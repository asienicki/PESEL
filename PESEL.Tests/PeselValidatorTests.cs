namespace PESEL.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Validators.Impl;

    [TestClass]
    public class PeselValidatorTests
    {
        [TestMethod]
        public void ValidateTest()
        {
            ValidatePesel("02070803628");
            ValidatePesel("54071304899");
            ValidatePesel("48011809618");
        }
        
        [TestMethod]
        public void ValidatePeselFromGeneratorTest()
        {
            var generator = new Generator();

            var peselList = generator.Generate(DateTime.Now.AddYears(-1));
            
            var validator = new PeselValidator();

            foreach (var pesel in peselList)
            {
                var entity = new PeselEntity(pesel);

                var validationResult = validator.Validate(entity);

                Assert.IsTrue(validationResult.IsValid);
            }
        }

        private static void ValidatePesel(string peselString)
        {
            var validator = new PeselValidator();

            var entity = new PeselEntity(peselString);

            var validationResult = validator.Validate(entity);

            Assert.IsTrue(validationResult.IsValid);
        } 
    }
}
