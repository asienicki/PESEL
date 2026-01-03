using PESEL.ValidationResults.Impl;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Validator")]
    [TestCategory("BirthDate")]
    public class BirthDateValidatorTests : BaseValidatorTests<BirthDateValidator>
    {
        [TestMethod]
        public void Should_parse_birth_date_in_1900s()
        {
            var result = Validate("480118", out var entity);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(new DateTime(1948, 1, 18), entity.PeselStruct.BirthDate);
        }

        [TestMethod]
        public void Should_parse_birth_date_in_2000s()
        {
            var result = Validate("022708", out var entity);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(new DateTime(2002, 7, 8), entity.PeselStruct.BirthDate);
        }

        [TestMethod]
        public void Should_parse_birth_date_in_2100s()
        {
            var result = Validate("044228", out var entity);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(new DateTime(2104, 2, 28), entity.PeselStruct.BirthDate);
        }

        [TestMethod]
        public void Should_parse_birth_date_in_2200s()
        {
            var result = Validate("066228", out var entity);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(new DateTime(2206, 2, 28), entity.PeselStruct.BirthDate);
        }

        [TestMethod]
        public void Should_parse_birth_date_in_1800s()
        {
            var result = Validate("819228", out var entity);

            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(new DateTime(1881, 12, 28), entity.PeselStruct.BirthDate);
        }

        [TestMethod]
        public void Should_fail_for_invalid_month_encoding()
        {
            var result = Validate("024013", out _);

            Assert.IsInstanceOfType(result, typeof(InvalidMonthValidationResult));
        }

        [TestMethod]
        public void Should_fail_for_non_existing_date()
        {
            var result = Validate("022231", out _); // 31.02.2002

            Assert.IsInstanceOfType(result, typeof(InvalidDateValidationResult));
        }
    }
}
