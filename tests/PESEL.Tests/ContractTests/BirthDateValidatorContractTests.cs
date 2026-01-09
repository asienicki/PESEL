namespace PESEL.Tests.ContractTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Validators.Impl;

    /// <summary>
    /// BirthDateValidator assumes digit-only input.
    /// This test documents that precondition.
    /// </summary>
    [TestClass]
    [TestCategory("Contract")]
    [TestCategory("Precondition")]
    public class BirthDateValidatorContractTests
    {
        [TestMethod]
        public void Should_throw_when_birth_date_validator_is_used_without_digit_validation()
        {
            var validator = new BirthDateValidator();
            var entity = new PeselEntity("02A70803628");

            Assert.Throws<FormatException>(() =>
            {
                validator.Validate(entity);
            });
        }
    }
}
