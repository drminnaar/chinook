using System.Reflection;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Orders;
using Chinook.Operations.Application.Services;
using Chinook.Operations.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Operations.Application.DependencyInjection
{
    public static class ApplicationSetup
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            return services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddScoped<IEmployeeFilterBuilder, EmployeeFilterBuilder>()
                .AddScoped<IEntityOrderBuilder<Employee>, EmployeeOrderBuilder>()
                .AddScoped<IBirthDateValidationService, BirthDateValidationService>()
                .AddScoped<IEmailAssignmentService, DummyEmailAssignmentService>()
                .AddScoped<IFaxNumberAssignmentService, DummyFaxNumberAssignmentService>()
                .AddScoped<IPhoneNumberAssignmentService, DummyPhoneNumberAssignmentService>()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
