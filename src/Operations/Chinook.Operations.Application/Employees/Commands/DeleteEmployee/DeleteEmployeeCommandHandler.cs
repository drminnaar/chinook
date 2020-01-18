using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Commands.DeleteEmployee
{
    public sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IOperationsDbContext _context;

        public DeleteEmployeeCommandHandler(IOperationsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return DeleteEmployee(request.EmployeeId);
        }

        private async Task<Unit> DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee == null)
                throw new EntityNotFoundException($"An employee having id '{employeeId}' could not be found");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
