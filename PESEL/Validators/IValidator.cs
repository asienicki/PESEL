namespace PESEL.Validators
{
    using Models;
    using ValidationResults;

    public interface IValidator
    {
        IValidationResult Validate(Entity entity);
    }
}