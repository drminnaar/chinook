using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch
{
    public sealed class GetEmployeeForPatchQueryHandler : IRequestHandler<GetEmployeeForPatchQuery, EmployeeForPatch?>
    {
        private readonly IOperationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeForPatchQueryHandler(
            IOperationsDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<EmployeeForPatch?> Handle(GetEmployeeForPatchQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetEmployeeForPatch(request.EmployeeId);
        }

        private async Task<EmployeeForPatch?> GetEmployeeForPatch(int employeeId)
        {
            var employeeFromDb = await _dbContext
                .Employees
                .TagWithQueryName(nameof(GetEmployeeForPatch))
                .AsNoTracking()
                .FirstOrDefaultAsync(employee => employee.Id == employeeId);

            return _mapper.Map<EmployeeForPatch>(employeeFromDb);
        }
    }
}
