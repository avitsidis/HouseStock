using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace HouseStock.DataAccess.Tools
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configBuilder => {
                configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configBuilder.AddJsonFile("appSettings.json");
                configBuilder.AddUserSecrets(Assembly.GetExecutingAssembly());
                configBuilder.AddEnvironmentVariables();
                configBuilder.AddCommandLine(args);
            })
            .ConfigureServices((configure,servicesCollection) => Startup.ConfigureServices(servicesCollection, configure.Configuration.GetConnectionString("stock")))
            ;
    }

    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
            => DataAccess.Startup.ConfigureServices(services, connectionString);
    }
}
