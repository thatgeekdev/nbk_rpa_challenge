using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RPA_CS.Helpers;
using RPA_CS.Services;
using System.Collections.Generic;

namespace RPA_CS.Services
{
    public class BotService
    {
        private readonly IWebDriver _driver;
        private readonly LoggerService _log;
        private readonly ExportService _export;
        private readonly string _username;
        private readonly string _password;

        public BotService(LoggerService log, ExportService export, string username, string password, bool headless = false)
        {
            _log = log;
            _export = export;
            _username = username;
            _password = password;

            var options = new ChromeOptions();
            if (headless) options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--log-level=3");
            _driver = new ChromeDriver(options);
        }

        public string RunAndExportAllQuotes()
        {
            _log.Info("Navigating to quotes.toscrape.com/login");
            _driver.Navigate().GoToUrl("https://quotes.toscrape.com/login");

            var usernameInput = WaitHelper.WaitForElement(_driver, By.Name("username"));
            var passwordInput = WaitHelper.WaitForElement(_driver, By.Name("password"));
            var loginBtn = WaitHelper.WaitForElement(_driver, By.CssSelector("input[type='submit']"));

            usernameInput.SendKeys(_username);
            passwordInput.SendKeys(_password);
            loginBtn.Click();

            _log.Info("Logged in. Starting to scrape quotes...");

            var quotes = new List<(string Quote, string Author)>();

            while (true)
            {
                var quoteElements = _driver.FindElements(By.CssSelector(".quote"));
                foreach (var q in quoteElements)
                {
                    var text = q.FindElement(By.CssSelector(".text")).Text;
                    var author = q.FindElement(By.CssSelector(".author")).Text;
                    quotes.Add((text, author));
                }

                var nextBtn = _driver.FindElements(By.CssSelector(".next > a"));
                if (nextBtn.Count == 0) break;
                nextBtn[0].Click();
            }

            _log.Info($"Scraped {quotes.Count} quotes. Exporting CSV...");
            var path = _export.ExportQuotes(quotes);

            _driver.Quit();
            _log.Info($"Bot finished. CSV saved at {path}");

            return path;
        }
    }
}
