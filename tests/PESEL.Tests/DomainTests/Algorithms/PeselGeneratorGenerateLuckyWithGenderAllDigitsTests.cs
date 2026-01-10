using PESEL.Generator;
using PESEL.Models;

namespace PESEL.Tests.DomainTests.Algorithms
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Generator")]
    [TestCategory("Pesel")]
    [TestCategory("Gender")]
    public class PeselGeneratorGenerateLuckyWithGenderAllDigitsTests
    {
        [TestMethod]
        [DataRow(0, Gender.Woman)]
        [DataRow(1, Gender.Man)]
        [DataRow(2, Gender.Woman)]
        [DataRow(3, Gender.Man)]
        [DataRow(4, Gender.Woman)]
        [DataRow(5, Gender.Man)]
        [DataRow(6, Gender.Woman)]
        [DataRow(7, Gender.Man)]
        [DataRow(8, Gender.Woman)]
        [DataRow(9, Gender.Man)]
        public void GenerateLucky_WithGender_ShouldRespectParityRule_ForAllDigits(
            int simulatedDigit,
            Gender expectedGender)
        {
            // Arrange
            var date = new DateTime(1995, 7, 21);

            // mapowanie 0..9 -> 0..4 (jak Next(0,5))
            var value0to4 = simulatedDigit / 2;

            var random = new FakeRandom(value0to4);

            // Act
            var pesel = PeselGenerator.GenerateLucky(date, expectedGender, random);

            // Assert
            Assert.IsNotNull(pesel);

            var genderDigit = pesel[9] - '0';

            if (expectedGender == Gender.Man)
                Assert.AreEqual(1, genderDigit % 2);
            else
                Assert.AreEqual(0, genderDigit % 2);
        }

        /// <summary>
        /// Fake Random kontrolujący wywołanie Next(0,5) dla cyfry płci.
        /// </summary>
        private sealed class FakeRandom : Random
        {
            private readonly int _value0to4;
            private int _callIndex;

            public FakeRandom(int value0to4)
            {
                _value0to4 = value0to4;
            }

            public override int Next(int minValue, int maxValue)
            {
                _callIndex++;

                // 4. wywołanie → cyfra płci
                if (_callIndex == 4 && maxValue == 5)
                    return _value0to4;

                return 0;
            }
        }
    }
}
