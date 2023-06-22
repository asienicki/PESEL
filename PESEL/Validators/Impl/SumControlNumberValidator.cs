namespace PESEL.Validators.Impl
{
    using System;
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    public class SumControlNumberValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            var weights = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            var calculator = new CheckSumCalculator();
            var checkSum = calculator.Calculate(weights, entity.Pesel.Substring(0, 10));

            if (checkSum == (int)char.GetNumericValue(entity.Pesel[10]))
            {
                entity.PeselStruct.ControlNumber = Convert.ToByte(checkSum);
                return new OkValidationResult();
            }

            return new InvalidCheckSumValidationResult();
        }
    }
}