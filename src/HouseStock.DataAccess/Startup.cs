using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HouseStock.DataAccess
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            System.Console.WriteLine($"CS:{connectionString}");
            services.AddDbContext<HouseStockDbContext>(
                options => options.UseMySQL(connectionString)
                );
        }
    }
}
