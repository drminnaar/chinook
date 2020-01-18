using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters
{
    public sealed class DateFilter : EqualityFilterBase<Invoice, DateTime>
    {
        public DateFilter(string filterExpression) : base(filterExpression)
        {
        }

        protected override IDictionary<string, Expression<Func<Invoice, bool>>> CreateEqualityOperatorExpressionLookup()
        {
            return new Dictionary<string, Expression<Func<Invoice, bool>>>
            {
                { "gt", e => e.InvoiceDate > Value},
                { "gte", e => e.InvoiceDate >= Value},
                { "lt", e => e.InvoiceDate < Value},
                { "lte", e => e.InvoiceDate <= Value},
                { "eq", e => e.InvoiceDate == Value}
            };
        }
    }
}
