namespace PESEL.ValidationResults
{
    public interface IValidationResult
    {
        bool IsValid { get;  }

        string Message { get; }
    }
}