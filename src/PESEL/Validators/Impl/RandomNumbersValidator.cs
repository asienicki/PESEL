namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    /// <summary>
    /// Projects random digits (positions 7–9) from PESEL.
    /// 
    /// Preconditions:
    /// - PESEL length >= 9
    /// - LengthValidator executed earlier
    /// </summary>
    public class RandomNumbersValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            entity.PeselStruct.RandomNumbers = entity.Pesel.Substring(6, 3).ToCharArray();

            return new OkValidationResult();
        }
    }
}