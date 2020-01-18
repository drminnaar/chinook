using System.Runtime.Serialization;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Models
{
    [DataContract(Name = "Customer", Namespace = "http://example.com/chinook")]
    public sealed class AddressForCustomerDto
    {
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
    }
}
