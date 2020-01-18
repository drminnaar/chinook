using System;
using Chinook.Operations.Application.Services;
using FluentValidation;

namespace Chinook.Operations.Application.Employees.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        private readonly IBirthDateValidationService _birthdateValidationService;

        public UpdateEmployeeCommandValidator(IBirthDateValidationService birthdateValidationService)
        {
            _birthdateValidationService = birthdateValidationService
                ?? throw new ArgumentNullException(nameof(birthdateValidationService));

            RuleFor(command => command.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(command => command.LastName).MaximumLength(20).NotEmpty();
            RuleFor(command => command.Title).MaximumLength(30).NotEmpty();

            // validate address details
            RuleFor(command => command.Address).MaximumLength(70);
            RuleFor(command => command.City).MaximumLength(40);
            RuleFor(command => command.Country).MaximumLength(40);
            RuleFor(command => command.State).MaximumLength(40);
            RuleFor(command => command.PostalCode).MaximumLength(10);

            // validate contact details
            RuleFor(command => command.Email).MaximumLength(60);
            RuleFor(command => command.Fax).MaximumLength(24);
            RuleFor(command => command.Phone).MaximumLength(24);

            RuleFor(command => command.BirthDate)
                .Must(_birthdateValidationService.IsEighteenYearsOrOlder)
                .WithMessage("An employee must be at least 18 years of age");
        }
    }
}
