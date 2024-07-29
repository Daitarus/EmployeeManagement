using EmployeeManagementCLI.Console.Commands.Handler;
using EmployeeManagementCLI.Console.Test.MockModels;
using EmployeeManagementCLI.Console.Test.MockModelsCreators;
using EmployeeManagementCLI.Domain.Services.Interfaces;
using EmployeeManagementCLI.Console.Commands.Controllers;

namespace EmployeeManagementCLI.Console.Test.ControllersTests
{
    [TestClass]
    public class CommandControllerTests
    {
        #region Add
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Add_For_NullCommand()
        {
            var command = CommandCreator.Null_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Add(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Add_For_Not_Add_Command()
        {
            var command = CommandCreator.Get_Command_negativ_id_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Add(command);
        }

        [TestMethod]
        public void Test_Add_For_Add_Command()
        {
            var command = CommandCreator.Add_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            var result = controller.Add(command);
            Assert.AreEqual(result, "add");
        }
        #endregion

        #region Delete
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Delete_For_NullCommand()
        {
            var command = CommandCreator.Null_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Delete(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Delete_For_Not_Delete_Command()
        {
            var command = CommandCreator.Get_Command_negativ_id_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Delete(command);
        }

        [TestMethod]
        public void Test_Delete_For_Delete_Command()
        {
            var command = CommandCreator.Delete_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            var result = controller.Delete(command);
            Assert.AreEqual(result, "delete");
        }
        #endregion

        #region Get
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Get_For_NullCommand()
        {
            var command = CommandCreator.Null_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Get(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Get_For_Not_Get_Command()
        {
            var command = CommandCreator.Delete_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Get(command);
        }

        [TestMethod]
        public void Test_Get_For_Get_Command()
        {
            var command = CommandCreator.Get_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            var result = controller.Get(command);
            Assert.AreEqual(result, "get");
        }
        #endregion

        #region GetAll
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_GetAll_For_NullCommand()
        {
            var command = CommandCreator.Null_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.GetAll(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetAll_For_Not_GetAll_Command()
        {
            var command = CommandCreator.Delete_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.GetAll(command);
        }

        [TestMethod]
        public void Test_GetAll_For_GetAll_Command()
        {
            var command = CommandCreator.GetAll_command_no_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            var result = controller.GetAll(command);
            Assert.AreEqual(result, "getall");
        }
        #endregion

        #region Update
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Update_For_NullCommand()
        {
            var command = CommandCreator.Null_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Update(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Update_For_Not_Update_Command()
        {
            var command = CommandCreator.Delete_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Update(command);
        }

        [TestMethod]
        public void Test_Update_For_Update_Command()
        {
            var command = CommandCreator.Update_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            var result = controller.Update(command);
            Assert.AreEqual(result, "update");
        }
        #endregion

        #region Unknown
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Unknown_For_NullCommand()
        {
            var command = CommandCreator.Null_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Unknown(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Unknown_For_Not_Unknown_Command()
        {
            var command = CommandCreator.Delete_command_valid_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            controller.Unknown(command);
        }

        [TestMethod]
        public void Test_Unknown_For_Unknown_Command()
        {
            var command = CommandCreator.Unknown_command_empty_args_model;

            IEmployeeService service = new TestEmployeeService();
            var idConverter = new IdConverter();
            var messageConverter = new MessageConverter();
            var employeeConverter = new EmployeeConverter();

            var controller = new CommandController(service, employeeConverter, idConverter, messageConverter);
            var result = controller.Unknown(command);
            Assert.AreEqual(result, "There is no such command!");
        }
        #endregion
    }
}
