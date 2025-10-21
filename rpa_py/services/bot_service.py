import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from webdriver_manager.chrome import ChromeDriverManager
import config

class BotService:
    def __init__(self, logger):
        self.logger = logger
        self.driver = self._init_driver()

    def _init_driver(self):
        options = Options()
        if config.HEADLESS:
            options.add_argument("--headless=new")
        options.add_argument("--no-sandbox")
        options.add_argument("--disable-gpu")
        options.add_argument("--disable-dev-shm-usage")
        options.add_experimental_option("prefs", {
            "credentials_enable_service": False,
            "profile.password_manager_enabled": False
        })

        service = Service(ChromeDriverManager().install())
        driver = webdriver.Chrome(service=service, options=options)
        self.logger.info("🌐 Chrome WebDriver initialized.")
        return driver

    def login(self):
        self.logger.info("🔑 Navigating to login page...")
        self.driver.get(config.URL_LOGIN)

        WebDriverWait(self.driver, 10).until(EC.presence_of_element_located((By.NAME, "username")))
        self.driver.find_element(By.NAME, "username").send_keys(config.USERNAME)
        self.driver.find_element(By.NAME, "password").send_keys(config.PASSWORD)
        self.driver.find_element(By.CSS_SELECTOR, "input[type='submit']").click()
        self.logger.info("✅ Login successful.")

        time.sleep(2)

    def collect_quotes(self):
        self.logger.info("📚 Collecting quotes...")
        all_quotes = []

        while True:
            quotes = self.driver.find_elements(By.CLASS_NAME, "quote")
            for q in quotes:
                text = q.find_element(By.CLASS_NAME, "text").text
                author = q.find_element(By.CLASS_NAME, "author").text
                all_quotes.append({"quote": text, "author": author})

            # Tenta clicar em "Next"
            try:
                next_button = self.driver.find_element(By.CSS_SELECTOR, "li.next > a")
                next_button.click()
                time.sleep(1.5)
            except:
                self.logger.info("🏁 No more pages.")
                break

        self.logger.info(f"📊 Collected {len(all_quotes)} quotes.")
        return all_quotes

    def close(self):
        self.driver.quit()
        self.logger.info("🧹 Browser closed.")
