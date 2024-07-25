using EmployeeManagementCLI.Console.Application.Interfaces;
using EmployeeManagementCLI.Console.Container;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementCLI.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = GetConfiguration();
            var serviceProvider = new ServiceCollection().UseStartup<Startup>(configuration).BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<IApplicationRunner>();
            app.Run(args);
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
              .AddJsonFile("appsettings.dev", true)
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}
