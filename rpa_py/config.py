import os

# === Paths ===
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
LOG_DIR = os.path.join(BASE_DIR, "logs")
EXPORT_DIR = os.path.join(BASE_DIR, "exports")

os.makedirs(LOG_DIR, exist_ok=True)
os.makedirs(EXPORT_DIR, exist_ok=True)

# === App Config ===
URL_LOGIN = "https://quotes.toscrape.com/login"
USERNAME = "admin"
PASSWORD = "admin"
HEADLESS = False
