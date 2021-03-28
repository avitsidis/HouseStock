using HouseStock.Presentation.Blazor.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Debug));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<RoomControllerProxy>();
            builder.Services.AddTransient<ShelfControllerProxy>();
            builder.Services.AddTransient<ProductControllerProxy>();
            builder.Services.AddTransient<ProductInstanceControllerProxy>();
            builder.Services.AddScoped<VersionControllerProxy>();


            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            await builder.Build().RunAsync();
        }
    }
}
