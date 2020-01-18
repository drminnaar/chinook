using System.Reflection;
using AutoMapper;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Filters;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Orders;
using Chinook.Sales.Application.Invoices.Queries;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters;
using Chinook.Sales.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Sales.Application.DependencyInjection
{
    public static class ApplicationSetup
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddScoped<ICustomerFilterBuilder, CustomerFilterBuilder>()
                .AddScoped<IInvoiceFilterBuilder, InvoiceFilterBuilder>()
                .AddScoped<IEntityOrderBuilder<Customer>, CustomerOrderBuilder>()
                .AddScoped<IEntityOrderBuilder<Invoice>, InvoiceOrderBuilder>();
        }
    }
}
