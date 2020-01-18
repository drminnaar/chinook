using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Catalog.Api.DependencyInjection
{
    internal static class ControllerSetup
    {
        internal static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
            })
            .AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setup =>
            {
                setup.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = $"https://httpstatuses.com/{StatusCodes.Status422UnprocessableEntity}",
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };

                    problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });

            return services;
        }
    }
}
