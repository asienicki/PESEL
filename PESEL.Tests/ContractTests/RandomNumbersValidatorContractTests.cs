namespace PESEL.Tests.ContractTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Validators.Impl;

    /// <summary>
    /// RandomNumbersValidator assumes PESEL length >= 9.
    /// This test documents that precondition.
    /// </summary>
    [TestClass]
    [TestCategory("Contract")]
    [TestCategory("Precondition")]
    public class RandomNumbersValidatorContractTests
    {
        [TestMethod]
        public void Should_throw_when_random_numbers_validator_is_used_with_too_short_pesel()
        {
            var validator = new RandomNumbersValidator();
            var entity = new PeselEntity("1234567"); // length < 9

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                validator.Validate(entity);
            });
        }
    }
}
