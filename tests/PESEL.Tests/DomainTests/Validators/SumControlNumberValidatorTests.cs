using PESEL.ValidationResults.Impl;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("Checksum")]
    public class SumControlNumberValidatorTests
        : BaseValidatorTests<SumControlNumberValidator>
    {
        [TestMethod]
        public void Should_accept_pesel_with_valid_checksum_and_project_control_number()
        {
            // known valid PESEL
            var result = Validate("74040152795", out var entity);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(5, entity.PeselStruct.ControlNumber);
        }

        [TestMethod]
        public void Should_fail_for_invalid_checksum()
        {
            // same digits, wrong checksum (last digit changed)
            var result = Validate("74040152794", out _);

            Assert.IsInstanceOfType<InvalidCheckSumValidationResult>(result);
        }

        [TestMethod]
        public void Should_fail_when_checksum_digit_does_not_match_calculated_value()
        {
            var result = Validate("02070803621", out _); // invalid checksum

            Assert.IsInstanceOfType<InvalidCheckSumValidationResult>(result);
        }
    }
}
