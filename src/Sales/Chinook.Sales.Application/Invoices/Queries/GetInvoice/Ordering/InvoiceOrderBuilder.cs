using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice
{
    public sealed class InvoiceOrderBuilder : EntityOrderBuilderBase<Invoice>
    {
        protected override IDictionary<string, Expression<Func<Invoice, object>>> CreateSelectorLookup()
        {
            return new Dictionary<string, Expression<Func<Invoice, object>>>()
            {
                { "id", e => e.Id},
                { "date", e => e.InvoiceDate },
                { "total", e => e.Total},
                { "address", e => e.BillingAddress! },
                { "city", e => e.BillingCity! },
                { "country", e => e.BillingCountry! },
                { "code", e => e.BillingPostalCode! },
                { "state", e => e.BillingState! }
            };
        }
    }
}
