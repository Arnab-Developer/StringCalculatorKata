using System;
using System.Linq;

namespace ClassLibrary1
{
    public class StringCalculator
    {
        private readonly char[] _delimiters;

        public StringCalculator()
        {
            _delimiters = new char[] { ',', '\n', ';' };
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            string[] nums = numbers.Split(_delimiters);
            if (nums.Length == 1)
            {
                return int.Parse(nums[0]);
            }
            string negetiveNumbers = string.Empty;
            foreach(string num in nums)
            {
                if (int.TryParse(num, out int result) && result < 0)
                {
                    negetiveNumbers = string.Concat(negetiveNumbers, result, ',');
                }
            }
            if (!string.IsNullOrEmpty(negetiveNumbers))
            {
                throw new ArgumentException($"Negatives not allowed: {negetiveNumbers.Substring(0, negetiveNumbers.Length - 1)}");
            }
                
            return nums.Select(num => int.TryParse(num, out int result) ? result : 0).Sum();
        }
    }
}
