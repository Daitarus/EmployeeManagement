using EmployeeManagementCLI.Data.Handlers.Interfaces;
using System.Text.Json;

namespace EmployeeManagementCLI.Data.Handlers
{
    public class JsonHandler : IRecorderHandler
    {
        public string JsonPath { private get; set; }

        private JsonSerializerOptions _otions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        public JsonHandler(string jsonPath)
        {
            JsonPath = jsonPath;
        }

        public T? ReadModel<T>() where T : class
        {
            if (File.Exists(JsonPath))
            {
                using (FileStream fs = new FileStream(JsonPath, FileMode.Open, FileAccess.Read))
                {
                    return JsonSerializer.Deserialize<T>(fs, _otions);
                }
            }
            else
            {
                return null;
            }
        }

        public void WriteModel<T>(T model) where T : class
        {
            CreateDirectoryIfNotExist();

            using (FileStream fs = new FileStream(JsonPath, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, model, _otions);
            }
        }

        public async Task<T?> ReadModelAsync<T>() where T : class
        {
            if (File.Exists(JsonPath))
            {
                using (FileStream fs = new FileStream(JsonPath, FileMode.Open, FileAccess.Read))
                {
                    return await JsonSerializer.DeserializeAsync<T>(fs, _otions);
                }
            }
            else
            {
                return null;
            }
        }

        public async Task WriteModelAsync<T>(T model) where T : class
        {
            CreateDirectoryIfNotExist();

            using (FileStream fs = new FileStream(JsonPath, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, model, _otions);
            }
        }

        private void CreateDirectoryIfNotExist()
        {
            var directoryPath = Path.GetDirectoryName(JsonPath);

            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
