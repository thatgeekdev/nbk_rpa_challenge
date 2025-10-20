from helpers.logger_helper import create_logger
from services.bot_service import BotService
from services.export_service import export_to_csv

def main():
    logger = create_logger()
    logger.info("🚀 Starting RPA Automation...")

    bot = BotService(logger)
    try:
        bot.login()
        data = bot.collect_quotes()
        export_to_csv(data, logger)
        logger.info("✅ Automation finished successfully.")
    except Exception as e:
        logger.error(f"❌ Error: {e}")
    finally:
        bot.close()
        logger.info("🏁 Process finished.")

if __name__ == "__main__":
    main()
