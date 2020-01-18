using System;
using Chinook.Operations.Application.Services;
using FluentValidation;

namespace Chinook.Operations.Application.Employees.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private readonly IBirthDateValidationService _birthdateValidationService;

        public CreateEmployeeCommandValidator(IBirthDateValidationService birthdateValidationService)
        {
            _birthdateValidationService = birthdateValidationService
                ?? throw new ArgumentNullException(nameof(birthdateValidationService));

            RuleFor(command => command.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(command => command.LastName).MaximumLength(20).NotEmpty();
            RuleFor(command => command.Title).MaximumLength(30).NotEmpty();
            RuleFor(command => command.BirthDate)
                .Must(_birthdateValidationService.IsEighteenYearsOrOlder)
                .WithMessage("An employee must be at least 18 years of age");
        }
    }
}
