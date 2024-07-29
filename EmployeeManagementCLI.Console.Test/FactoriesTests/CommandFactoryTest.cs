using EmployeeManagementCLI.Console.Commands.Factories;
using EmployeeManagementCLI.Console.Commands.Factories.Interfaces;
using EmployeeManagementCLI.Console.Commands.Models;
using EmployeeManagementCLI.Console.Test.MockModelsCreators;

namespace EmployeeManagementCLI.Console.Test.FactoriesTests
{
    [TestClass]
    public class CommandFactoryTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestUserArgsAndCommands), DynamicDataSourceType.Method)]
        public void Test_CommandFactory_For_Command(string[] args, Command answerCommand)
        {
            ICommandFactory commandFactory = new CommandFactory();
            Command command = commandFactory.Create(args);
            Assert.AreEqual(command, answerCommand);
        }

        private static IEnumerable<object?[]> GetTestUserArgsAndCommands()
        {
            yield return new object?[] { InputArgsCreator.Null_model, CommandCreator.Unknown_command_empty_args_model };
            yield return new object?[] { InputArgsCreator.Empty_model, CommandCreator.Unknown_command_empty_args_model };

            yield return new object?[] { InputArgsCreator.Unknown_model, CommandCreator.Unknown_command_empty_args_model };
            yield return new object?[] { InputArgsCreator.Unknown_one_args_model, CommandCreator.Unknown_one_args_model };
            yield return new object?[] { InputArgsCreator.Unknown_two_args_model, CommandCreator.Unknown_two_args_model };

            yield return new object?[] { InputArgsCreator.Unknown_command_valid_args_model, CommandCreator.Unknown_command_valid_args_model };

            yield return new object?[] { InputArgsCreator.Add_command_empty_args_model, CommandCreator.Add_command_empty_args_model };
            yield return new object?[] { InputArgsCreator.Delete_command_unknown_args_model, CommandCreator.Delete_command_unknown_args_model };

            yield return new object?[] { InputArgsCreator.Get_command_only_id_args_model, CommandCreator.Get_command_only_id_args_model };
            yield return new object?[] { InputArgsCreator.Delete_command_more_args_model, CommandCreator.Delete_command_more_args_model };

            yield return new object?[] { InputArgsCreator.Add_command_change_order_args_model, CommandCreator.Add_command_change_order_args_mode };

            yield return new object?[] { InputArgsCreator.Add_command_valid_args_model, CommandCreator.Add_command_valid_args_model };
            yield return new object?[] { InputArgsCreator.Delete_command_valid_args_model, CommandCreator.Delete_command_valid_args_model };
            yield return new object?[] { InputArgsCreator.Get_command_valid_args_model, CommandCreator.Get_command_valid_args_model };
            yield return new object?[] { InputArgsCreator.GetAll_command_no_args_model, CommandCreator.GetAll_command_no_args_model };
            yield return new object?[] { InputArgsCreator.Update_command_valid_args_model, CommandCreator.Update_command_valid_args_model };

            yield return new object?[] { InputArgsCreator.Get_command_many_separation_args_model, CommandCreator.Get_command_valid_args_model };
        }
    }
}
