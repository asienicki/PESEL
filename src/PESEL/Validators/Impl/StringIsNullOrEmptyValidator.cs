namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class StringIsNullOrEmptyValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Pesel))
            {
                return new StringIsNullOrEmptyValidationResult();
            }

            return new OkValidationResult();
        }
    }
}