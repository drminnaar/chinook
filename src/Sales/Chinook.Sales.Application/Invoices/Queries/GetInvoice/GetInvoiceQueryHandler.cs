using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice
{
    public sealed class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, InvoiceDetail?>
    {
        private readonly ISalesDbContext _context;
        private readonly IMapper _mapper;

        public GetInvoiceQueryHandler(ISalesDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<InvoiceDetail?> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetInvoiceDetailAsync(request.InvoiceId);
        }

        private async Task<InvoiceDetail?> GetInvoiceDetailAsync(int invoiceId)
        {
            var invoiceFromDb = await _context
                .Invoices
                .Where(invoice => invoice.Id == invoiceId)
                .Include(invoice => invoice.Customer.SupportRepresentative)
                .FirstOrDefaultAsync();

            return invoiceFromDb == null ? null : _mapper.Map<InvoiceDetail>(invoiceFromDb);
        }
    }
}
