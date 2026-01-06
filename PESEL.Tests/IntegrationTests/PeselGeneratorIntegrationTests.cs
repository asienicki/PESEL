namespace PESEL.Tests.IntegrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Validators.Impl;

    [TestClass]
    [TestCategory("Integration")]
    [TestCategory("Generator")]
    public class PeselGeneratorIntegrationTests
    {
        [TestMethod]
        public void Should_validate_pesels_generated_for_given_birth_date()
        {
            var validator = new PeselValidator();

            var pesels = PeselGenerator.Generate(new DateTime(2000, 01, 01));

            foreach (var pesel in pesels)
            {
                var result = validator.Validate(new PeselEntity(pesel));
                Assert.IsTrue(result.IsValid);
            }
        }
    }
}
