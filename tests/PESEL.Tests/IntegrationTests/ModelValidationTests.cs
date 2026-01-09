using PESEL.Tests.IntegrationTests.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PESEL.Tests.IntegrationTests
{
    [TestClass]
    [TestCategory("Integration")]
    [TestCategory("ModelValidation")]
    public class ModelValidationTests
    {
        [TestMethod]
        public void Should_validate_model_with_valid_pesel()
        {
            var model = new ModelWithPeselAttributeOnProperty
            {
                Pesel = "02070803628"
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(
                model,
                context,
                results,
                validateAllProperties: true);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Should_fail_model_validation_for_invalid_pesel()
        {
            var model = new ModelWithPeselAttributeOnProperty
            {
                Pesel = "02070803621" // invalid checksum
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(
                model,
                context,
                results,
                validateAllProperties: true);

            Assert.IsFalse(isValid);
        }
    }
}