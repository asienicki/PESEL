namespace PESEL.ValidationResults.Impl
{
    public class InvalidDateValidator : FailValidationResult
    {
        public override string Message => "Niepoprawna data urodzenia";
    }
}