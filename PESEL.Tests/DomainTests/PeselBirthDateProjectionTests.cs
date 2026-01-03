namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Models;
    using PESEL.Tests.TestData;
    using PESEL.Validators.Impl;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("BirthDate")]
    [TestCategory("Projection")]
    public class PeselBirthDateProjectionTests
    {
        [TestMethod]
        [DynamicData(nameof(PeselBirthDateProjectionTestData.Cases),
                     typeof(PeselBirthDateProjectionTestData))]
        public void Should_extract_correct_birth_date(string pesel, DateTime expected)
        {
            var entity = new PeselEntity(pesel);

            new PeselValidator().Validate(entity);

            Assert.AreEqual(expected, entity.PeselStruct.BirthDate);
        }
    }
}
