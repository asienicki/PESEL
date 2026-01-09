namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Tests.TestBase;
    using PESEL.Tests.TestData;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Empty")]
    public class PeselEmptyValidatorTests : BasePeselValidatorTest
    {
        [TestMethod]
        [DynamicData(nameof(PeselEmptyTestData.Empty),
                     typeof(PeselEmptyTestData))]
        public void Should_fail_for_empty_or_whitespace_pesel(string pesel, string _)
        {
            AssertInvalid(pesel);
        }
    }
}
