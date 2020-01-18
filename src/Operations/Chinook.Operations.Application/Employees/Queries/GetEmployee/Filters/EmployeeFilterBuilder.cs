using System;
using System.Linq.Expressions;
using Chinook.Operations.Domain.Models;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters
{
    public sealed class EmployeeFilterBuilder : IEmployeeFilterBuilder
    {
        public Expression<Func<Employee, bool>> Filter { get; private set; } = ExpressionBuilder.True<Employee>();

        public IEmployeeFilterBuilder WhereFirstNameEquals(string? firstName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                Filter = Filter.And(e => e.FirstName.ToLower() == firstName.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WhereLastNameEquals(string? lastName)
        {
            if (!string.IsNullOrWhiteSpace(lastName))
                Filter = Filter.And(e => e.LastName.ToLower() == lastName.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WhereTitleEquals(string? title)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Filter = Filter.And(e => e.Title!.ToLower() == title.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WhereBirthDate(BirthDateFilter? fromBirthDate, BirthDateFilter? toBirthDate)
        {
            if (fromBirthDate != null)
                Filter = Filter.And(fromBirthDate.Expression());

            if (toBirthDate != null)
                Filter = Filter.And(toBirthDate.Expression());

            return this;
        }

        public IEmployeeFilterBuilder WhereHireDate(HireDateFilter? fromHireDate, HireDateFilter? toHireDate)
        {
            if (fromHireDate != null)
                Filter = Filter.And(fromHireDate.Expression());

            if (toHireDate != null)
                Filter = Filter.And(toHireDate.Expression());

            return this;
        }

        public IEmployeeFilterBuilder WhereAddressEquals(string? address)
        {
            if (!string.IsNullOrWhiteSpace(address))
                Filter = Filter.And(e => e.Address!.ToLower() == address.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WhereCityEquals(string? city)
        {
            if (!string.IsNullOrWhiteSpace(city))
                Filter = Filter.And(e => e.City!.ToLower() == city.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WhereStateEquals(string? state)
        {
            if (!string.IsNullOrWhiteSpace(state))
                Filter = Filter.And(e => e.State!.ToLower() == state.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WhereCountryEquals(string? country)
        {
            if (!string.IsNullOrWhiteSpace(country))
                Filter = Filter.And(e => e.Country!.ToLower() == country.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WherePostalCodeEquals(string? postalCode)
        {
            if (!string.IsNullOrWhiteSpace(postalCode))
                Filter = Filter.And(e => e.PostalCode!.ToLower() == postalCode.Trim().ToLower());

            return this;
        }

        public IEmployeeFilterBuilder WherePhoneEquals(string? phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
                Filter = Filter.And(e => e.Phone!.Substring(1)!.Trim() == phone.Trim());

            return this;
        }

        public IEmployeeFilterBuilder WhereFaxEquals(string? fax)
        {
            if (!string.IsNullOrWhiteSpace(fax))
                Filter = Filter.And(e => e.Fax!.Substring(1)!.Trim() == fax.Trim());

            return this;
        }

        public IEmployeeFilterBuilder WhereEmailEquals(string? email)
        {
            if (!string.IsNullOrWhiteSpace(email))
                Filter = Filter.And(e => e.Email!.ToLower() == email.Trim().ToLower());

            return this;
        }
    }
}
