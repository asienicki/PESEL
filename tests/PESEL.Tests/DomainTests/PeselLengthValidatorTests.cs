namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Tests.TestBase;
    using PESEL.Tests.TestData;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Length")]
    public class PeselLengthValidatorTests : BasePeselValidatorTest
    {
        [TestMethod]
        [DynamicData(nameof(PeselLengthTestData.TooShort),
                     typeof(PeselLengthTestData))]
        public void Should_fail_for_too_short_pesel(string pesel, string _)
        {
            AssertInvalid(pesel);
        }

        [TestMethod]
        [DynamicData(nameof(PeselLengthTestData.TooLong),
                     typeof(PeselLengthTestData))]
        public void Should_fail_for_too_long_pesel(string pesel, string _)
        {
            AssertInvalid(pesel);
        }
    }
}
