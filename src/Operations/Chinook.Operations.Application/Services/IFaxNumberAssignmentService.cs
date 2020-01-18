using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public interface IFaxNumberAssignmentService
    {
        Task<string> AssignFaxNumber(int employeeId);
    }
}
