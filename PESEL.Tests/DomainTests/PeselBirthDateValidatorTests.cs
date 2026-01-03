namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Tests.TestBase;
    using PESEL.Tests.TestData;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("BirthDate")]
    public class PeselBirthDateValidatorTests : BasePeselValidatorTest
    {
        [TestMethod]
        [DynamicData(nameof(PeselBirthDateTestData.InvalidBirthDates),
                     typeof(PeselBirthDateTestData))]
        public void Should_fail_for_invalid_birth_date(string pesel, string _)
        {
            AssertInvalid(pesel);
        }

        [TestMethod]
        [DynamicData(nameof(PeselBirthDateTestData.ValidBirthDates),
                     typeof(PeselBirthDateTestData))]
        public void Should_accept_valid_birth_date(string pesel, string _)
        {
            AssertValid(pesel);
        }
    }
}
