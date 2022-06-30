using System.ComponentModel.DataAnnotations;

namespace Domain.Validators;

public class PersonalCodeValidator : ValidationAttribute
{
    const int _expectedLenght = 11;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var personalCode = value!.ToString();
        if (personalCode!.Length != _expectedLenght)
            return new ValidationResult("Expected lenght of personal code is 11!");
        if (!ulong.TryParse(personalCode, out var _))
            return new ValidationResult("Personal code is not in correct format!");
        return null;
    }
}