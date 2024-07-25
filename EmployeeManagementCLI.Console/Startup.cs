using EmployeeManagementCLI.Console.Commands.Controllers.Interfaces;
using EmployeeManagementCLI.Console.Commands.Controllers;
using EmployeeManagementCLI.Console.Commands.Factories.Interfaces;
using EmployeeManagementCLI.Console.Commands.Factories;
using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Console.Commands.Handler;
using EmployeeManagementCLI.Console.Commands.Models;
using EmployeeManagementCLI.Data.Context;
using EmployeeManagementCLI.Data.Contexts.Interfaces;
using EmployeeManagementCLI.Data.Handlers.Interfaces;
using EmployeeManagementCLI.Data.Handlers;
using EmployeeManagementCLI.Domain.Models;
using EmployeeManagementCLI.Domain.Services.Interfaces;
using EmployeeManagementCLI.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using EmployeeEntity = EmployeeManagementCLI.Data.Entities.Employee;
using EmployeeModel = EmployeeManagementCLI.Domain.Models.Employee;
using EmployeeManagementCLI.Console.Application.Interfaces;
using EmployeeManagementCLI.Console.Application;

namespace EmployeeManagementCLI.Console
{
    internal class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigurationService(IServiceCollection services)
        {
            services.AddSingleton<IRecorderHandler, JsonHandler>(); //add jsonPath
            services.AddSingleton<IContext<EmployeeEntity>, EmployeeContext>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.AddSingleton<IModelConverter<Command, EmployeeModel>, EmployeeConverter>();
            services.AddSingleton<IModelConverter<Command, int>, IdConverter>();
            services.AddSingleton<IModelConverter<Message, string>, MessageConverter>();

            services.AddSingleton<ICommandController, CommandController>();
            services.AddSingleton<ICommandHandler, CommandHandler>();
            services.AddSingleton<ICommandFactory, CommandFactory>();

            services.AddSingleton<IApplicationRunner, ApplicationRunner>();
        }
    }
}
