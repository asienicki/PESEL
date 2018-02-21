namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class RandomNumbersValidator : IValidator
    {
        public IValidationResult Validate(Entity entity)
        {
            entity.PeselStruct.RandomNumbers = entity.Pesel.Substring(6, 3).ToCharArray();

            return new OkValidationResult();
        }
    }
}