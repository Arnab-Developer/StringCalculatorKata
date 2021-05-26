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
            return numbers.Split(',').Select(num => int.Parse(num)).Sum();
        }
    }
}
