namespace PESEL.Validators
{
    using Models;
    using ValidationResults;

    public interface IValidator
    {
        IPeselValidationResult Validate(PeselEntity entity);
    }
}