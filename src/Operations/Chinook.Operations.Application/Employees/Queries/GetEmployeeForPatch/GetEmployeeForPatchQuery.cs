using Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch.Models;
using MediatR;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch
{
    public sealed class GetEmployeeForPatchQuery : IRequest<EmployeeForPatch?>
    {
        public GetEmployeeForPatchQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
