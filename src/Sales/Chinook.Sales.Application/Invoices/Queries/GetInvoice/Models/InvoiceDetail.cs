using System;
using System.Runtime.Serialization;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models
{
    [DataContract(Name = "Invoice", Namespace = "http://example.com/chinook")]
    public sealed class InvoiceDetail
    {
        /// <summary>
        /// A unique invoice identifier
        /// </summary>
        /// <example>1122334455</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// The date of invoice
        /// </summary>
        /// <example>2020/01/01</example>
        [DataMember(Order = 2)]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// The invoice total
        /// </summary>
        /// <example>555.55</example>
        [DataMember(Order = 3)]
        public decimal Total { get; set; }

        /// <summary>
        /// The address line
        /// </summary>
        /// <example>1 Example Street</example>
        [DataMember(Order = 4)]
        public string? BillingAddress { get; set; }

        /// <summary>
        /// The address city for billing address
        /// </summary>
        /// <example>Auckland</example>
        [DataMember(Order = 5)]
        public string? BillingCity { get; set; } = string.Empty;

        /// <summary>
        /// The address state for billing address
        /// </summary>
        /// <example>Auckland State</example>
        [DataMember(Order = 6)]
        public string? BillingState { get; set; } = string.Empty;

        /// <summary>
        /// The address country for billing address
        /// </summary>
        /// <example>New Zealand</example>
        [DataMember(Order = 7)]
        public string? BillingCountry { get; set; } = string.Empty;

        /// <summary>
        /// The post code for billing address
        /// </summary>
        /// <example>12345</example>
        [DataMember(Order = 8)]
        public string? BillingPostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Customer detail
        /// </summary>
        [DataMember(Order = 9)]
        public InvoiceCustomer Customer { get; set; } = new InvoiceCustomer();
    }
}
