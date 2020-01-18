using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Filters
{
    public sealed class PriceFilter : EqualityFilterBase<Track, decimal>
    {
        public PriceFilter(string filterExpression) : base(filterExpression)
        {
        }

        protected override IDictionary<string, Expression<Func<Track, bool>>> CreateEqualityOperatorExpressionLookup()
        {
            return new Dictionary<string, Expression<Func<Track, bool>>>
            {
                { "gt", e => e.UnitPrice > Value},
                { "gte", e => e.UnitPrice >= Value},
                { "lt", e => e.UnitPrice < Value},
                { "lte", e => e.UnitPrice <= Value},
                { "eq", e => e.UnitPrice == Value}
            };
        }
    }
}
