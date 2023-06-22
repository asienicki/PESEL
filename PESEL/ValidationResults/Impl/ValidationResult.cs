using PESEL.Models;

namespace PESEL.ValidationResults.Impl
{
    public class ValidationResult : IPeselValidationResult
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }
        
        public Pesel Pesel { get; set; }
    }
}