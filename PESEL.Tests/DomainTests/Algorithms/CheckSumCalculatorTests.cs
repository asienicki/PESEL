namespace PESEL.Tests.DomainTests.Algorithms
{

    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Algorithm")]
    [TestCategory("Checksum")]
    public class PeselChecksumCalculatorTests
    {
        private static readonly int[] Weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        private PeselChecksumCalculator _calculator = null!;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new PeselChecksumCalculator();
        }

        [TestMethod]
        public void Should_calculate_correct_checksum_for_known_pesel_prefix()
        {
            var result = _calculator.Calculate(Weights, "7404015279");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Should_return_zero_when_sum_modulo_is_zero()
        {
            // dobrane tak, aby suma % 10 == 0
            var result = _calculator.Calculate(Weights, "0000000000");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Should_calculate_checksum_independent_of_text_length()
        {
            var shortWeights = new[] { 1, 3, 7 };

            var result = _calculator.Calculate(shortWeights, "123");

            Assert.AreEqual((1 * 1 + 3 * 2 + 7 * 3) % 10 == 0 ? 0 : 10 - ((1 * 1 + 3 * 2 + 7 * 3) % 10), result);
        }
    }
}
