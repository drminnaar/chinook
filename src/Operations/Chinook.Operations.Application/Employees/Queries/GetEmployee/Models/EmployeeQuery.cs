using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Models
{
    public sealed class EmployeeQuery : PagedQueryParams
    {
        private const string DEFAULT_ORDER = "last-name, first-name"; // order by last name ascending, then by first name ascending

        public EmployeeQuery() : base()
        {
        }

        [FromQuery(Name = "first-name")]
        public string? FirstName { get; set; }

        [FromQuery(Name = "last-name")]
        public string? LastName { get; set; }

        [FromQuery(Name = "title")]
        public string? Title { get; set; }

        [FromQuery(Name = "from-birthdate")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'from-birthdate' must be specified in the format 'gte:yyyy-mm-dd'")]
        public string? FromBirthDate { get; set; }

        [FromQuery(Name = "to-birthdate")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'to-birthdate' must be specified in the format 'gte:yyyy-mm-dd'")]
        public string? ToBirthDate { get; set; }

        [FromQuery(Name = "from-hiredate")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'from-hiredate' must be specified in the format 'gte:yyyy-mm-dd'")]
        public string? FromHireDate { get; set; }

        [FromQuery(Name = "to-hiredate")]
        [RegularExpression(@"^(gt|gte|lt|lte|eq):([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'to-hiredate' must be specified in the format 'gte:yyyy-mm-dd'")]
        public string? ToHireDate { get; set; }

        [FromQuery(Name = "address")]
        public string? Address { get; set; }

        [FromQuery(Name = "city")]
        public string? City { get; set; }

        [FromQuery(Name = "state")]
        public string? State { get; set; }

        [FromQuery(Name = "country")]
        public string? Country { get; set; }

        [FromQuery(Name = "code")]
        public string? PostalCode { get; set; }

        [FromQuery(Name = "phone")]
        public string? Phone { get; set; }

        [FromQuery(Name = "fax")]
        public string? Fax { get; set; }

        [FromQuery(Name = "email")]
        public string? Email { get; set; }

        [FromQuery(Name = "order")]
        [RegularExpression(@"^((-)?[a-zA-Z][a-zA-Z]*)(-[a-zA-Z]+)*((,|,\s|\s,|\s,\s)?((-)?[a-zA-Z][a-zA-Z]*)(-[a-zA-Z]+)*)$", ErrorMessage = "The specified order is invalid. The default sort order is ascending. Use a '-' at the start of expression to order descending. The sort value may use 'kebab case' AKA 'hyphen case'. Some examples of valid order expressions are 'address', '-address', 'last-name', '-last-name'")]
        public string? Order { get; set; } = DEFAULT_ORDER;
    }
}
