using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Console.Commands.Handler;
using EmployeeManagementCLI.Console.Commands.Models;
using EmployeeManagementCLI.Console.Test.MockModelsCreators;
using EmployeeManagementCLI.Domain.Models;

namespace EmployeeManagementCLI.Console.Test.ConsoleHandlersTests
{
    [TestClass]
    public class EmployeeConverterTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestNullCommands), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_EmployeeConverter_For_Null(Command? command)
        {
            IModelConverter<Command, Employee> modelConverter = new EmployeeConverter();
            var result = modelConverter.Convert(command);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCommands), DynamicDataSourceType.Method)]
        public void Test_EmployeeConverter(Command command, Employee answerEmployee)
        {
            IModelConverter<Command, Employee> modelConverter = new EmployeeConverter();
            var result = modelConverter.Convert(command);
            Assert.AreEqual(result, answerEmployee);
        }

        private static IEnumerable<object?[]> GetTestNullCommands()
        {
            yield return new object?[] { CommandCreator.Null_model };
        }

        private static IEnumerable<object?[]> GetTestCommands()
        {
            yield return new object?[] { CommandCreator.Unknown_one_args_model, EmployeeCreator.Empty_model };
            yield return new object?[] { CommandCreator.Get_command_valid_args_model, EmployeeCreator.Only_id_model };
            yield return new object?[] { CommandCreator.Add_command_valid_args_model, EmployeeCreator.No_id_model };
            yield return new object?[] { CommandCreator.Full_Update_command_valid_args_model, EmployeeCreator.Full_model };
            yield return new object?[] { CommandCreator.Get_Command_negativ_id_model, EmployeeCreator.Only_negativ_id_model };
            yield return new object?[] { CommandCreator.Add_command_change_order_args_mode, EmployeeCreator.Negativ_salary_model };
        }
    }
}
