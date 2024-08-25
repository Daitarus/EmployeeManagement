using EmployeeManagement.Console.Application.Interfaces;
using EmployeeManagement.Console.Commands.Factories.Interfaces;
using EmployeeManagement.Console.Commands.Handler.Interfaces;

namespace EmployeeManagement.Console.Application
{
    public class ApplicationRunner : IApplicationRunner
    {
        private readonly ICommandFactory _commandFactory;
        private readonly ICommandHandler _commandHandler;

        public ApplicationRunner(ICommandFactory commandFactory, ICommandHandler commandHandler)
        {
            _commandFactory = commandFactory;
            _commandHandler = commandHandler;
        }

        public void Run(string[]? args = null)
        {
            if(args == null || args.Length == 0)
            {
                ViewWorkRun();
            }
            else
            {
                WorkSpace(args);
            }
        }

        public void ViewWorkRun()
        {
            while(true)
            {
                System.Console.Write("Enter your command: ");
                var inputLine = System.Console.ReadLine();

                var args = inputLine?.Split(' ');
                WorkSpace(args);
            }
        }

        public void WorkSpace(string[]? args)
        {
            var command = _commandFactory.Create(args);
            var answer = _commandHandler.Execute(command);
            System.Console.WriteLine(answer);
        }
    }
}
