using Chinook.Operations.Application.Employees.Queries.GetEmployee.Models;
using MediatR;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee
{
    public sealed class GetEmployeeQuery : IRequest<EmployeeDetail?>
    {
        public GetEmployeeQuery()
        {
        }

        public GetEmployeeQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
