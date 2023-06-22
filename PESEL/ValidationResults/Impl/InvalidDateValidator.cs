namespace PESEL.ValidationResults.Impl
{
    public class InvalidDateValidator : FailPeselValidationResult
    {
        public override string Message => "Niepoprawna data urodzenia";
    }
}