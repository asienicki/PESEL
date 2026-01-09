namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Models;
    using PESEL.Tests.TestData;
    using PESEL.Validators.Impl;
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Gender")]
    public class PeselGenderTests
    {
        [TestMethod]
        [DynamicData(nameof(PeselGenderTestData.Female),
                     typeof(PeselGenderTestData))]
        public void Should_extract_female_gender(string pesel)
        {
            var entity = new PeselEntity(pesel);
            new PeselValidator().Validate(entity);

            Assert.AreEqual(Gender.Woman, entity.PeselStruct.Gender);
        }

        [TestMethod]
        [DynamicData(nameof(PeselGenderTestData.Male),
                     typeof(PeselGenderTestData))]
        public void Should_extract_male_gender(string pesel)
        {
            var entity = new PeselEntity(pesel);
            new PeselValidator().Validate(entity);

            Assert.AreEqual(Gender.Man, entity.PeselStruct.Gender);
        }
    }
}
