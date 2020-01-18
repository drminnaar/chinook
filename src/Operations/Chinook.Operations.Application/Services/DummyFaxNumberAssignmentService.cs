using System;
using System.Threading.Tasks;

namespace Chinook.Operations.Application.Services
{
    public sealed class DummyFaxNumberAssignmentService : IFaxNumberAssignmentService
    {
        private readonly RandomNumberGenerator _rng;

        public DummyFaxNumberAssignmentService(RandomNumberGenerator rng)
        {
            _rng = rng ?? throw new ArgumentNullException(nameof(rng));
        }

        public Task<string> AssignFaxNumber(int employeeId)
        {
            return Task.FromResult($"+1 (403) 262-{_rng.GetRandomNumber(8000, 9999)}");
        }
    }
}
