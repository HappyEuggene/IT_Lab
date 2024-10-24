using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using IT_Lab.Models;

namespace IT_Lab.Services
{
    public class DatabaseService
    {
        private readonly string _filePath = "database.json";

        // Завантаження бази з JSON
        public List<TableModel> LoadDatabase()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<TableModel>>(json) ?? new List<TableModel>();
            }
            return new List<TableModel>();
        }

        // Збереження бази в JSON
        public void SaveDatabase(List<TableModel> tables)
        {
            var json = JsonSerializer.Serialize(tables, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
