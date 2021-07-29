using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kumojin.Blazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Kumojin.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var baseAddress = "https://localhost:5001";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            builder.Services.AddScoped<ITimeZoneService, TimeZoneService>();

            await builder.Build().RunAsync();
        }
    }
}