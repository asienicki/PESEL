namespace PESEL.ValidationResults.Impl
{
    public class InvalidGenderValidationResult : FailValidationResult
    {
        public override string Message => "Płeć inna niż zadeklarowana.";
    }
}