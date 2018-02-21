using System.ComponentModel.DataAnnotations;
using PESEL.Models;
using PESEL.Validators.Impl;

namespace PESEL.Attributes
{
    class PeselAttribute : ValidationAttribute
    {
        public bool IsValid(string pesel)
        {
            var peselValidator = new PeselValidator();

            var validationResult = peselValidator.Validate(new Entity(pesel));

            return validationResult.IsValid;
        }
        
        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }
    }
}
