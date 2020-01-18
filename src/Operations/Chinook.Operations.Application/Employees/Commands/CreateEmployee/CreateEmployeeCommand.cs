using System;
using System.Globalization;
using Chinook.Operations.Application.Employees.Commands.CreateEmployee.Models;
using MediatR;

namespace Chinook.Operations.Application.Employees.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommand : IRequest<EmployeeFromCreate>
    {
        public CreateEmployeeCommand(EmployeeForCreate employeeForCreate)
        {
            if (employeeForCreate is null)
                throw new ArgumentNullException(nameof(employeeForCreate));

            FirstName = employeeForCreate.FirstName;
            LastName = employeeForCreate.LastName;
            Title = employeeForCreate.Title;
            BirthDate = DateTime.Parse(employeeForCreate.BirthDate, CultureInfo.CurrentCulture);
            HireDate = DateTime.Parse(employeeForCreate.HireDate, CultureInfo.CurrentCulture);
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public DateTime BirthDate { get; }
        public DateTime HireDate { get; }
    }
}
