using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Operations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters
{
    public sealed class HireDateFilter : EqualityFilterBase<Employee, DateTime>
    {
        public HireDateFilter(string filterExpression) : base(filterExpression)
        {
        }

        protected override IDictionary<string, Expression<Func<Employee, bool>>> CreateEqualityOperatorExpressionLookup()
        {
            return new Dictionary<string, Expression<Func<Employee, bool>>>
            {
                { "gt", e => e.HireDate > Value},
                { "gte", e => e.HireDate >= Value},
                { "lt", e => e.HireDate < Value},
                { "lte", e => e.HireDate <= Value},
                { "eq", e => e.HireDate == Value}
            };
        }
    }
}
