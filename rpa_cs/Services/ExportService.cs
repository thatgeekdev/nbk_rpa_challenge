using System;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;

namespace RPA_CS.Services
{
    public class ExportService
    {
        private readonly string _exportDir;

        public ExportService(string exportDir)
        {
            _exportDir = exportDir;
            Directory.CreateDirectory(_exportDir);
        }

        public string ExportQuotes(List<(string Quote, string Author)> quotes)
        {
            var filePath = Path.Combine(_exportDir, $"quotes_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(quotes.ConvertAll(q => new { Quote = q.Quote, Author = q.Author }));
            }

            return filePath;
        }
    }
}
