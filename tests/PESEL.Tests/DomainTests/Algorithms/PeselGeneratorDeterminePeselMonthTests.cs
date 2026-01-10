namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    [TestCategory("Month")]
    public class PeselGeneratorDeterminePeselMonthTests
    {
        [TestMethod]
        public void DeterminePeselMonth_ShouldReturnNull_ForFutureDate()
        {
            // Arrange
            var date = DateTime.Now.AddDays(1);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldReturnNull_ForDateBefore1800()
        {
            // Arrange
            var date = new DateTime(1700, 1, 1);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldEncodeMonth_For19thCentury()
        {
            // Arrange
            var date = new DateTime(1850, 4, 15);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(84, result); // 4 + 80
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldEncodeMonth_For20thCentury()
        {
            // Arrange
            var date = new DateTime(1974, 4, 15);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldEncodeMonth_For21stCentury()
        {
            // Arrange
            var date = new DateTime(2005, 4, 15);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(24, result); // 4 + 20
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldHandleBoundaryYear_1899()
        {
            // Arrange
            var date = new DateTime(1899, 12, 31);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(92, result); // 12 + 80
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldHandleBoundaryYear_1900()
        {
            // Arrange
            var date = new DateTime(1900, 1, 1);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldHandleBoundaryYear_1999()
        {
            // Arrange
            var date = new DateTime(1999, 12, 31);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void DeterminePeselMonth_ShouldHandleBoundaryYear_2000()
        {
            // Arrange
            var date = new DateTime(2000, 1, 1);

            // Act
            var result = PeselGenerator.DeterminePeselMonth(date);

            // Assert
            Assert.AreEqual(21, result); // 1 + 20
        }
    }
}
