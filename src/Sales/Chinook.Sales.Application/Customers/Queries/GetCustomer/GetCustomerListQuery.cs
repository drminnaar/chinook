using System;
using System.Collections.Generic;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Models;
using MediatR;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer
{
    public sealed class GetCustomerListQuery : IRequest<IPagedCollection<CustomerDetail>>
    {
        public GetCustomerListQuery(CustomerQuery customerQueryParams)
        {
            if (customerQueryParams is null)
                throw new ArgumentNullException(nameof(customerQueryParams));

            Address = customerQueryParams.Address;
            City = customerQueryParams.City;
            Company = customerQueryParams.Company;
            Country = customerQueryParams.Country;
            Email = customerQueryParams.Email;
            Fax = customerQueryParams.Fax;
            FirstName = customerQueryParams.FirstName;
            LastName = customerQueryParams.LastName;
            Order = customerQueryParams.Order;
            PageNumber = customerQueryParams.PageNumber;
            PageSize = customerQueryParams.PageSize;
            Phone = customerQueryParams.Phone;
            PostalCode = customerQueryParams.PostalCode;
            State = customerQueryParams.State;
        }

        public string? FirstName { get; }
        public string? LastName { get; }
        public string? Company { get; }
        public string? Address { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }
        public string? PostalCode { get; }
        public string? Phone { get; }
        public string? Fax { get; }
        public string? Email { get; }
        public string? Order { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
