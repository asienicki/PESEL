using PESEL.Models;
using PESEL.ValidationResults;
using PESEL.ValidationResults.Impl;
using PESEL.Validators;
using PESEL.Validators.Impl;

namespace PESEL.Tests.DomainTests.Validators
{
    [TestClass]
    [TestCategory("Domain")]
    [TestCategory("Pipeline")]
    [TestCategory("Composite")]
    public class CompositeValidatorTests
    {
        internal sealed class AlwaysValidValidator : IValidator
        {
            public IPeselValidationResult Validate(PeselEntity entity)
                => new OkValidationResult();
        }

        internal sealed class AlwaysInvalidValidator : IValidator
        {
            public IPeselValidationResult Validate(PeselEntity entity)
                => new InvalidLengthValidationResult();
        }

        internal sealed class CountingValidator : IValidator
        {
            public int CallCount { get; private set; }

            public IPeselValidationResult Validate(PeselEntity entity)
            {
                CallCount++;
                return new OkValidationResult();
            }
        }
        [TestMethod]
        public void Should_return_invalid_when_entity_is_null()
        {
            var composite = new CompositeValidator([]);

            var result = composite.Validate(null);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Should_return_ok_when_all_validators_pass()
        {
            var composite = new CompositeValidator(
            [
                new AlwaysValidValidator(),
                new AlwaysValidValidator()
            ]);

            var result = composite.Validate(new PeselEntity("123"));

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Should_return_first_invalid_result_and_stop_pipeline()
        {
            var counter = new CountingValidator();

            var composite = new CompositeValidator(
            [
                new AlwaysValidValidator(),
                new AlwaysInvalidValidator(), // stop here
                counter
            ]);

            var result = composite.Validate(new PeselEntity("123"));

            Assert.IsInstanceOfType<InvalidLengthValidationResult>(result);
            Assert.AreEqual(0, counter.CallCount);
        }

        [TestMethod]
        public void Should_execute_validators_in_order()
        {
            var first = new CountingValidator();
            var second = new CountingValidator();

            var composite = new CompositeValidator(
            [
                first,
                second
            ]);

            composite.Validate(new PeselEntity("123"));

            Assert.AreEqual(1, first.CallCount);
            Assert.AreEqual(1, second.CallCount);
        }
    }
}
