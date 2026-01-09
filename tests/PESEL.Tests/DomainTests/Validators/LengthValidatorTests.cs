using PESEL.ValidationResults.Impl;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("Length")]
    public class LengthValidatorTests : BaseValidatorTests<LengthValidator>
    {
        [TestMethod]
        public void Should_accept_pesel_with_exact_length_11()
        {
            var result = Validate("12345678901", out _);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_fail_for_too_short_pesel()
        {
            var result = Validate("1234567890", out _); // 10

            Assert.IsInstanceOfType<InvalidLengthValidationResult>(result);
        }

        [TestMethod]
        public void Should_fail_for_too_long_pesel()
        {
            var result = Validate("123456789012", out _); // 12

            Assert.IsInstanceOfType<InvalidLengthValidationResult>(result);
        }

        [TestMethod]
        public void Should_fail_for_empty_string()
        {
            var result = Validate(string.Empty, out _);

            Assert.IsInstanceOfType<InvalidLengthValidationResult>(result);
        }
    }
}
