namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Tests.TestBase;
    using PESEL.Tests.TestData;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("General")]
    public class PeselGeneralValidTests : BasePeselValidatorTest
    {
        [TestMethod]
        [DynamicData(nameof(PeselValidGeneralTestData.Valid),
                     typeof(PeselValidGeneralTestData))]
        public void Should_accept_valid_pesel(string pesel, string _)
        {
            AssertValid(pesel);
        }
    }
}
