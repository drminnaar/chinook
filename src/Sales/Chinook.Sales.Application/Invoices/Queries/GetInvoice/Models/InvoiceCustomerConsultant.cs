using System.Runtime.Serialization;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models
{
    [DataContract(Name = "Consultant", Namespace = "http://example.com/chinook")]
    public sealed class InvoiceCustomerConsultant
    {
        /// <summary>
        /// A unique employee identifier
        /// </summary>
        /// <example>1122334455</example>
        [DataMember]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee last name
        /// </summary>
        /// <example>Doe</example>
        [DataMember]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Employee first name
        /// </summary>
        /// <example>John</example>
        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Employee job title
        /// </summary>
        /// <example>Manager</example>
        [DataMember]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Employee email address
        /// </summary>
        /// <example>john.doe@example.com</example>
        [DataMember]
        public string Email { get; set; } = string.Empty;
    }
}
