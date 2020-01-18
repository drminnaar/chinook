using System;
using MediatR;

namespace Chinook.Operations.Application.Employees.Commands.UpdateEmployeeAddress
{
    public sealed class UpdateEmployeeAddressCommand : IRequest
    {
        public UpdateEmployeeAddressCommand(int employeeId, EmployeeAddressForUpdate address)
        {
            if (address is null)
                throw new ArgumentNullException(nameof(address));

            EmployeeId = employeeId;
            Address = address.Address;
            City = address.City;
            State = address.State;
            Country = address.Country;
            PostalCode = address.PostalCode;
        }

        public int EmployeeId { get; }
        public string? Address { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }
        public string? PostalCode { get; }
    }
}
