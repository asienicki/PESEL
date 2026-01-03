namespace PESEL.ValidationResults.Impl
{
    public class NullEntityValidationResult : FailPeselValidationResult
    {
        public override string Message => "Entity cannot be null";
    }
}