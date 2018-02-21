namespace PESEL.ValidationResults.Impl
{
    public class CharsNotDigitValidationResult : FailValidationResult
    {
        public override string Message => "Nie wszystkie znaki są cyframi";
    }

    public class InvalidLengthValidationResult : FailValidationResult
    {
        public override string Message => "Niepoprawna długość pesel";
    }
}