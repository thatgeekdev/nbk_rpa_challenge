import logging
import os
from datetime import datetime
from config import LOG_DIR

def create_logger():
    log_filename = f"rpa_{datetime.now():%Y%m%d_%H%M%S}.log"
    log_path = os.path.join(LOG_DIR, log_filename)

    logging.basicConfig(
        level=logging.INFO,
        format="%(asctime)s [%(levelname)s] %(message)s",
        handlers=[
            logging.FileHandler(log_path),
            logging.StreamHandler()
        ]
    )

    logger = logging.getLogger("RPA_LOGGER")
    logger.info(f"📜 Log file: {log_path}")
    return logger
