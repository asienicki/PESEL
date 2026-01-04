namespace PESEL.Tests.DomainTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PESEL.Models;
    using PESEL.Validators.Impl;

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Projection")]
    public class PeselStructureProjectionTests
    {
        private static readonly char[] ExpectedRandomNumbers = { '5', '2', '7' };

        [TestMethod]
        public void Should_extract_all_pesel_parts_correctly()
        {
            var entity = new PeselEntity("74040152795");

            var result = new PeselValidator().Validate(entity);
            Assert.IsTrue(result.IsValid);

            Assert.AreEqual(new DateTime(1974, 04, 01), entity.PeselStruct.BirthDate);

            CollectionAssert.AreEqual(ExpectedRandomNumbers, entity.PeselStruct.RandomNumbers);

            Assert.AreEqual(9, entity.PeselStruct.GenderNumber);
            Assert.AreEqual(5, entity.PeselStruct.ControlNumber);
        }
    }
}
