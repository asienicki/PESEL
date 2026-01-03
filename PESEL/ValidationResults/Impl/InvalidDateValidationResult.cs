namespace PESEL.ValidationResults.Impl
{
    /// <summary>
    /// taka data nie istnieje
    /// </summary>
    public class InvalidDateValidationResult : FailPeselValidationResult
    {
        public override string Message => "Niepoprawna data urodzenia";
    }
}