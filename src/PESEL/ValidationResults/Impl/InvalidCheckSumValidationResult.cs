namespace PESEL.ValidationResults.Impl
{
    public class InvalidCheckSumValidationResult : FailPeselValidationResult
    {
        public override string Message => "Niepoprawna suma kontrolna";
    }
}