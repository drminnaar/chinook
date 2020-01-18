using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Filters;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Models;
using Chinook.Sales.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer
{
    public sealed class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, IPagedCollection<CustomerDetail>>
    {
        private readonly ISalesDbContext _context;
        private readonly ICustomerFilterBuilder _filterBuilder;
        private readonly IEntityOrderBuilder<Customer> _orderBuilder;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(
            ISalesDbContext context,
            ICustomerFilterBuilder filterBuilder,
            IEntityOrderBuilder<Customer> orderBuilder,
            IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _filterBuilder = filterBuilder ?? throw new ArgumentNullException(nameof(filterBuilder));
            _orderBuilder = orderBuilder ?? throw new ArgumentNullException(nameof(orderBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IPagedCollection<CustomerDetail>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetCustomerList(request);
        }

        private async Task<IPagedCollection<CustomerDetail>> GetCustomerList(GetCustomerListQuery request)
        {
            var expression = _filterBuilder
                .WhereAddressEquals(request.Address)
                .WhereCityEquals(request.City)
                .WhereCompanyEquals(request.Company)
                .WhereCountryEquals(request.Country)
                .WhereEmailEquals(request.Email)
                .WhereFaxEquals(request.Fax)
                .WhereFirstNameEquals(request.FirstName)
                .WhereLastNameEquals(request.LastName)
                .WherePhoneEquals(request.Phone)
                .WherePostalCodeEquals(request.PostalCode)
                .WhereStateEquals(request.State)
                .Filter;

            var customersFromDb = await _context
                .Customers
                .TagWithQueryName(nameof(GetCustomerList))
                .Where(expression)
                .Include(e => e.SupportRepresentative)
                .OrderBy(request.Order, _orderBuilder)
                .ToPagedCollectionAsync(request.PageNumber, request.PageSize);

            var customers = _mapper.Map<IReadOnlyList<CustomerDetail>>(customersFromDb);

            return new PagedCollection<CustomerDetail>(
                customers,
                customersFromDb.ItemCount,
                customersFromDb.CurrentPageNumber,
                customersFromDb.PageSize);
        }
    }
}
