using EmployeeManagementCLI.Console.Commands.Handler;
using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Console.Commands.Models;
using EmployeeManagementCLI.Console.Test.MockModels;
using EmployeeManagementCLI.Console.Test.MockModelsCreators;

namespace EmployeeManagementCLI.Console.Test.ConsoleHandlersTests
{
    [TestClass]
    public class CommandHandlerTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestNullCommands), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CommandHandler_For_NullCommand(Command? command)
        {
            ICommandHandler commandHandler = new CommandHandler(new TestCommandController());
            var result = commandHandler.Execute(command);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCommands), DynamicDataSourceType.Method)]
        public void Test_CommandHandler(Command command, string answer)
        {
            ICommandHandler commandHandler = new CommandHandler(new TestCommandController());
            var result = commandHandler.Execute(command);
            Assert.AreEqual(answer, result);
        }

        private static IEnumerable<object?[]> GetTestNullCommands()
        {
            yield return new object?[] { CommandCreator.Null_model};
        }

        private static IEnumerable<object?[]> GetTestCommands()
        {
            yield return new object?[] { CommandCreator.Unknown_command_empty_args_model, "unknown" };
            yield return new object?[] { CommandCreator.Add_command_valid_args_model, "add" };
            yield return new object?[] { CommandCreator.Delete_command_valid_args_model, "delete" };
            yield return new object?[] { CommandCreator.Get_command_valid_args_model, "get" };
            yield return new object?[] { CommandCreator.GetAll_command_no_args_model, "getall" };
            yield return new object?[] { CommandCreator.Update_command_valid_args_model, "update" };
        }
    }
}
