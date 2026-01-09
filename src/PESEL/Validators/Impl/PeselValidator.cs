using PESEL.ValidationResults.Impl;

namespace PESEL.Validators.Impl
{
    using Models;
    using Factories.Impl;

    public class PeselValidator
    {
        public ValidationResult Validate(PeselEntity entity)
        {
            var factory = new FactoryValidator();

            var validators = factory.CompositeValidator(
                factory.StringIsNullOrEmptyValidator(),
                factory.LengthValidator(),
                factory.DigitValidator(),
                factory.RandomNumbersValidator(),
                factory.BirthDateValidator(),
                factory.SumControlNumberValidator(),
                factory.GenderValidator());

            var validationResult = validators.Validate(entity);

            return new ValidationResult
            {
                IsValid = validationResult.IsValid,
                Message = validationResult.Message,
                Pesel = entity.PeselStruct
            };
        }
    }
}