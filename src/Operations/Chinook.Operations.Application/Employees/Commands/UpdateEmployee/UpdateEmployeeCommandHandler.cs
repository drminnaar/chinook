using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IOperationsDbContext _context;

        public UpdateEmployeeCommandHandler(IOperationsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return UpdateEmployee(request, cancellationToken);
        }

        private async Task<Unit> UpdateEmployee(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(command.Id);

            if (employee == null)
                throw new EntityNotFoundException($"An employee having id '{command.Id}' could not be found");

            employee.Address = command.Address;
            employee.BirthDate = command.BirthDate;
            employee.City = command.City;
            employee.Country = command.Country;
            employee.Email = command.Email;
            employee.Fax = command.Fax;
            employee.FirstName = command.FirstName;
            employee.HireDate = command.HireDate;
            employee.LastName = command.LastName;
            employee.Phone = command.Phone;
            employee.PostalCode = command.PostalCode;
            employee.State = command.State;
            employee.Title = command.Title;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
