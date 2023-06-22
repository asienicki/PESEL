namespace PESEL.Validators.Impl
{
    using System.Linq;
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class DigitValidator : IValidator
    {
        private readonly char[] _digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public IPeselValidationResult Validate(PeselEntity entity)
        {
            foreach (var charDigit in entity.Pesel)
            {
                if (_digits.Any(x => x.Equals(charDigit)))
                {
                    continue;
                }

                return new CharsNotDigitValidationResult();
            }

            return new OkValidationResult();
        }
    }
}