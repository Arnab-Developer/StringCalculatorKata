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
            return nums
                .Select(num => int.TryParse(num, out int result) ? result : 0)
                .Sum();
        }
    }
}
