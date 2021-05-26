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
            if (!numbers.Contains(',') && !numbers.Contains('\n'))
            {
                return int.Parse(numbers);
            }
            return numbers.Split(',', '\n').Select(num => int.Parse(num)).Sum();
        }
    }
}
