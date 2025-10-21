# RPA Challenge Projects

This repository contains two automation projects developed as part of a RPA (Robotic Process Automation) challenge. The goal of both projects is to demonstrate the ability to:

* Access a website
* Perform login
* Extract information
* Save data in CSV/Excel
* Generate logs for tracking

The projects are implemented in **C# (.NET + Selenium)** and **Python (Selenium)**, following **clean code principles** and organized in separate directories.

---

## Project Structure

```
/
├── RPA_CS/              # C# + Selenium project
│   ├── Config/          # Configuration service
│   ├── Services/        # Core automation logic
│   ├── Helpers/         # Utility functions
│   ├── Logs/            # Logs generated during execution
│   ├── Exports/         # CSV/Excel outputs
│   └── Program.cs       # Main entry point
│   └── .gitignore        # Git ignore for C# project
│
├── rpa_py/              # Python + Selenium project
│   ├── services/        # Core automation logic
│   ├── helpers/         # Utility functions
│   ├── Logs/            # Logs generated during execution
│   ├── Exports/         # CSV/Excel outputs
│   ├── config.py        # Configuration variables
│   └── main.py          # Main entry point
│   └── .gitignore       # Git ignore for Python project
│
└── .gitignore           # Git ignore for both projects
```

---

## Requirements

### C# Project (RPA_CS)

* .NET SDK 7.0 or later
* Google Chrome (or any supported browser)
* Selenium WebDriver
* NuGet packages:

  * Selenium.WebDriver
  * Selenium.WebDriver.ChromeDriver
  * NLog (or any logging library)

### Python Project (rpa_py)

* Python 3.10+
* pip packages:

  * selenium
  * pandas
  * webdriver-manager

---

## How to Run

### C# Project

1. Open a terminal in `RPA_CS`.
2. Restore NuGet packages:

   ```bash
   dotnet restore
   ```
3. Run the project:

   ```bash
   dotnet run
   ```
4. Logs will be generated in `RPA_CS/Logs` and CSV files in `RPA_CS/Exports`.

### Python Project

1. Create and activate a virtual environment:

   ```bash
   python -m venv venv
   source venv/bin/activate  # Linux/Mac
   venv\Scripts\activate     # Windows
   ```
2. Install dependencies:

   ```bash
   pip install -r requirements.txt
   ```
3. Run the bot:

   ```bash
   python main.py
   ```
4. Logs will be generated in `rpa_py/Logs` and CSV files in `rpa_py/Exports`.

---

## Features

* Clean and modular code structure
* Configurable login credentials
* Automatic CSV/Excel export
* Logging of each step
* Handles dynamic web pages
* Easily extensible for new automation tasks

---

## Notes

* Make sure your browser version matches the WebDriver version.
* Update configuration variables (username/password, URLs) in the `.env` file (C#) or `config.py` (Python).
* All generated logs and CSVs are automatically stored in their respective folders.
