namespace PESEL.ValidationResults.Impl
{
    public class FailValidationResult : IValidationResult
    {
        public bool IsValid => false;
        public virtual string Message => "FailValidationResult";
    }
}