using PESEL.Models;
using PESEL.ValidationResults.Impl;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("Gender")]
    public class GenderValidatorTests : BaseValidatorTests<GenderValidator>
    {
        [TestMethod]
        public void Should_project_gender_number_from_pesel()
        {
            var result = Validate("74040152795", out var entity); // 9 -> male

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(9, entity.PeselStruct.GenderNumber);
        }

        [TestMethod]
        public void Should_accept_when_gender_is_none()
        {
            var entity = new PeselEntity("74040152795")
            {
                Gender = Gender.None
            };

            var result = new GenderValidator().Validate(entity);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_accept_when_gender_matches_pesel()
        {
            var entity = new PeselEntity("74040152795")
            {
                Gender = Gender.Man
            };

            var result = new GenderValidator().Validate(entity);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_fail_when_gender_does_not_match_pesel()
        {
            var entity = new PeselEntity("74040152795")
            {
                Gender = Gender.Woman
            };

            var result = new GenderValidator().Validate(entity);

            Assert.IsInstanceOfType(result, typeof(InvalidGenderValidationResult));
        }
    }
}
