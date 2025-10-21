using System;

namespace RPA_CS.Config
{
    public class ConfigService
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin";
        public string LogPath { get; set; } = "Logs";
        public string ExportPath { get; set; } = "Exports";
    }
}
