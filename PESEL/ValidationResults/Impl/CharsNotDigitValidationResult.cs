namespace PESEL.ValidationResults.Impl
{
    public class CharsNotDigitValidationResult : FailPeselValidationResult
    {
        public override string Message => "Nie wszystkie znaki są cyframi";
    }
}