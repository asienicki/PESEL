namespace PESEL.Tests.TestBase
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using PESEL.ValidationResults;
    using Validators.Impl;

    public class BasePeselValidatorTest
    {
        protected static void AssertValid(string pesel)
        {
            var result = Validate(pesel);
            Assert.IsTrue(result.IsValid);
        }

        protected static void AssertInvalid(string pesel)
        {
            var result = Validate(pesel);
            Assert.IsFalse(result.IsValid);
        }

        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "S3242:Change return type to concrete type for performance",
            Justification = "Public/contract API – multiple implementations")]
        private static IPeselValidationResult Validate(string pesel)
        {
            var validator = new PeselValidator();
            var entity = new PeselEntity(pesel);

            return validator.Validate(entity);
        }
    }
}
