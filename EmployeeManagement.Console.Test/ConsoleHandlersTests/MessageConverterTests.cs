using EmployeeManagement.Console.Commands.Handler.Interfaces;
using EmployeeManagement.Console.Commands.Handler;
using EmployeeManagement.Console.Test.MockModelsCreators;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Console.Test.ConsoleHandlersTests
{
    [TestClass]
    public class MessageConverterTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestNullCommands), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_MessageConverter_For_Null(Message? message)
        {
            IModelConverter<Message, string> modelConverter = new MessageConverter();
            var result = modelConverter.Convert(message);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCommands), DynamicDataSourceType.Method)]
        public void Test_MessageConverter(Message message, string answer)
        {
            IModelConverter<Message, string> modelConverter = new MessageConverter();
            var result = modelConverter.Convert(message);
            Assert.AreEqual(result, answer);
        }

        private static IEnumerable<object?[]> GetTestNullCommands()
        {
            yield return new object?[] { MessageCreator.Null_model };
        }

        private static IEnumerable<object?[]> GetTestCommands()
        {
            yield return new object?[] { MessageCreator.Empty_model, null };
            yield return new object?[] { MessageCreator.Empty_text_model, string.Empty };
            yield return new object?[] { MessageCreator.Full_model, "testString" };
        }
    }
}
