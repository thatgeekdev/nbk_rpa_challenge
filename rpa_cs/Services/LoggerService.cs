using System;
using System.IO;

namespace RPA_CS.Services
{
    public class LoggerService
    {
        private readonly string _logDir;
        private readonly string _logFile;

        public LoggerService(string logDir)
        {
            _logDir = logDir;
            Directory.CreateDirectory(_logDir);
            _logFile = Path.Combine(_logDir, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
        }

        public void Info(string message) => WriteLog("INFO", message);
        public void Error(string message) => WriteLog("ERROR", message);
        public void Warn(string message) => WriteLog("WARN", message);

        private void WriteLog(string level, string message)
        {
            var logMsg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            Console.WriteLine(logMsg);
            File.AppendAllText(_logFile, logMsg + Environment.NewLine);
        }
    }
}
