using Microsoft.AspNetCore.Mvc;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Models
{
    public sealed class CustomerQuery : PagedQueryParams
    {
        public CustomerQuery() : base()
        {
        }

        /// <summary>
        /// Customer first name
        /// </summary>
        [FromQuery(Name = "first-name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Customer last name
        /// </summary>
        [FromQuery(Name = "last-name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Customer company
        /// </summary>
        [FromQuery(Name = "company")]
        public string Company { get; set; } = string.Empty;

        /// <summary>
        /// Address line
        /// </summary>
        [FromQuery(Name = "address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Address city
        /// </summary>
        [FromQuery(Name = "city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Address state
        /// </summary>
        [FromQuery(Name = "state")]
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Address country
        /// </summary>
        [FromQuery(Name = "country")]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Address postal code
        /// </summary>
        [FromQuery(Name = "code")]
        public string PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        /// <example>555-555-5555</example>
        [FromQuery(Name = "phone")]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Fax number
        /// </summary>
        /// <example>555-555-5555</example>
        [FromQuery(Name = "fax")]
        public string Fax { get; set; } = string.Empty;

        /// <summary>
        /// Email address
        /// </summary>
        /// <example>john@example.com</example>
        [FromQuery(Name = "email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Order expression
        /// </summary>
        /// <remarks>
        ///
        ///     order=last-name,-city
        ///
        /// </remarks>
        [FromQuery(Name = "order")]
        public string Order { get; set; } = "-customer-id";
    }
}
