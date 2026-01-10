using PESEL.Generator;

namespace PESEL.Tests.DomainTests.Algorithms
{


    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    public class PeselGeneratorBuildPeselsFromRandomDigitsTakeTests
    {
        private const string DatePart = "740401";

        [TestMethod]
        public void BuildPeselsFromRandomDigits_TakeZero_ShouldGenerateAllPesels()
        {
            // Act
            var result = PeselGenerator
                .BuildPeselsFromRandomDigits(DatePart, take: 0)
                .ToList();

            // Assert
            Assert.HasCount(10_000, result);
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_TakeOne_ShouldGenerateExactlyOnePesel()
        {
            // Act
            var result = PeselGenerator
                .BuildPeselsFromRandomDigits(DatePart, take: 1)
                .ToList();

            // Assert
            Assert.HasCount(1, result);
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_TakeTen_ShouldGenerateExactlyTenPesels()
        {
            // Act
            var result = PeselGenerator
                .BuildPeselsFromRandomDigits(DatePart, take: 10)
                .ToList();

            // Assert
            Assert.HasCount(10, result);
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_TakeEqualMax_ShouldGenerateExactly10000Pesels()
        {
            // Act
            var result = PeselGenerator
                .BuildPeselsFromRandomDigits(DatePart, take: 10_000)
                .ToList();

            // Assert
            Assert.HasCount(10_000, result);
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_TakeGreaterThanMax_ShouldGenerateExactly10000Pesels()
        {
            // Act
            var result = PeselGenerator
                .BuildPeselsFromRandomDigits(DatePart, take: 20_000)
                .ToList();

            // Assert
            Assert.HasCount(10_000, result);
        }

        [TestMethod]
        public void BuildPeselsFromRandomDigits_Take_ShouldNotGenerateMoreThanRequested()
        {
            // Act
            var result = PeselGenerator
                .BuildPeselsFromRandomDigits(DatePart, take: 5);

            // Assert
            Assert.AreEqual(5, result.Take(6).Count());
        }
    }
}
