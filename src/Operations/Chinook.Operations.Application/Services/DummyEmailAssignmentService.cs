using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Services
{
    public sealed class DummyEmailAssignmentService : IEmailAssignmentService
    {
        private readonly IOperationsDbContext _context;

        public DummyEmailAssignmentService(IOperationsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> AssignEmailAsync(int employeeId)
        {
            try
            {
                var employee = await _context
                .Employees
                .TagWithQueryName(nameof(AssignEmailAsync))
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == employeeId);

                if (employee == null)
                    throw new EntityNotFoundException($"An employee having id '{employeeId}' does not exist");

                var localPart = $"{employee.FirstName}.{employee.LastName}".Trim().ToLower();
                var domainPart = "chinookcorp.com".Trim().ToLower();
                var email = $"{localPart}@{domainPart}";

                var employees = await _context
                    .Employees
                    .TagWithQueryName("GetEmployeesByEmailAddress")
                    .AsNoTracking()
                    .Where(e => e.Email!.ToLower().Trim().StartsWith(localPart, StringComparison.InvariantCultureIgnoreCase))
                    .ToListAsync();

                if (employees.Count > 1)
                    email = $"{localPart}{employees.Count + 1}@{domainPart}";

                return email;
            }
            catch (Exception exception)
            {
                throw new ApplicationServiceException("The email assignment service failed to assign an email address. See inner exception for details.", exception);
            }
        }
    }
}
