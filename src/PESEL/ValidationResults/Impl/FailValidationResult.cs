namespace PESEL.ValidationResults.Impl
{
    public class FailPeselValidationResult : IPeselValidationResult
    {
        public bool IsValid => false;
        public virtual string Message => "FailValidationResult";
    }
}