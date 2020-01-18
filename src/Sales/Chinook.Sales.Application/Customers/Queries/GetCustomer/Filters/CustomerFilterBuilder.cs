using System;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Filters
{
    public sealed class CustomerFilterBuilder : ICustomerFilterBuilder
    {
        public Expression<Func<Customer, bool>> Filter { get; private set; } = ExpressionBuilder.True<Customer>();

        public ICustomerFilterBuilder WhereAddressEquals(string? address)
        {
            if (!string.IsNullOrWhiteSpace(address))
                Filter = Filter.And(e => e.Address!.ToLower() == address.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereCityEquals(string? city)
        {
            if (!string.IsNullOrWhiteSpace(city))
                Filter = Filter.And(e => e.City!.ToLower() == city.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereCompanyEquals(string? company)
        {
            if (!string.IsNullOrWhiteSpace(company))
                Filter = Filter.And(e => e.Company!.ToLower() == company.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereCountryEquals(string? country)
        {
            if (!string.IsNullOrWhiteSpace(country))
                Filter = Filter.And(e => e.Country!.ToLower() == country.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereEmailEquals(string? email)
        {
            if (!string.IsNullOrWhiteSpace(email))
                Filter = Filter.And(e => e.Email!.ToLower() == email.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereFaxEquals(string? fax)
        {
            if (!string.IsNullOrWhiteSpace(fax))
                Filter = Filter.And(e => e.Fax!.Substring(1)!.Trim()!.ToLower() == fax.Trim().ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereFirstNameEquals(string? firstName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                Filter = Filter.And(e => e.FirstName.ToLower() == firstName.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereLastNameEquals(string? lastName)
        {
            if (!string.IsNullOrWhiteSpace(lastName))
                Filter = Filter.And(e => e.LastName.ToLower() == lastName.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WherePhoneEquals(string? phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
                Filter = Filter.And(e => e.Phone!.Substring(1)!.Trim()!.ToLower() == phone.Trim().ToLower());

            return this;
        }

        public ICustomerFilterBuilder WherePostalCodeEquals(string? postalCode)
        {
            if (!string.IsNullOrWhiteSpace(postalCode))
                Filter = Filter.And(e => e.PostalCode!.ToLower() == postalCode.ToLower());

            return this;
        }

        public ICustomerFilterBuilder WhereStateEquals(string? state)
        {
            if (!string.IsNullOrWhiteSpace(state))
                Filter = Filter.And(e => e.State!.ToLower() == state.ToLower());

            return this;
        }
    }
}
