using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models;
using Chinook.Sales.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice
{
    public sealed class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, IPagedCollection<InvoiceDetail>>
    {
        private readonly ISalesDbContext _context;
        private readonly IInvoiceFilterBuilder _filterBuilder;
        private readonly IEntityOrderBuilder<Invoice> _orderBuilder;
        private readonly IMapper _mapper;

        public GetInvoiceListQueryHandler(
            ISalesDbContext context,
            IInvoiceFilterBuilder filterBuilder,
            IEntityOrderBuilder<Invoice> orderBuilder,
            IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _filterBuilder = filterBuilder ?? throw new ArgumentNullException(nameof(filterBuilder));
            _orderBuilder = orderBuilder ?? throw new ArgumentNullException(nameof(orderBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IPagedCollection<InvoiceDetail>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetInvoicesAsync(request);
        }

        private async Task<IPagedCollection<InvoiceDetail>> GetInvoicesAsync(GetInvoiceListQuery query)
        {
            var filter = _filterBuilder
                .WhereBillingAddressLike(query.BillingAddress)
                .WhereBillingCityEquals(query.BillingCity)
                .WhereBillingCountryEquals(query.BillingCountry)
                .WhereBillingPostalCodeEquals(query.BillingPostalCode)
                .WhereBillingStateEquals(query.BillingState)
                .WhereCustomerIdEquals(query.CustomerId)
                .WhereCustomerLike(query.Customer)
                .WhereDate(query.FromDate, query.ToDate)
                .WhereTotal(query.FromTotal, query.ToTotal)
                .Filter;

            var invoicesFromDb = await _context
                .Invoices
                .AsNoTracking()
                .Where(filter)
                .Include(invoice => invoice.Customer.SupportRepresentative)
                .OrderBy(query.Order, _orderBuilder)
                .ToPagedCollectionAsync(query.PageNumber, query.PageSize);

            var invoices = _mapper.Map<IReadOnlyList<InvoiceDetail>>(invoicesFromDb);

            return new PagedCollection<InvoiceDetail>(
                invoices,
                invoicesFromDb.ItemCount,
                invoicesFromDb.CurrentPageNumber,
                invoicesFromDb.PageSize);
        }
    }
}
