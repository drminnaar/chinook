using System;
using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public sealed class DummyPhoneNumberAssignmentService : IPhoneNumberAssignmentService
    {
        private readonly RandomNumberGenerator _rng;

        public DummyPhoneNumberAssignmentService(RandomNumberGenerator rng)
        {
            _rng = rng ?? throw new ArgumentNullException(nameof(rng));
        }

        public Task<string> AssignPhoneNumber(int employeeId)
        {
            return Task.FromResult($"+1 (403) 262-{_rng.GetRandomNumber(1000, 7999)}");
        }
    }
}
