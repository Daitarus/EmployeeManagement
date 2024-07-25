namespace EmployeeManagementCLI.Console.Commands.Handler.Interfaces
{
    public interface IModelConverter<T, TResult>
    {
        public TResult Convert(T model);
    }
}
