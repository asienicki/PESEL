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
            var calculator = new PeselChecksumCalculator();

            Assert.Throws<ArgumentNullException>(() =>
                calculator.Calculate(null, "7404015279"));
        }

        [TestMethod]
        public void Should_throw_when_text_is_null()
        {
            var calculator = new PeselChecksumCalculator();

            Assert.Throws<ArgumentNullException>(() =>
                calculator.Calculate(Weights, null));
        }

        [TestMethod]
        public void Should_throw_when_weights_length_is_less_than_text_length()
        {
            var calculator = new PeselChecksumCalculator();
            var shortWeights = new[] { 1, 3, 7 };

            Assert.Throws<InvalidChecksumInputException>(() =>
                calculator.Calculate(shortWeights, "740401"));
        }

        [TestMethod]
        public void Should_throw_when_text_contains_non_digit_character()
        {
            var calculator = new PeselChecksumCalculator();

            Assert.Throws<FormatException>(() =>
                calculator.Calculate(Weights, "74040A5279"));
        }
    }
}
