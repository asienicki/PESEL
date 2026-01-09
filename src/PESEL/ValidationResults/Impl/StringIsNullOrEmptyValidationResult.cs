namespace PESEL.ValidationResults.Impl
{
    public class StringIsNullOrEmptyValidationResult : FailPeselValidationResult
    {
        public override string Message => "StringIsNullOrEmpty";
    }
}