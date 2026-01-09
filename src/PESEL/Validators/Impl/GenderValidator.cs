namespace PESEL.Validators.Impl
{
    using System;
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    /// <summary>
    /// Validates and projects gender from PESEL.
    /// 
    /// Preconditions:
    /// - PESEL length >= 10
    /// - PESEL contains digits only
    /// - DigitValidator and LengthValidator executed earlier
    /// </summary>
    public class GenderValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            entity.PeselStruct.GenderNumber
                = Convert.ToByte((int)Char.GetNumericValue(entity.Pesel[9]));

            if (entity.Gender == Gender.None)
            {
                return new OkValidationResult();
            }

            if (entity.Gender == entity.PeselStruct.Gender)
            {
                return new OkValidationResult();
            }

            return new InvalidGenderValidationResult();
        }
    }
}