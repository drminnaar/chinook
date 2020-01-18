using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public interface IPhoneNumberAssignmentService
    {
        Task<string> AssignPhoneNumber(int employeeId);
    }
}