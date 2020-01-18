using System.Runtime.Serialization;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Models
{
    [DataContract(Name = "Customer", Namespace = "http://example.com/chinook")]
    public sealed class ContactForCustomerDto
    {
        /// <summary>
        /// Phone number
        /// </summary>
        /// <example>555-555-5555</example>
        [DataMember]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Fax number
        /// </summary>
        /// <example>555-555-5555</example>
        [DataMember]
        public string Fax { get; set; } = string.Empty;

        /// <summary>
        /// Email address
        /// </summary>
        /// <example>john@example.com</example>
        [DataMember]
        public string Email { get; set; } = string.Empty;
    }
}
