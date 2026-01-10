using PESEL.Generator;

namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    public class PeselGeneratorBuildPeselsFromRandomDigitsTests
    {
        [TestMethod]
        public void BuildPeselsFromRandomDigits_ShouldGenerateExactly10000Pesels()
        {
            // Arrange
            const string datePart = "740401";

            // Act
            var result = PeselGenerator.BuildPeselsFromRandomDigits(datePart).ToList();

            // Assert
            Assert.HasCount(10_000, result);
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_ShouldGenerate11DigitPesels()
        {
            // Arrange
            const string datePart = "740401";

            // Act
            var result = PeselGenerator.BuildPeselsFromRandomDigits(datePart);

            // Assert
            Assert.IsTrue(result.All(p => p.Length == 11));
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_ShouldStartWithDatePart()
        {
            // Arrange
            const string datePart = "740401";

            // Act
            var result = PeselGenerator.BuildPeselsFromRandomDigits(datePart);

            // Assert
            Assert.IsTrue(result.All(p => p.StartsWith(datePart)));
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_ShouldGenerateUniquePesels()
        {
            // Arrange
            const string datePart = "740401";

            // Act
            var result = PeselGenerator.BuildPeselsFromRandomDigits(datePart).ToList();

            // Assert
            Assert.AreEqual(result.Count, result.Distinct().Count());
        }
    }
}
