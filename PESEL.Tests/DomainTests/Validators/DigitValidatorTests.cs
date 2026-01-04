using PESEL.ValidationResults.Impl;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("Digit")]
    public class DigitValidatorTests : BaseValidatorTests<DigitValidator>
    {
        [TestMethod]
        public void Should_accept_all_digits_only()
        {
            var result = Validate("0123456789", out _);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_accept_short_numeric_input()
        {
            var result = Validate("123", out _);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_accept_empty_string()
        {
            var result = Validate(string.Empty, out _);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_fail_when_contains_letter()
        {
            var result = Validate("12A45", out _);

            Assert.IsInstanceOfType<CharsNotDigitValidationResult>(result);
        }

        [TestMethod]
        public void Should_fail_when_contains_special_character()
        {
            var result = Validate("12#45", out _);

            Assert.IsInstanceOfType<CharsNotDigitValidationResult>(result);
        }

        [TestMethod]
        public void Should_fail_when_contains_whitespace()
        {
            var result = Validate("12 45", out _);

            Assert.IsInstanceOfType< CharsNotDigitValidationResult>(result);
        }
    }
}
