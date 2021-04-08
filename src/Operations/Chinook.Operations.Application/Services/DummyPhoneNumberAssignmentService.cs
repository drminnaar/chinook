using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public sealed class DummyPhoneNumberAssignmentService : IPhoneNumberAssignmentService
    {
        public Task<string> AssignPhoneNumber(int employeeId) =>
            Task.FromResult($"+1 (403) 262-{RandomNumberGenerator.GetInt32(1000, 7999)}");
    }
}
