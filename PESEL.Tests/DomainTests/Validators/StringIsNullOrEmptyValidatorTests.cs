using PESEL.ValidationResults.Impl;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("NullOrEmpty")]
    public class StringIsNullOrEmptyValidatorTests
        : BaseValidatorTests<StringIsNullOrEmptyValidator>
    {
        [TestMethod]
        public void Should_fail_for_null()
        {
            var result = Validate(null, out _);

            Assert.IsInstanceOfType(result, typeof(StringIsNullOrEmptyValidationResult));
        }

        [TestMethod]
        public void Should_fail_for_empty_string()
        {
            var result = Validate(string.Empty, out _);

            Assert.IsInstanceOfType(result, typeof(StringIsNullOrEmptyValidationResult));
        }

        [TestMethod]
        public void Should_fail_for_whitespace_only()
        {
            var result = Validate("   ", out _);

            Assert.IsInstanceOfType(result, typeof(StringIsNullOrEmptyValidationResult));
        }

        [TestMethod]
        public void Should_accept_non_empty_string()
        {
            var result = Validate("1", out _);

            Assert.IsTrue(result.IsValid);
        }
    }
}
