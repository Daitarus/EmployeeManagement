using EmployeeManagement.Console.Application.Interfaces;
using EmployeeManagement.Console.Container;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Console
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
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.dev.json", true)
                .Build();
        }
    }
}
