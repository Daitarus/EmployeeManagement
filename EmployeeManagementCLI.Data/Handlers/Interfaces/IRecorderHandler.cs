namespace EmployeeManagementCLI.Data.Handlers.Interfaces
{
    public interface IRecorderHandler
    {
        public T? ReadModel<T>() where T : class;

        public void WriteModel<T>(T model) where T : class;

        public Task<T?> ReadModelAsync<T>() where T : class;

        public Task WriteModelAsync<T>(T model) where T : class;
    }
}
