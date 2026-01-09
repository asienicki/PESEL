using PESEL.Models;
using PESEL.Validators.Impl;

namespace PESEL.Tests.SmokeTests
{
    [TestClass]
    [TestCategory("Smoke")]
    [TestCategory("Pipeline")]
    public class PeselSmokeTests
    {
        [TestMethod]
        public void Should_validate_known_correct_pesel()
        {
            var validator = new PeselValidator();
            var entity = new PeselEntity("02070803628");

            var result = validator.Validate(entity);

            Assert.IsTrue(result.IsValid);
        }
    }
}