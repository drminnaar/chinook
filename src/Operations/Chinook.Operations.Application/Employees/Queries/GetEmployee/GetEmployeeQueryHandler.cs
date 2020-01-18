using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee
{
    public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDetail?>
    {
        private readonly IOperationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(
            IOperationsDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<EmployeeDetail?> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetEmployeeById(request.EmployeeId);
        }

        private async Task<EmployeeDetail?> GetEmployeeById(int employeeId)
        {
            var employeeFromDb = await _dbContext
                .Employees
                .TagWithQueryName(nameof(GetEmployeeById))
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(employee => employee.Id == employeeId);

            return _mapper.Map<EmployeeDetail>(employeeFromDb);
        }
    }
}
