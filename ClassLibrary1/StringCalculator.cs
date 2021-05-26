using System.Linq;

namespace ClassLibrary1
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            if (!numbers.Contains(','))
            {
                return int.Parse(numbers);
            }
            string [] nums = numbers.Split(',');
            return int.Parse(nums[0]) + int.Parse(nums[1]);
        }
    }
}
