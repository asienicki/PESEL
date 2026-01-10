namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    [TestCategory("Core")]
    public class PeselGeneratorGenerateLuckyCoreTests
    {
        [TestMethod]
        public void GenerateLuckyCore_ShouldReturnNull_ForInvalidDate()
        {
            // Arrange
            var future = DateTime.Now.AddDays(1);
            var random = new Random(0);

            // Act
            var result = PeselGenerator.GenerateLuckyCore(
                future,
                random,
                _ => 0);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GenerateLuckyCore_ShouldUseGenderDigitSelector()
        {
            // Arrange
            var date = new DateTime(1995, 7, 21);
            var random = new Random(0);

            // zawsze zwracamy 7
            Func<Random, int> selector = _ => 7;

            // Act
            var pesel = PeselGenerator.GenerateLuckyCore(date, random, selector);

            // Assert
            Assert.IsNotNull(pesel);
            Assert.AreEqual(7, pesel[9] - '0');
        }

        [TestMethod]
        public void GenerateLuckyCore_ShouldGenerateValidChecksum()
        {
            // Arrange
            var date = new DateTime(1992, 8, 15);
            var random = new Random(1);

            Func<Random, int> selector = _ => 4;

            // Act
            var pesel = PeselGenerator.GenerateLuckyCore(date, random, selector);

            // Assert
            var withoutCrc = pesel.Substring(0, 10);
            var expected = PeselGenerator.CalculateControlSum(withoutCrc);

            Assert.AreEqual(
                expected.ToString(),
                pesel.Substring(10, 1));
        }

        [TestMethod]
        public void GenerateLuckyCore_ShouldGenerateCorrectDatePrefix()
        {
            // Arrange
            var date = new DateTime(1974, 4, 1); // 740401
            var random = new Random(0);

            Func<Random, int> selector = _ => 0;

            // Act
            var pesel = PeselGenerator.GenerateLuckyCore(date, random, selector);

            // Assert
            Assert.IsTrue(pesel.StartsWith("740401"));
        }
    }


}
