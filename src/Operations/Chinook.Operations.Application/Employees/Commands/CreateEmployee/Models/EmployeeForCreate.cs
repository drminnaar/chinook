using System.ComponentModel.DataAnnotations;

namespace Chinook.Operations.Application.Employees.Commands.CreateEmployee.Models
{
    public sealed class EmployeeForCreate
    {
        [Required(ErrorMessage = "A 'First Name' is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "A 'Last Name' is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "A 'Title' is required")]
        public string Title { get; set; } = string.Empty;

        [RegularExpression(@"^([12]\d{3}-([1-9]|0[1-9]|1[0-2])-([1-9]|0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'BirthDate' must be specified in the format 'yyyy-mm-dd'")]
        public string BirthDate { get; set; } = string.Empty;

        [RegularExpression(@"^([12]\d{3}-([1-9]|0[1-9]|1[0-2])-([1-9]|0[1-9]|[12]\d|3[01]))$", ErrorMessage = "The 'HireDate' must be specified in the format 'yyyy-mm-dd'")]
        public string HireDate { get; set; } = string.Empty;
    }
}
