using System;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters
{
    public interface IInvoiceFilterBuilder
    {
        Expression<Func<Invoice, bool>> Filter { get; }

        IInvoiceFilterBuilder WhereBillingAddressLike(string? billingAddress);
        IInvoiceFilterBuilder WhereBillingCityEquals(string? billingCity);
        IInvoiceFilterBuilder WhereBillingCountryEquals(string? billingCountry);
        IInvoiceFilterBuilder WhereBillingPostalCodeEquals(string? postalCode);
        IInvoiceFilterBuilder WhereBillingStateEquals(string? billingState);
        IInvoiceFilterBuilder WhereCustomerLike(string? customer);
        IInvoiceFilterBuilder WhereCustomerIdEquals(int? customerId);
        IInvoiceFilterBuilder WhereDate(DateFilter? fromDate, DateFilter? toDate);
        IInvoiceFilterBuilder WhereTotal(TotalFilter? fromTotal, TotalFilter? toTotal);
    }
}
