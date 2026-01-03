using PESEL.Tests.TestBase;
using PESEL.Tests.TestData;

namespace PESEL.Tests.SmokeTests
{
    [TestClass]
    [TestCategory("Smoke")]
    [TestCategory("Corpus")]
    public class PeselCorpusSmokeTests : BasePeselValidatorTest
    {
        [TestMethod]
        [DynamicData(nameof(PeselCorpusTestData.Valid),
                     typeof(PeselCorpusTestData))]
        public void Should_accept_all_known_valid_pesels(string pesel)
        {
            AssertValid(pesel);
        }

        [TestMethod]
        [DynamicData(nameof(PeselCorpusTestData.Invalid),
                     typeof(PeselCorpusTestData))]
        public void Should_reject_all_known_invalid_pesels(string pesel)
        {
            AssertInvalid(pesel);
        }
    }
}