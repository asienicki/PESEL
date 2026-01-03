namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class DigitValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            foreach (var charDigit in entity.Pesel)
            {
                if (char.IsDigit(charDigit))
                {
                    continue;
                }

                return new CharsNotDigitValidationResult();
            }

            return new OkValidationResult();
        }
    }
}