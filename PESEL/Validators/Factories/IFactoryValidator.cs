using PESEL.Validators.Impl;

namespace PESEL.Validators.Factories
{
    public interface IFactoryValidator
    {
        CompositeValidator CompositeValidator(params IValidator[] validators);

        DigitValidator DigitValidator();

        StringIsNullOrEmptyValidator StringIsNullOrEmptyValidator();

        SumControlNumberValidator SumControlNumberValidator();
        
        BirthDateValidator BirthDateValidator();

        GenderValidator GenderValidator();

        LengthValidator LengthValidator();

        RandomNumbersValidator RandomNumbersValidator();
    }
}