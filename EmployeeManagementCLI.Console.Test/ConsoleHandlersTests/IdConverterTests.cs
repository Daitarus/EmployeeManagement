using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Console.Commands.Handler;
using EmployeeManagementCLI.Console.Commands.Models;
using EmployeeManagementCLI.Console.Test.MockModelsCreators;

namespace EmployeeManagementCLI.Console.Test.ConsoleHandlersTests
{
    [TestClass]
    public class IdConverterTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestNullCommands), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_IdConverter_For_Null(Command? command)
        {
            IModelConverter<Command, int> modelConverter = new IdConverter();
            var result = modelConverter.Convert(command);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCommands), DynamicDataSourceType.Method)]
        public void Test_IdConverter(Command command, int answerId)
        {
            IModelConverter<Command, int> modelConverter = new IdConverter();
            var result = modelConverter.Convert(command);
            Assert.AreEqual(result, answerId);
        }

        private static IEnumerable<object?[]> GetTestNullCommands()
        {
            yield return new object?[] { CommandCreator.Null_model };
        }

        private static IEnumerable<object?[]> GetTestCommands()
        {
            yield return new object?[] { CommandCreator.Delete_command_unknown_args_model, 0 };
            yield return new object?[] { CommandCreator.Update_command_valid_args_model, 14 };
            yield return new object?[] { CommandCreator.Get_Command_negativ_id_model, -24 };
            yield return new object?[] { CommandCreator.Delete_Command_float_id_model, 0 };
            yield return new object?[] { CommandCreator.Update_Command_zero_id_model, 0 };
        }
    }
}
