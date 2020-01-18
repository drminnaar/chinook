using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Sales.Api.DependencyInjection
{
    internal static class UrlHelperSetup
    {
        internal static IServiceCollection ConfigureUrlHelper(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(serviceProvider =>
            {
                var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = serviceProvider.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            return services;
        }
    }
}
