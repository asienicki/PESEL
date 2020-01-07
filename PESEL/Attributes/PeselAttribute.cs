namespace PESEL.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using Models;
    using Validators.Impl;

    public class PeselAttribute : ValidationAttribute
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