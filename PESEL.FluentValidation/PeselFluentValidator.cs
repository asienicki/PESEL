using PESEL.Models;
using PESEL.Validators.Factories.Impl;

namespace FluentValidation.PESEL
{
    public static class PeselFluentValidator
    {
        public static IRuleBuilderOptions<T, TElement> PeselMustBeValid<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, list, context) =>
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

                var validationResult = validators.Validate(new Entity(list as string));

                if (!validationResult.IsValid)
                {
                    context.AddFailure(validationResult.Message);
                }

                return validationResult.IsValid;
            });
        }
    }
}
