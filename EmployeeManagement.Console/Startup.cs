using EmployeeManagement.Console.Commands.Controllers.Interfaces;
using EmployeeManagement.Console.Commands.Controllers;
using EmployeeManagement.Console.Commands.Factories.Interfaces;
using EmployeeManagement.Console.Commands.Factories;
using EmployeeManagement.Console.Commands.Handler.Interfaces;
using EmployeeManagement.Console.Commands.Handler;
using EmployeeManagement.Console.Commands.Models;
using EmployeeManagement.Data.Context;
using EmployeeManagement.Data.Contexts.Interfaces;
using EmployeeManagement.Data.Handlers.Interfaces;
using EmployeeManagement.Data.Handlers;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Services.Interfaces;
using EmployeeManagement.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using EmployeeEntity = EmployeeManagement.Data.Entities.Employee;
using EmployeeModel = EmployeeManagement.Domain.Models.Employee;
using EmployeeManagement.Console.Application.Interfaces;
using EmployeeManagement.Console.Application;
using Serilog;
using Serilog.Extensions.Logging;
using EmployeeManagement.Console.Settings;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Console
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
