namespace PESEL.ValidationResults
{
    public interface IPeselValidationResult
    {
        bool IsValid { get; }

        string Message { get; }
    }
}