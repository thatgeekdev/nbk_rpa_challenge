using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace RPA_CS.Helpers
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(d => d.FindElement(by));
            }
            catch
            {
                return null;
            }
        }
    }
}
