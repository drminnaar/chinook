using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer
{
    public sealed class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDetail?>
    {
        private readonly ISalesDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ISalesDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<CustomerDetail?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetCustomerById(request.CustomerId);
        }

        private async Task<CustomerDetail?> GetCustomerById(int customerId)
        {
            var customerFromDb = await _context
                .Customers
                .TagWithQueryName(nameof(GetCustomerById))
                .Where(customer => customer.Id == customerId)
                .Include(customer => customer.SupportRepresentative)
                .FirstOrDefaultAsync();

            return customerFromDb == null ? null : _mapper.Map<CustomerDetail>(customerFromDb);
        }
    }
}
