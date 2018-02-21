namespace PESEL.Validators.Impl
{
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class CompositeValidator : IValidator
    {
        public byte Order => 0;

        private readonly IValidator[] _validators;

        public CompositeValidator(IValidator[] validators)
        {
            _validators = validators;
        }

        public IValidationResult Validate(Entity entity)
        {
            if (entity == null)
            {
                return new ValidationResult();
            }

            foreach (var validator in _validators)
            {
                var result = validator.Validate(entity);

                if (!result.IsValid)
                {
                    return result;
                }
            }

            return new ValidationResult
            {
                IsValid = true
            };
        }
    }
}