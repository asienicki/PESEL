using PESEL.Exceptions;

namespace PESEL.Tests.DomainTests.Algorithms
{

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Checksum")]
    public class PeselChecksumCalculatorFailTests
    {
        private static readonly int[] Weights =
            { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        [TestMethod]
        public void Should_throw_when_weights_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
                PeselChecksumCalculator.Calculate(null, "7404015279"));
        }

        [TestMethod]
        public void Should_throw_when_text_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
                PeselChecksumCalculator.Calculate(Weights, null));
        }

        [TestMethod]
        public void Should_throw_when_weights_length_is_less_than_text_length()
        {
            var shortWeights = new[] { 1, 3, 7 };

            Assert.Throws<InvalidChecksumInputException>(() =>
                PeselChecksumCalculator.Calculate(shortWeights, "740401"));
        }

        [TestMethod]
        public void Should_throw_when_text_contains_non_digit_character()
        {
            Assert.Throws<FormatException>(() =>
                PeselChecksumCalculator.Calculate(Weights, "74040A5279"));
        }
    }
}
