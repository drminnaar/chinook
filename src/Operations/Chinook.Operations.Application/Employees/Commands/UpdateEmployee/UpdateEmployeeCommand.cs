using System;
using Chinook.Operations.Application.Employees.Commands.UpdateEmployee.Models;
using MediatR;

namespace Chinook.Operations.Application.Employees.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommand : IRequest
    {
        public UpdateEmployeeCommand(int employeeId, EmployeeForUpdate employeeUpdate)
        {
            if (employeeUpdate is null)
                throw new ArgumentNullException(nameof(employeeUpdate));

            Id = employeeId;
            FirstName = employeeUpdate.FirstName;
            LastName = employeeUpdate.LastName;
            Title = employeeUpdate.Title;
            BirthDate = employeeUpdate.BirthDate;
            HireDate = employeeUpdate.HireDate;
            Address = employeeUpdate.Address;
            City = employeeUpdate.City;
            State = employeeUpdate.State;
            Country = employeeUpdate.Country;
            PostalCode = employeeUpdate.PostalCode;
            Phone = employeeUpdate.Phone;
            Fax = employeeUpdate.Fax;
            Email = employeeUpdate.Email;
            ManagerId = employeeUpdate.ManagerId;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public DateTime BirthDate { get; }
        public DateTime? HireDate { get; }
        public string? Address { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }
        public string? PostalCode { get; }
        public string? Phone { get; }
        public string? Fax { get; }
        public string? Email { get; }
        public int? ManagerId { get; }
    }
}
