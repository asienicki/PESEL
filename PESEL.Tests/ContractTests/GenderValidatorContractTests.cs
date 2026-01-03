namespace PESEL.Tests.ContractTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Validators.Impl;

    /// <summary>
    /// GenderValidator assumes PESEL length >= 10 and digit-only input.
    /// This test documents that precondition.
    /// </summary>
    [TestClass]
    [TestCategory("Contract")]
    [TestCategory("Precondition")]
    public class GenderValidatorContractTests
    {
        [TestMethod]
        public void Should_throw_when_gender_validator_is_used_with_too_short_pesel()
        {
            var validator = new GenderValidator();
            var entity = new PeselEntity("123456789"); // length < 10

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                validator.Validate(entity);
            });
        }

        [TestMethod]
        public void Should_throw_when_gender_validator_is_used_without_digit_validation()
        {
            var validator = new GenderValidator();
            var entity = new PeselEntity("123456789A1"); // non-digit at index 9

            Assert.Throws<OverflowException>(() =>
            {
                validator.Validate(entity);
            });
        }
    }
}
