using System;
using Chinook.Operations.Domain.Models;

namespace Chinook.Operations.Application.Employees.Commands.CreateEmployee.Models
{
    public sealed class EmployeeFromCreate
    {
        public EmployeeFromCreate(
            int id,
            string firstName,
            string lastName,
            string title,
            DateTime birthDate,
            DateTime hireDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            BirthDate = birthDate;
            HireDate = hireDate;
        }

        public EmployeeFromCreate(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Title = employee.Title ?? throw new ArgumentException("Expected employee title to have a value");
            BirthDate = employee.BirthDate ?? throw new ArgumentException("Expected employee birthdate to have a value");
            HireDate = employee.HireDate ?? throw new ArgumentException("Expected employee hiredate to have a value");
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public DateTime BirthDate { get; }
        public DateTime HireDate { get; }
    }
}
