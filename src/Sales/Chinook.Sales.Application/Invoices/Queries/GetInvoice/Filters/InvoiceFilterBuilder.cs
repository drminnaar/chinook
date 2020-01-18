using System;
using System.Linq.Expressions;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Filters
{
    public sealed class InvoiceFilterBuilder : IInvoiceFilterBuilder
    {
        public Expression<Func<Invoice, bool>> Filter { get; private set; } = ExpressionBuilder.True<Invoice>();

        public IInvoiceFilterBuilder WhereCustomerIdEquals(int? customerId)
        {
            if (customerId.HasValue && customerId > 0)
                Filter = Filter.And(e => e.CustomerId == customerId);

            return this;
        }

        public IInvoiceFilterBuilder WhereCustomerLike(string? customer)
        {
            if (!string.IsNullOrWhiteSpace(customer))
            {
                Filter = Filter.And(e => EF.Functions.ILike(e.Customer.FirstName, $"%{customer}%")
                    || EF.Functions.ILike(e.Customer.LastName, $"%{customer}%"));
            }

            return this;
        }

        public IInvoiceFilterBuilder WhereDate(DateFilter? fromDate, DateFilter? toDate)
        {
            if (fromDate != null)
                Filter = Filter.And(fromDate.Expression());

            if (toDate != null)
                Filter = Filter.And(toDate.Expression());

            return this;
        }

        public IInvoiceFilterBuilder WhereBillingAddressLike(string? billingAddress)
        {
            if (!string.IsNullOrWhiteSpace(billingAddress))
                Filter = Filter.And(e => EF.Functions.ILike(e.BillingAddress, $"%{billingAddress}%"));

            return this;
        }

        public IInvoiceFilterBuilder WhereBillingCityEquals(string? billingCity)
        {
            if (!string.IsNullOrWhiteSpace(billingCity))
                Filter = Filter.And(e => e.BillingCity != null && e.BillingCity.ToLower() == billingCity.Trim().ToLower());

            return this;
        }

        public IInvoiceFilterBuilder WhereBillingCountryEquals(string? billingCountry)
        {
            if (!string.IsNullOrWhiteSpace(billingCountry))
                Filter = Filter.And(e => e.BillingCountry != null && e.BillingCountry.ToLower() == billingCountry.Trim().ToLower());

            return this;
        }

        public IInvoiceFilterBuilder WhereBillingPostalCodeEquals(string? postalCode)
        {
            if (!string.IsNullOrWhiteSpace(postalCode))
                Filter = Filter.And(e => e.BillingPostalCode != null && e.BillingPostalCode == postalCode.Trim().ToLower());

            return this;
        }

        public IInvoiceFilterBuilder WhereBillingStateEquals(string? billingState)
        {
            if (!string.IsNullOrWhiteSpace(billingState))
                Filter = Filter.And(e => e.BillingState != null && e.BillingState.ToLower() == billingState.Trim().ToLower());

            return this;
        }

        public IInvoiceFilterBuilder WhereTotal(TotalFilter? fromTotal, TotalFilter? toTotal)
        {
            if (fromTotal != null)
                Filter = Filter.And(fromTotal.Expression());

            if (toTotal != null)
                Filter = Filter.And(toTotal.Expression());

            return this;
        }
    }
}
