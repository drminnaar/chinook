using System;

namespace Chinook.Operations.Application.Services
{
    public interface IBirthDateValidationService
    {
        bool IsEighteenYearsOrOlder(DateTime birthDate);
    }
}