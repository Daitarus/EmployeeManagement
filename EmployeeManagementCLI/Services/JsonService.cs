using EmployeeManagementCLI.Models;
using System.Text.Json;

namespace EmployeeManagementCLI.Services
{
    public class JsonService
    {
        public string JsonPath { private get; set; }

        public JsonService(string jsonPath)
        {
            JsonPath = jsonPath;
        }

        public async Task<T?> ReadModel<T>() where T : class
        {
            using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }

        public async Task WriteModel<T>(T model) where T : class
        {
            using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, model);
            }
        }
    }
}
