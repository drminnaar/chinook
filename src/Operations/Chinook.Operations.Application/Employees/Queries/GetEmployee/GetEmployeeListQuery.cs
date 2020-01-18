using System;
using System.Collections.Generic;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Models;
using MediatR;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee
{
    public sealed class GetEmployeeListQuery : IRequest<IPagedCollection<EmployeeDetail>>
    {
        public GetEmployeeListQuery(EmployeeQuery employeeQuery)
        {
            if (employeeQuery is null)
                throw new ArgumentNullException(nameof(employeeQuery));

            Address = employeeQuery.Address;
            City = employeeQuery.City;
            Country = employeeQuery.Country;
            Email = employeeQuery.Email;
            Fax = employeeQuery.Fax;
            FirstName = employeeQuery.FirstName;
            FromBirthDate = employeeQuery.FromBirthDate == null ? null : new BirthDateFilter(employeeQuery.FromBirthDate);
            FromHireDate = employeeQuery.FromHireDate == null ? null : new HireDateFilter(employeeQuery.FromHireDate);
            LastName = employeeQuery.LastName;
            Order = employeeQuery.Order;
            PageNumber = employeeQuery.PageNumber;
            PageSize = employeeQuery.PageSize;
            Phone = employeeQuery.Phone;
            PostalCode = employeeQuery.PostalCode;
            State = employeeQuery.State;
            Title = employeeQuery.Title;
            ToBirthDate = employeeQuery.ToBirthDate == null ? null : new BirthDateFilter(employeeQuery.ToBirthDate);
            ToHireDate = employeeQuery.ToHireDate == null ? null : new HireDateFilter(employeeQuery.ToHireDate);
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public BirthDateFilter? FromBirthDate { get; set; }
        public BirthDateFilter? ToBirthDate { get; set; }
        public HireDateFilter? FromHireDate { get; set; }
        public HireDateFilter? ToHireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Order { get; set; }
    }
}
