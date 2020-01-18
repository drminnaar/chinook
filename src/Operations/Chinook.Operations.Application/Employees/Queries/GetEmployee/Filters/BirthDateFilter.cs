using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Operations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters
{
    public sealed class BirthDateFilter : EqualityFilterBase<Employee, DateTime>
    {
        public BirthDateFilter(string filterExpression) : base(filterExpression)
        {
        }

        protected override IDictionary<string, Expression<Func<Employee, bool>>> CreateEqualityOperatorExpressionLookup()
        {
            return new Dictionary<string, Expression<Func<Employee, bool>>>
            {
                { "gt", e => e.BirthDate > Value},
                { "gte", e => e.BirthDate >= Value},
                { "lt", e => e.BirthDate < Value},
                { "lte", e => e.BirthDate <= Value},
                { "eq", e => e.BirthDate == Value}
            };
        }
    }
}
