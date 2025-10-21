### README.md

# NBK RPA Challenge (PYTHON)

## Overview

This project implements a simple and clean RPA (Robotic Process Automation) bot using **Python** and **Selenium**.

The bot:

1. Logs into a demo website: [Quotes to Scrape](https://quotes.toscrape.com/login)
2. Extracts quotes and authors from multiple pages
3. Saves the data in a CSV file under the `csv/` folder
4. Generates logs for all actions in the `logs/` folder

The project is structured for maintainability and clean code practices.

---

## Project Structure

```
rpa_py/
│
├── helpers/          # Utility functions (e.g., wait helpers, CSV helpers)
├── services/         # Bot services, scraping logic
├── logs/             # Automation logs
├── csv/              # Exported CSV files
├── main.py           # Entry point of the automation
├── config.py         # Configuration settings (headless, credentials)
├── requirements.txt  # Dependencies
└── README.md
```

---

## Setup

1. Clone the repository:

```bash
git clone <https://github.com/thatgeekdev/nbk_rpa_challenge.git>
cd rpa_py
```

2. Create a virtual environment:

```bash
python3 -m venv venv
source venv/bin/activate  # Linux/macOS
# .\venv\Scripts\activate  # Windows
```

3. Install dependencies:

```bash
pip install --upgrade pip
pip install -r requirements.txt
```

4. Run the bot:

```bash
python main.py
```

---

## Configuration

Settings are defined in `config.py`:

```python
HEADLESS = True           # Run browser in headless mode
USERNAME = "admin"        # Demo site username
PASSWORD = "admin"        # Demo site password
LOG_PATH = "logs/"
CSV_PATH = "csv/"
```

You can adjust these according to your environment.

---

## Features

* Clean and modular code: `helpers` and `services` separate responsibilities
* Automated multi-page scraping
* CSV export with timestamped filenames
* Logging of all actions and errors
* Easy configuration for headless mode and credentials

---

## Notes

* Ensure Chrome or Chromium is installed and compatible with `webdriver-manager`
* The project uses **WebDriver Manager** to automatically manage the correct ChromeDriver version
* All logs are saved in `logs/`
* All CSV files are saved in `csv/`

---

## License

MIT License

---

```
