using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Operations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Orders
{
    public sealed class EmployeeOrderBuilder : EntityOrderBuilderBase<Employee>
    {
        protected override IDictionary<string, Expression<Func<Employee, object>>> CreateSelectorLookup()
        {
            return new Dictionary<string, Expression<Func<Employee, object>>>
            {
                { "address", e => e.Address! },
                { "birthdate", e => e.BirthDate! },
                { "city", e => e.City! },
                { "code", e => e.PostalCode! },
                { "country", e => e.Country! },
                { "id", e => e.Id! },
                { "email", e => e.Email! },
                { "fax", e => e.Fax! },
                { "first-name", e => e.FirstName! },
                { "hiredate", e => e.HireDate! },
                { "last-name", e => e.LastName! },
                { "phone", e => e.Phone! },
                { "state", e => e.State! },
                { "title", e => e.Title! }
            };
        }
    }
}
