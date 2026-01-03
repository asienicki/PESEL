using PESEL.Models;
using PESEL.Validators.Impl;
using System.ComponentModel.DataAnnotations;

namespace PESEL.System.ComponentModel.DataAnnotations
{
    public class PeselAttribute : ValidationAttribute
    {
        public bool IsValid(string pesel)
        {
            var peselValidator = new PeselValidator();

            var validationResult = peselValidator.Validate(new PeselEntity(pesel));

            return validationResult.IsValid;
        }

        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }
    }
}