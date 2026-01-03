using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("Projection")]
    [TestCategory("RandomNumbers")]
    public class RandomNumbersValidatorTests
    : BaseValidatorTests<RandomNumbersValidator>
    {
        [TestMethod]
        public void Should_project_random_numbers_from_pesel()
        {
            var result = Validate("74040152795", out var entity);

            Assert.IsTrue(result.IsValid);
            CollectionAssert.AreEqual(
                new[] { '5', '2', '7' },
                entity.PeselStruct.RandomNumbers);
        }
    }
}
