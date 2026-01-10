using System.Linq;

namespace PESEL
{
    using PESEL.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public static class PeselGenerator
    {
        #region Public methods

        /// <summary>
        /// Generates all valid possible PESEL numbers for the specified date.
        /// </summary>
        /// <param name="dateTime">The date for which the PESEL numbers should be generated.</param>
        /// <returns>An enumerable sequence of valid PESEL numbers.</returns>
        public static IEnumerable<string> Generate(DateTime dateTime, int take = 0)
        {
            var month = DeterminePeselMonth(dateTime);

            if (month is null)
                yield break;

            var datePeselString = BuildPeselDatePrefix(dateTime, month.Value);

            foreach (var pesel in BuildPeselsFromRandomDigits(datePeselString, take))
                yield return pesel;
        }

        /// <summary>
        /// Generates a random (non-deterministic) PESEL number for the specified date.
        /// Intended for demo, samples, and testing scenarios.
        /// </summary>
        /// <param name="date">The date for which the PESEL number should be generated.</param>
        /// <param name="random">
        /// Optional random number generator.  
        /// Providing an instance allows deterministic results in tests.
        /// </param>
        /// <returns>
        /// A randomly generated valid PESEL number, or <c>null</c> if the date is not valid.
        /// </returns>
        public static string GenerateLucky(DateTime date, Random random = null)
        {
            if (random == null)
                random = new Random();

            return GenerateLuckyCore(
                date,
                random,
                r => r.Next(0, 10));
        }

        public static string GenerateLucky(DateTime date, Gender gender, Random random = null)
        {
            if (random == null)
                random = new Random();

            return GenerateLuckyCore(
                date,
                random,
                r => gender == Gender.Man
                    ? r.Next(0, 5) * 2 + 1   // 1,3,5,7,9
                    : r.Next(0, 5) * 2);    // 0,2,4,6,8
        }

        #endregion

        #region internal methods

        internal static string GenerateLuckyCore(DateTime date, Random random, Func<Random, int> genderDigitSelector)
        {
            var month = DeterminePeselMonth(date);
            if (month is null)
                return null;

            var datePart = BuildPeselDatePrefix(date, month.Value);

            var a = random.Next(0, 10);
            var b = random.Next(0, 10);
            var c = random.Next(0, 10);
            var d = genderDigitSelector(random);

            var peselWithoutCrc = $"{datePart}{a}{b}{c}{d}";
            return $"{peselWithoutCrc}{CalculateControlSum(peselWithoutCrc)}";
        }

        internal static string BuildPeselDatePrefix(DateTime date, int month)
        {
            return
                date.ToString("yy", CultureInfo.InvariantCulture) +
                month.ToString("00", CultureInfo.InvariantCulture) +
                date.Day.ToString("00", CultureInfo.InvariantCulture);
        }

        internal static int? DeterminePeselMonth(DateTime date)
        {
            if (date >= DateTime.Now)
                return null;

            return date.Year switch
            {
                < 1800 => null,
                > 1800 and < 1900 => date.Month + 80,
                >= 1900 and < 2000 => date.Month,
                >= 2000 => date.Month + 20,
                _ => null
            };
        }

        /// <summary>
        /// Calculates the PESEL checksum using the weights
        /// (1, 3, 7, 9, 1, 3, 7, 9, 1, 3).
        /// </summary>
        /// <param name="pesel">The PESEL number (without the checksum digit).</param>
        /// <returns>The calculated checksum digit.</returns>
        internal static int CalculateControlSum(string pesel)
        {
            var weights = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            var calculator = new PeselChecksumCalculator();

            var checkSum = calculator.Calculate(weights, pesel.Substring(0, 10));

            return checkSum;
        }

        internal static IEnumerable<string> BuildPeselsFromRandomDigits(string peselDateString, int take = 0)
        {
            var count = 0;
            for (var a = 0; a < 10; a++)
            {
                for (var b = 0; b < 10; b++)
                {
                    for (var c = 0; c < 10; c++)
                    {
                        for (var d = 0; d < 10; d++)
                        {
                            if (take > 0 && count >= take)
                            {
                                yield break;
                            }

                            count++;

                            var peselWithoutCrc = $"{peselDateString}{a}{b}{c}{d}";

                            yield return $"{peselWithoutCrc}{CalculateControlSum(peselWithoutCrc)}";
                        }
                    }
                }
            }
        }

        #endregion
    }
}
