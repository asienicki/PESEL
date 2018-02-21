namespace PESEL.ValidationResults.Impl
{
    public class OkValidationResult : IValidationResult
    {
        public bool IsValid => true;
        
        public string Message => string.Empty;
    }
}