using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Chinook.Sales.Api
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
