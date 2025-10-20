import pandas as pd
import os
from datetime import datetime
from config import EXPORT_DIR

def export_to_csv(data, logger):
    if not data:
        logger.warning("⚠️ No data to export.")
        return None

    filename = f"quotes_{datetime.now():%Y%m%d_%H%M%S}.csv"
    filepath = os.path.join(EXPORT_DIR, filename)

    pd.DataFrame(data).to_csv(filepath, index=False)
    logger.info(f"✅ Data exported to {filepath}")
    return filepath
