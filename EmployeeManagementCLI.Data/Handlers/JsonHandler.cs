using EmployeeManagementCLI.Data.Handlers.Interfaces;
using System.Text.Json;

namespace EmployeeManagementCLI.Data.Handlers
{
    public class JsonHandler : IRecorderHandler
    {
        public string JsonPath { private get; set; }

        public JsonHandler(string jsonPath)
        {
            JsonPath = jsonPath;
        }

        public T? ReadModel<T>() where T : class
        {
            using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
        }

        public void WriteModel<T>(T model) where T : class
        {
            CreateDirectoryIfNotExist();

            using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, model);
            }
        }

        public async Task<T?> ReadModelAsync<T>() where T : class
        {
            using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }

        public async Task WriteModelAsync<T>(T model) where T : class
        {
            CreateDirectoryIfNotExist();

            using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, model);
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
