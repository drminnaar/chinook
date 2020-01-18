using System;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Operations.Application.Employees.Commands.CreateEmployee.Models;
using Chinook.Operations.Application.Services;
using Chinook.Operations.Domain.Models;
using MediatR;

namespace Chinook.Operations.Application.Employees.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeFromCreate>
    {
        private readonly IOperationsDbContext _context;
        private readonly IEmailAssignmentService _emailAssignmentService;
        private readonly IFaxNumberAssignmentService _faxNumberAssignmentService;
        private readonly IPhoneNumberAssignmentService _phoneNumberAssignmentService;

        public CreateEmployeeCommandHandler(
            IOperationsDbContext context,
            IEmailAssignmentService emailAssignmentService,
            IFaxNumberAssignmentService faxNumberAssignmentService,
            IPhoneNumberAssignmentService phoneNumberAssignmentService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailAssignmentService = emailAssignmentService ?? throw new ArgumentNullException(nameof(emailAssignmentService));
            _faxNumberAssignmentService = faxNumberAssignmentService ?? throw new ArgumentNullException(nameof(faxNumberAssignmentService));
            _phoneNumberAssignmentService = phoneNumberAssignmentService ?? throw new ArgumentNullException(nameof(phoneNumberAssignmentService));
        }

        public Task<EmployeeFromCreate> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return CreateEmployee(request, cancellationToken);
        }

        private async Task<EmployeeFromCreate> CreateEmployee(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                BirthDate = command.BirthDate,
                FirstName = command.FirstName,
                HireDate = command.HireDate,
                LastName = command.LastName,
                Title = command.Title
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            employee.Email = await _emailAssignmentService.AssignEmailAsync(employee.Id);
            employee.Fax = await _faxNumberAssignmentService.AssignFaxNumber(employee.Id);
            employee.Phone = await _phoneNumberAssignmentService.AssignPhoneNumber(employee.Id);
            await _context.SaveChangesAsync(cancellationToken);

            return new EmployeeFromCreate(employee);
        }
    }
}
