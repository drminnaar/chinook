using System.Runtime.Serialization;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Models
{
    [DataContract(Name = "Customer", Namespace = "http://example.com/chinook")]
    public sealed class CustomerDetail
    {
        /// <summary>
        /// A unique customer identifier
        /// </summary>
        /// <example>1122334455</example>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Customer first name
        /// </summary>
        /// <example>John</example>
        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Customer last name
        /// </summary>
        /// <example>Doe</example>
        [DataMember]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Customer company
        /// </summary>
        /// <example>Acme Co</example>
        [DataMember]
        public string Company { get; set; } = string.Empty;

        /// <summary>
        /// Address line
        /// </summary>
        /// <example>1 Example Street</example>
        [DataMember]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Address city
        /// </summary>
        /// <example>Example City</example>
        [DataMember]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Address state
        /// </summary>
        /// <example>Example State</example>
        [DataMember]
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Address country
        /// </summary>
        /// <example>Example Country</example>
        [DataMember]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Address postal code
        /// </summary>
        /// <example>1234</example>
        [DataMember]
        public string PostalCode { get; set; } = string.Empty;

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

        /// <summary>
        /// Support representative
        /// </summary>
        [DataMember]
        public CustomerConsultant? Consultant { get; set; }
    }
}
