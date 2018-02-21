using PESEL.Validators.Impl;

namespace PESEL.Validators.Factories.Impl
{
    public class FactoryValidator : IFactoryValidator
    {
        public CompositeValidator CompositeValidator(params IValidator[] validators)
        {
            return new CompositeValidator(validators);
        }

        public DigitValidator DigitValidator()
        {
            return new DigitValidator();
        }

        public StringIsNullOrEmptyValidator StringIsNullOrEmptyValidator()
        {
            return new StringIsNullOrEmptyValidator();
        }

        public SumControlNumberValidator SumControlNumberValidator()
        {
            return new SumControlNumberValidator();
        }

        public BirthDateValidator BirthDateValidator()
        {
            return new BirthDateValidator();
        }

        public GenderValidator GenderValidator()
        {
            return new GenderValidator();
        }

        public LengthValidator LengthValidator()
        {
            return new LengthValidator();
        }

        public RandomNumbersValidator RandomNumbersValidator()
        {
            return new RandomNumbersValidator();
        }
    }
}