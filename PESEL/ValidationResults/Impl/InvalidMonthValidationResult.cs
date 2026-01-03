namespace PESEL.ValidationResults.Impl
{
    /// <summary>
    /// miesiąc poza zakresem
    /// </summary>
    public class InvalidMonthValidationResult : FailPeselValidationResult
    {
        public override string Message => "Niepoprawny miesiąc";
    }
}