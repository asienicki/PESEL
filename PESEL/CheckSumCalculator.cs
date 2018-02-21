namespace PESEL
{
    public class CheckSumCalculator
    {
        public int Calculate(int[] weights, string text)
        {

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