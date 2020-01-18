using System;

namespace Chinook.Operations.Application.Services
{
    public sealed class BirthDateValidationService : IBirthDateValidationService
    {
        public bool IsEighteenYearsOrOlder(DateTime birthDate)
        {
            var ageInDays = DateTime.Now.Subtract(birthDate).Days;
            var eighteenYearsInDays = 365 * 18;
            return ageInDays >= eighteenYearsInDays;
        }
    }
}
