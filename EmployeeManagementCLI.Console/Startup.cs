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
using Serilog;
using Serilog.Extensions.Logging;
using EmployeeManagementCLI.Console.Settings;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementCLI.Console
{
    internal class Startup
    {
        public IConfiguration Configuration { get; }

        private AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettings = Configuration.Get<AppSettings>() ?? new AppSettings();
        }

        public void ConfigurationService(IServiceCollection services)
        {
            var serilog = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            var loggerFactory = new SerilogLoggerFactory(serilog);

            services.AddSingleton<ILogger<EmployeeService>>(loggerFactory.CreateLogger<EmployeeService>());

            services.AddSingleton<IRecorderHandler>(new JsonHandler(_appSettings.JsonHandlerPath));

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
