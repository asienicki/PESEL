namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Tests.TestBase;
    using PESEL.Tests.TestData;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Garbage")]
    public class PeselGarbageValidatorTests : BasePeselValidatorTest
    {
        [TestMethod]
        [DynamicData(nameof(PeselGarbageTestData.Garbage),
                     typeof(PeselGarbageTestData))]
        public void Should_fail_for_garbage_input(string pesel, string _)
        {
            AssertInvalid(pesel);
        }
    }
}
