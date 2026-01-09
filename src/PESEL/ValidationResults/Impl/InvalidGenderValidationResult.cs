namespace PESEL.ValidationResults.Impl
{
    public class InvalidGenderValidationResult : FailPeselValidationResult
    {
        public override string Message => "Płeć inna niż zadeklarowana.";
    }
}