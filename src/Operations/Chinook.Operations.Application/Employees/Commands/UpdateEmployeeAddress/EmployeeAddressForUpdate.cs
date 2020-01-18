namespace Chinook.Operations.Application.Employees.Commands.UpdateEmployeeAddress
{
    public sealed class EmployeeAddressForUpdate
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }
}
