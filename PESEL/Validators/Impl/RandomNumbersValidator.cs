namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class RandomNumbersValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            entity.PeselStruct.RandomNumbers = entity.Pesel.Substring(6, 3).ToCharArray();

            return new OkValidationResult();
        }
    }
}