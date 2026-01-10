using System.Reflection;

namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    [TestCategory("DatePrefix")]
    public class PeselGeneratorBuildPeselDatePrefixTests
    {
        [TestMethod]
        public void BuildPeselDatePrefix_ShouldFormatStandard20thCenturyDate()
        {
            // Arrange
            var date = new DateTime(1974, 4, 1);
            var month = 4;

            // Act
            var result = Invoke(date, month);

            // Assert
            Assert.AreEqual("740401", result);
        }

        [TestMethod]
        public void BuildPeselDatePrefix_ShouldFormatMonthWithLeadingZero()
        {
            // Arrange
            var date = new DateTime(1988, 3, 9);
            var month = 3;

            // Act
            var result = Invoke(date, month);

            // Assert
            Assert.AreEqual("880309", result);
        }

        [TestMethod]
        public void BuildPeselDatePrefix_ShouldFormatDayWithLeadingZero()
        {
            // Arrange
            var date = new DateTime(1991, 12, 7);
            var month = 12;

            // Act
            var result = Invoke(date, month);

            // Assert
            Assert.AreEqual("911207", result);
        }

        [TestMethod]
        public void BuildPeselDatePrefix_ShouldSupportPeselEncodedMonth_21stCentury()
        {
            // Arrange
            var date = new DateTime(2005, 4, 1);
            var month = 24; // 04 + 20

            // Act
            var result = Invoke(date, month);

            // Assert
            Assert.AreEqual("052401", result);
        }

        [TestMethod]
        public void BuildPeselDatePrefix_ShouldSupportPeselEncodedMonth_19thCentury()
        {
            // Arrange
            var date = new DateTime(1850, 4, 1);
            var month = 84; // 04 + 80

            // Act
            var result = Invoke(date, month);

            // Assert
            Assert.AreEqual("508401", result);
        }

        /// <summary>
        /// Helper to access internal method.
        /// </summary>
        private static string Invoke(DateTime date, int month)
        {
            var method = typeof(PeselGenerator).GetMethod(
                "BuildPeselDatePrefix",
                BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsNotNull(method, "BuildPeselDatePrefix method not found.");

            var result = method.Invoke(null, new object[] { date, month });

            Assert.IsInstanceOfType(result, typeof(string));

            return (string)result;
        }
    }
}
