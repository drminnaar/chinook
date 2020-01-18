using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models;
using MediatR;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice
{
    public sealed class GetInvoiceQuery : IRequest<InvoiceDetail?>
    {
        public GetInvoiceQuery(int invoiceId)
        {
            InvoiceId = invoiceId;
        }

        public int InvoiceId { get; }
    }
}
