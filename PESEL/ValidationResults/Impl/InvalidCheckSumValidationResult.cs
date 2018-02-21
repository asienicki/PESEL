namespace PESEL.ValidationResults.Impl
{
    public class InvalidCheckSumValidationResult : FailValidationResult
    {
        public override string Message => "Niepoprawna suma kontrolna";
    }
}