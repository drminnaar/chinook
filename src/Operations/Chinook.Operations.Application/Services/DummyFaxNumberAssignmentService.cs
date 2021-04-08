using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public sealed class DummyFaxNumberAssignmentService : IFaxNumberAssignmentService
    {
        public Task<string> AssignFaxNumber(int employeeId)
        {
            return Task.FromResult($"+1 (403) 262-{RandomNumberGenerator.GetInt32(8000, 9999)}");
        }
    }
}
