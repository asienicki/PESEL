using PESEL.Generator;

namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Checksum")]
    public class PeselGeneratorCalculateControlSumTests
    {
        [TestMethod]
        public void CalculateControlSum_ShouldReturnExpectedChecksum_ForValidPeselBase()
        {
            // Arrange
            const string pesel = "4405140135"; // znany poprawny PESEL
            const int expectedChecksum = 9;

            // Act
            var checksum = PeselGenerator.CalculateControlSum(pesel);

            // Assert
            Assert.AreEqual(expectedChecksum, checksum);
        }

        [TestMethod]
        public void CalculateControlSum_ShouldMatchLastDigitOfValidPesel()
        {
            // Arrange
            const string fullPesel = "44051401359";

            // Act
            var checksum = PeselGenerator.CalculateControlSum(fullPesel);
            var lastDigit = fullPesel[^1] - '0';

            // Assert
            Assert.AreEqual(lastDigit, checksum);
        }

        [TestMethod]
        public void CalculateControlSum_ShouldBeStable_ForSameInput()
        {
            // Arrange
            const string pesel = "0207080362";

            // Act
            var first = PeselGenerator.CalculateControlSum(pesel);
            var second = PeselGenerator.CalculateControlSum(pesel);

            // Assert
            Assert.AreEqual(first, second);
        }
    }
}
