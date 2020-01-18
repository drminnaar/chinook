using System;
using System.Runtime.Serialization;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Models
{
    [DataContract(Name = "Employee", Namespace = "http://example.com/chinook")]
    public sealed class EmployeeDetail
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        [DataMember]
        public string LastName { get; set; } = string.Empty;

        [DataMember]
        public string? Title { get; set; }

        [DataMember]
        public EmployeeDetail? Manager { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public DateTime? HireDate { get; set; }

        [DataMember]
        public string? Address { get; set; }

        [DataMember]
        public string? City { get; set; }

        [DataMember]
        public string? State { get; set; }

        [DataMember]
        public string? Country { get; set; }

        [DataMember]
        public string? PostalCode { get; set; }

        [DataMember]
        public string? Phone { get; set; }

        [DataMember]
        public string? Fax { get; set; }

        [DataMember]
        public string? Email { get; set; }
    }
}
