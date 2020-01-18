using System;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Filters
{
    public interface ICustomerFilterBuilder
    {
        Expression<Func<Customer, bool>> Filter { get; }

        ICustomerFilterBuilder WhereAddressEquals(string? address);
        ICustomerFilterBuilder WhereCityEquals(string? city);
        ICustomerFilterBuilder WhereCompanyEquals(string? company);
        ICustomerFilterBuilder WhereCountryEquals(string? country);
        ICustomerFilterBuilder WhereEmailEquals(string? email);
        ICustomerFilterBuilder WhereFaxEquals(string? fax);
        ICustomerFilterBuilder WhereFirstNameEquals(string? firstName);
        ICustomerFilterBuilder WhereLastNameEquals(string? lastName);
        ICustomerFilterBuilder WherePhoneEquals(string? phone);
        ICustomerFilterBuilder WherePostalCodeEquals(string? postalCode);
        ICustomerFilterBuilder WhereStateEquals(string? state);
    }
}
