using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters
{
    public sealed class TotalFilter : EqualityFilterBase<Invoice, decimal>
    {
        public TotalFilter(string filterExpression) : base(filterExpression)
        {
        }

        protected override IDictionary<string, Expression<Func<Invoice, bool>>> CreateEqualityOperatorExpressionLookup()
        {
            return new Dictionary<string, Expression<Func<Invoice, bool>>>
            {
                { "gt", e => e.Total > Value},
                { "gte", e => e.Total >= Value},
                { "lt", e => e.Total < Value},
                { "lte", e => e.Total <= Value},
                { "eq", e => e.Total == Value}
            };
        }
    }
}
