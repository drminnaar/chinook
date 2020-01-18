using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public interface IEmailAssignmentService
    {
        Task<string> AssignEmailAsync(int employeeId);
    }
}