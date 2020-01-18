using System;
using System.Linq.Expressions;
using Chinook.Operations.Domain.Models;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters
{
    public interface IEmployeeFilterBuilder
    {
        Expression<Func<Employee, bool>> Filter { get; }

        IEmployeeFilterBuilder WhereAddressEquals(string? address);
        IEmployeeFilterBuilder WhereBirthDate(BirthDateFilter? fromBirthDate, BirthDateFilter? toBirthDate);
        IEmployeeFilterBuilder WhereCityEquals(string? city);
        IEmployeeFilterBuilder WhereCountryEquals(string? country);
        IEmployeeFilterBuilder WhereEmailEquals(string? email);
        IEmployeeFilterBuilder WhereFaxEquals(string? fax);
        IEmployeeFilterBuilder WhereFirstNameEquals(string? firstName);
        IEmployeeFilterBuilder WhereHireDate(HireDateFilter? fromHireDate, HireDateFilter? toHireDate);
        IEmployeeFilterBuilder WhereLastNameEquals(string? lastName);
        IEmployeeFilterBuilder WherePhoneEquals(string? phone);
        IEmployeeFilterBuilder WherePostalCodeEquals(string? postalCode);
        IEmployeeFilterBuilder WhereStateEquals(string? state);
        IEmployeeFilterBuilder WhereTitleEquals(string? title);
    }
}
