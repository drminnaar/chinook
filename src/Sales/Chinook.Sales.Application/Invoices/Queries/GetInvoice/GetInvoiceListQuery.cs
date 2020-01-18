using System;
using System.Collections.Generic;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models;
using MediatR;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice
{
    public sealed class GetInvoiceListQuery : IRequest<IPagedCollection<InvoiceDetail>>
    {
        public GetInvoiceListQuery(InvoiceQuery invoiceQuery)
        {
            if (invoiceQuery is null)
                throw new ArgumentNullException(nameof(invoiceQuery));

            BillingAddress = invoiceQuery.BillingAddress;
            BillingCity = invoiceQuery.BillingCity;
            BillingCountry = invoiceQuery.BillingCountry;
            BillingPostalCode = invoiceQuery.BillingPostalCode;
            BillingState = invoiceQuery.BillingState;
            Customer = invoiceQuery.Customer;
            CustomerId = invoiceQuery.CustomerId;
            FromDate = invoiceQuery.FromDate == null ? null : new DateFilter(invoiceQuery.FromDate);
            FromTotal = invoiceQuery.FromTotal == null ? null : new TotalFilter(invoiceQuery.FromTotal);
            Order = invoiceQuery.Order;
            PageNumber = invoiceQuery.PageNumber;
            PageSize = invoiceQuery.PageSize;
            ToDate = invoiceQuery.ToDate == null ? null : new DateFilter(invoiceQuery.ToDate);
            ToTotal = invoiceQuery.ToTotal == null ? null : new TotalFilter(invoiceQuery.ToTotal);
        }

        public DateFilter? FromDate { get; }
        public DateFilter? ToDate { get; }
        public string? BillingAddress { get; }
        public string? BillingCity { get; }
        public string? BillingState { get; }
        public string? BillingCountry { get; }
        public string? BillingPostalCode { get; }
        public TotalFilter? FromTotal { get; }
        public TotalFilter? ToTotal { get; }
        public string? Order { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public string? Customer { get; }
        public int? CustomerId { get; }
    }
}
