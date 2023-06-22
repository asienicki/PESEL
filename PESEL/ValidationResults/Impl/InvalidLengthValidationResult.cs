namespace PESEL.ValidationResults.Impl
{
    public class InvalidLengthValidationResult : FailPeselValidationResult
    {
        public override string Message => "Niepoprawna długość pesel";
    }
}