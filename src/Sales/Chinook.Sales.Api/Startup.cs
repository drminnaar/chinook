using System;
using Chinook.Sales.Api.DependencyInjection;
using Chinook.Sales.Application.DependencyInjection;
using Chinook.Sales.Data.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chinook.Sales.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplication();
            services.ConfigureData(_configuration.GetConnectionString("chinook"), _environment.IsDevelopment());
            services.ConfigureControllers();
            services.ConfigureUrlHelper();
            services.ConfigureSwagger();
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/errors");
            app.UseStaticFiles();
            app.UseCustomSwagger();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
