namespace PESEL.Validators.Impl
{
    using System;
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    /// <summary>
    /// Validates PESEL checksum and projects control digit.
    /// 
    /// Preconditions:
    /// - PESEL length == 11
    /// - PESEL contains digits only
    /// </summary>
    public class SumControlNumberValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            var weights = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            var checkSum = PeselChecksumCalculator.Calculate(weights, entity.Pesel.Substring(0, 10));

            if (checkSum == (int)char.GetNumericValue(entity.Pesel[10]))
            {
                entity.PeselStruct.ControlNumber = Convert.ToByte(checkSum);
                return new OkValidationResult();
            }

            return new InvalidCheckSumValidationResult();
        }
    }
}