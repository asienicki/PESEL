using FluentValidation;
using PESEL.FluentValidation;
using PESEL.Generator;

namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    public class PeselGeneratorGenerateLuckyTests
    {
        private class TestModel
        {
            public string Pesel { get; set; }
        }

        private class TestModelValidator : AbstractValidator<TestModel>
        {
            public TestModelValidator()
            {
                RuleFor(x => x.Pesel)
                    .PeselMustBeValid();
            }
        }

        [TestMethod]
        public void GenerateLucky_Result_ShouldBeValidAccordingToFluentValidator()
        {
            // Arrange
            var date = new DateTime(1992, 8, 15);
            var random = new Random(123);

            var pesel = PeselGenerator.GenerateLucky(date, random);
            Assert.IsNotNull(pesel);

            var model = new TestModel { Pesel = pesel };
            var validator = new TestModelValidator();

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void GenerateLucky_ShouldReturnValidPesel_ForValidDate()
        {
            // Arrange
            var date = new DateTime(1990, 5, 12);
            var random = new Random(123);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date, random);

            // Assert
            Assert.IsNotNull(pesel);
            Assert.AreEqual(11, pesel.Length);
        }

        [TestMethod]
        public void GenerateLucky_ShouldBeDeterministic_WhenRandomIsSeeded()
        {
            // Arrange
            var date = new DateTime(1985, 3, 8);
            var random1 = new Random(42);
            var random2 = new Random(42);

            // Act
            var pesel1 = PeselGenerator.GenerateLucky(date, random1);
            var pesel2 = PeselGenerator.GenerateLucky(date, random2);

            // Assert
            Assert.AreEqual(pesel1, pesel2);
        }

        [TestMethod]
        public void GenerateLucky_ShouldReturnDifferentPesels_ForDifferentRandomSeeds()
        {
            // Arrange
            var date = new DateTime(1985, 3, 8);

            // Act
            var pesel1 = PeselGenerator.GenerateLucky(date, new Random(1));
            var pesel2 = PeselGenerator.GenerateLucky(date, new Random(2));

            // Assert
            Assert.AreNotEqual(pesel1, pesel2);
        }

        [TestMethod]
        public void GenerateLucky_ShouldReturnNull_ForFutureDate()
        {
            // Arrange
            var futureDate = DateTime.Now.AddDays(1);

            // Act
            var pesel = PeselGenerator.GenerateLucky(futureDate);

            // Assert
            Assert.IsNull(pesel);
        }

        [TestMethod]
        public void GenerateLucky_ShouldReturnNull_ForDateBefore1800()
        {
            // Arrange
            var date = new DateTime(1700, 1, 1);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date);

            // Assert
            Assert.IsNull(pesel);
        }

        [TestMethod]
        public void GenerateLucky_ShouldEncodeMonthCorrectly_For19thCentury()
        {
            // Arrange
            var date = new DateTime(1850, 4, 1); // month + 80 => 84
            var random = new Random(0);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date, random);

            // Assert
            Assert.StartsWith("508401", pesel);
        }

        [TestMethod]
        public void GenerateLucky_ShouldEncodeMonthCorrectly_For20thCentury()
        {
            // Arrange
            var date = new DateTime(1974, 4, 1); // month = 04
            var random = new Random(0);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date, random);

            // Assert
            Assert.StartsWith("740401", pesel);
        }

        [TestMethod]
        public void GenerateLucky_ShouldEncodeMonthCorrectly_For21stCentury()
        {
            // Arrange
            var date = new DateTime(2005, 4, 1); // month + 20 => 24
            var random = new Random(0);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date, random);

            // Assert
            Assert.StartsWith("052401", pesel);
        }

        [TestMethod]
        public void GenerateLucky_ShouldGenerateDifferentPesels_OnSubsequentCalls_WithSameRandom()
        {
            // Arrange
            var date = new DateTime(1990, 5, 12);
            var random = new Random(123);

            // Act
            var pesel1 = PeselGenerator.GenerateLucky(date, random);
            var pesel2 = PeselGenerator.GenerateLucky(date, random);

            // Assert
            Assert.AreNotEqual(pesel1, pesel2);
        }

        [TestMethod]
        public void GenerateLucky_ShouldGenerateValidChecksum()
        {
            // Arrange
            var date = new DateTime(1990, 5, 12);
            var random = new Random(5);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date, random);

            var peselWithoutCrc = pesel.Substring(0, 10);
            var expectedChecksum = PeselGenerator.CalculateControlSum(peselWithoutCrc);

            // Assert
            Assert.AreEqual(
                expectedChecksum.ToString(),
                pesel.Substring(10, 1));
        }
    }
}
