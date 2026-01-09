namespace PESEL.Validators.Impl
{
    using System;
    using System.Globalization;
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;

    /// <summary>
    /// Validates and projects birth date from PESEL.
    /// 
    /// Preconditions:
    /// - PESEL contains digits only
    /// - PESEL length >= 6
    /// - DigitValidator executed earlier
    /// </summary>
    public class BirthDateValidator : IValidator
    {
        public IPeselValidationResult Validate(PeselEntity entity)
        {
            var year = int.Parse(entity.Pesel.Substring(0, 2));
            var month = int.Parse(entity.Pesel.Substring(2, 2));
            var day = int.Parse(entity.Pesel.Substring(4, 2));

            switch (month)
            {
                case >= 1 and <= 12://zwykły miesiąc
                    year += 1900;
                    break;

                case >= 21 and <= 32://m + 20 dla 2000-2099
                    year += 2000;
                    month -= 20;
                    break;

                case >= 41 and <= 52://m+40 dla 2100 - 2199
                    year += 2100;
                    month -= 40;
                    break;

                case >= 61 and <= 72://m+60 dla 2200 - 2299
                    year += 2200;
                    month -= 60;
                    break;

                case >= 81 and <= 92://m+80 dla 1800 - 1899
                    year += 1800;
                    month -= 80;
                    break;

                default:
                    return new InvalidMonthValidationResult();
            }

            bool isDateTime = DateTime.TryParseExact(
                                $"{year:0000}-{month:00}-{day:00}",
                                "yyyy-MM-dd",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out var dateTime);

            if (!isDateTime)
            {
                return new InvalidDateValidationResult();
            }

            entity.PeselStruct.BirthDate = dateTime;

            return new OkValidationResult();
        }
    }
}