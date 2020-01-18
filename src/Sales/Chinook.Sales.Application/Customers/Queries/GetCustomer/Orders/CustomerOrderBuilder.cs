using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Orders
{
    public sealed class CustomerOrderBuilder : EntityOrderBuilderBase<Customer>
    {
        protected override IDictionary<string, Expression<Func<Customer, object>>> CreateSelectorLookup()
        {
            return new Dictionary<string, Expression<Func<Customer, object>>>
            {
                { "address", e => e.Address! },
                { "city", e => e.City! },
                { "company", e => e.Company! },
                { "country", e => e.Country! },
                { "customer-id", e => e.Id! },
                { "email", e => e.Email! },
                { "fax", e => e.Fax! },
                { "first-name", e => e.FirstName! },
                { "last-name", e => e.LastName! },
                { "phone", e => e.Phone! },
                { "code", e => e.PostalCode! },
                { "state", e => e.State! }
            };
        }
    }
}
