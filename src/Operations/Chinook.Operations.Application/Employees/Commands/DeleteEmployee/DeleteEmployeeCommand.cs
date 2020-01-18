using MediatR;

namespace Chinook.Operations.Application.Employees.Commands.DeleteEmployee
{
    public sealed class DeleteEmployeeCommand : IRequest
    {
        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
