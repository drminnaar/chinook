using System;
using Chinook.Catalog.Api.DependencyInjection;
using Chinook.Catalog.Application.DependencyInjection;
using Chinook.Catalog.Data.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chinook.Catalog.Api
{
    public sealed class Startup
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
            services.ConfigureData(_configuration.GetConnectionString("chinook"), _environment.IsDevelopment());
            services.ConfigureApplication();
            services.ConfigureUrlHelper();
            services.ConfigureControllers();
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
