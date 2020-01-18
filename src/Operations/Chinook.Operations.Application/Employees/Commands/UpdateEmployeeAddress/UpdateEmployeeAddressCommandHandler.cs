using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Commands.UpdateEmployeeAddress
{
    public sealed class UpdateEmployeeAddressCommandHandler : IRequestHandler<UpdateEmployeeAddressCommand>
    {
        private readonly IOperationsDbContext _context;

        public UpdateEmployeeAddressCommandHandler(IOperationsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(UpdateEmployeeAddressCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return UpdateEmployeeAddress(request, cancellationToken);
        }

        private async Task<Unit> UpdateEmployeeAddress(UpdateEmployeeAddressCommand address, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(address.EmployeeId);

            if (employee == null)
                throw new EntityNotFoundException($"An employee having id '{address.EmployeeId}' could not be found");

            employee.Address = address.Address;
            employee.City = address.City;
            employee.Country = address.Country;
            employee.PostalCode = address.PostalCode;
            employee.State = address.State;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
