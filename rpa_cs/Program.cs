using RPA_CS.Config;
using RPA_CS.Services;
using System;

namespace RPA_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigService();
            var log = new LoggerService(config.LogPath);
            var export = new ExportService(config.ExportPath);

            log.Info("🚀 Automation started");

            try
            {
                var bot = new BotService(log, export, config.Username, config.Password, headless: false);
                var csvPath = bot.RunAndExportAllQuotes();

                log.Info($"CSV generated at: {csvPath}");
            }
            catch (Exception ex)
            {
                log.Error("Fatal error: " + ex.Message);
            }

            log.Info("🏁 Automation finished");
        }
    }
}
