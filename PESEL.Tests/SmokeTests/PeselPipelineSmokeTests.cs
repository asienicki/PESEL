namespace PESEL.Tests.SmokeTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Validators.Impl;

    [TestClass]
    [TestCategory("Smoke")]
    [TestCategory("Pipeline")]
    public class PeselPipelineSmokeTests
    {
        [TestMethod]
        public void Should_validate_known_correct_pesel_numbers()
        {
            Validate("02070803628");
            Validate("54071304899");
            Validate("48011809618");
        }

        [TestMethod]
        public void Should_fail_for_known_invalid_pesel()
        {
            ValidateInvalid("86155009618"); // invalid PESEL (fails pipeline)
        }

        private static void Validate(string pesel)
        {
            var validator = new PeselValidator();
            var result = validator.Validate(new PeselEntity(pesel));

            Assert.IsTrue(result.IsValid);
        }

        private static void ValidateInvalid(string pesel)
        {
            var validator = new PeselValidator();
            var result = validator.Validate(new PeselEntity(pesel));

            Assert.IsFalse(result.IsValid);
        }
    }
}
