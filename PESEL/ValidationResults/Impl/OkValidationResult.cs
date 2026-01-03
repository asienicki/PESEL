namespace PESEL.ValidationResults.Impl
{
    public class OkValidationResult : IPeselValidationResult
    {
        public bool IsValid => true;

        public string Message => string.Empty;
    }
}