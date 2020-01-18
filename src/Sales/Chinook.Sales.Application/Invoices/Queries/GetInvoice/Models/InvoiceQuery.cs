using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models
{
    public sealed class InvoiceQuery : PagedQueryParams
    {
        public InvoiceQuery() : base()
        {
        }

        /// <summary>
        /// Customer Id
        /// </summary>
        [FromQuery(Name = "customer-id")]
        public int? CustomerId { get; set; }

        /// <summary>
        /// Date of invoice
        /// </summary>
        [FromQuery(Name = "from-date")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'from-date' must be specified in the format 'gte:yyyy-mm-dd'")]
        public string? FromDate { get; set; }

        /// <summary>
        /// To invoice date
        /// </summary>
        [FromQuery(Name = "to-date")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'to-date' must be specified in the format 'gte:yyyy-mm-dd'")]
        public string? ToDate { get; set; }

        /// <summary>
        /// Billing address line
        /// </summary>
        [FromQuery(Name = "address")]
        public string? BillingAddress { get; set; }

        /// <summary>
        /// Billing address city
        /// </summary>
        [FromQuery(Name = "city")]
        public string? BillingCity { get; set; }

        /// <summary>
        /// Billing address state
        /// </summary>
        [FromQuery(Name = "state")]
        public string? BillingState { get; set; }

        /// <summary>
        /// Billing address country
        /// </summary>
        [FromQuery(Name = "country")]
        public string? BillingCountry { get; set; }

        /// <summary>
        /// Billing address postal code
        /// </summary>
        [FromQuery(Name = "code")]
        public string? BillingPostalCode { get; set; }

        /// <summary>
        /// From invoice total
        /// </summary>
        [FromQuery(Name = "from-total")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):[1-9]{1}\d*\.?\d*$", ErrorMessage = "The 'from-total' filter bust be in the form of 'gt:10', 'gte:10', 'eq:10', lt:10, lte:10")]
        public string? FromTotal { get; set; }

        /// <summary>
        /// To invoice total
        /// </summary>
        [FromQuery(Name = "to-total")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):[1-9]{1}\d*\.?\d*$", ErrorMessage = "The 'to-total' filter bust be in the form of 'gt:10', 'gte:10', 'eq:10', lt:10, lte:10")]
        public string? ToTotal { get; set; }

        /// <summary>
        /// Order expression
        /// </summary>
        /// <remarks>
        ///
        ///     order=total,-country
        ///
        /// </remarks>
        [FromQuery(Name = "order")]
        [DataMember(Name = "order")]
        public string? Order { get; set; } = "-date";

        /// <summary>
        /// A customer name represented by first name, or last name, or full name
        /// </summary>
        [FromQuery(Name = "customer")]
        [DataMember(Name = "customer")]
        public string? Customer { get; set; }
    }
}
