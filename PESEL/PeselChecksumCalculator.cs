using PESEL.Exceptions;
using System;

namespace PESEL
{
    public class PeselChecksumCalculator
    {
        public static int Calculate(int[] weights, string text)
        {
            if (weights == null)
                throw new ArgumentNullException(nameof(weights));

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (weights.Length < text.Length)
                throw new InvalidChecksumInputException();

            var sum = 0;

            for (var i = 0; i < text.Length; i++)
            {
                var p = int.Parse(text.Substring(i, 1));
                sum += weights[i] * p;
            }

            sum = sum % 10;

            if (sum > 0)
            {
                sum = 10 - sum;
            }

            return sum;
        }
    }
}