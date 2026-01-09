namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class LengthValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            if (entity.Pesel.Length == 11)
            {
                return new OkValidationResult();
            }

            return new InvalidLengthValidationResult();
        }
    }
}