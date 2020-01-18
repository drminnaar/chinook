using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Filters;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Models;
using Chinook.Operations.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee
{
    public sealed class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, IPagedCollection<EmployeeDetail>>
    {
        private readonly IOperationsDbContext _dbContext;
        private readonly IEmployeeFilterBuilder _filterBuilder;
        private readonly IEntityOrderBuilder<Employee> _orderBuilder;
        private readonly IMapper _mapper;

        public GetEmployeeListQueryHandler(
            IOperationsDbContext dbContext,
            IEmployeeFilterBuilder filterBuilder,
            IEntityOrderBuilder<Employee> orderBuilder,
            IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _filterBuilder = filterBuilder ?? throw new ArgumentNullException(nameof(filterBuilder));
            _orderBuilder = orderBuilder ?? throw new ArgumentNullException(nameof(orderBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IPagedCollection<EmployeeDetail>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetEmployeeList(request);
        }

        private async Task<IPagedCollection<EmployeeDetail>> GetEmployeeList(GetEmployeeListQuery query)
        {
            var filter = _filterBuilder
                .WhereAddressEquals(query.Address)
                .WhereBirthDate(query.FromBirthDate, query.ToBirthDate)
                .WhereCityEquals(query.City)
                .WhereCountryEquals(query.Country)
                .WhereEmailEquals(query.Email)
                .WhereFaxEquals(query.Fax)
                .WhereFirstNameEquals(query.FirstName)
                .WhereHireDate(query.FromHireDate, query.ToHireDate)
                .WhereLastNameEquals(query.LastName)
                .WherePhoneEquals(query.Phone)
                .WherePostalCodeEquals(query.PostalCode)
                .WhereStateEquals(query.State)
                .WhereTitleEquals(query.Title)
                .Filter;

            var employeesFromDb = await _dbContext
                .Employees
                .TagWithQueryName(nameof(GetEmployeeList))
                .Where(filter)
                .Include(employee => employee.Manager)
                .OrderBy(query.Order, _orderBuilder)
                .ToPagedCollectionAsync<Employee>(query.PageNumber, query.PageSize);

            var employees = _mapper.Map<IReadOnlyList<EmployeeDetail>>(employeesFromDb);

            return new PagedCollection<EmployeeDetail>(
                employees,
                employeesFromDb.ItemCount,
                employeesFromDb.CurrentPageNumber,
                employeesFromDb.PageSize);
        }
    }
}
