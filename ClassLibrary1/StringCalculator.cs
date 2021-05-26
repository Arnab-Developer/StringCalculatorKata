using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary1
{
    public class StringCalculator
    {
        private const int _upperNumLimit = 1000;

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            CheckNegative(numbers);
            IList<string> nums = Regex.Matches(numbers, @"-?[0-9]+")
                .Select(match => match.Value)
                .ToList();
            if (nums.Count == 1)
            {
                return int.Parse(nums[0]);
            }
            return nums
                .Where(num => int.Parse(num) <= _upperNumLimit)
                .Select(num => int.Parse(num))
                .Sum();
        }

        private static void CheckNegative(string numbers)
        {
            List<string> negativeNums = Regex.Matches(numbers, @"-[0-9]+")
                .Select(match => match.Value)
                .ToList();
            string joinedNegetiveNumbers = string.Empty;
            foreach (string negativeNum in negativeNums)
            {
                joinedNegetiveNumbers = string.Concat(joinedNegetiveNumbers, negativeNum, ',');
            }
            if (!string.IsNullOrEmpty(joinedNegetiveNumbers))
            {
                throw new ArgumentException(
                    $"Negatives not allowed: {joinedNegetiveNumbers.Substring(0, joinedNegetiveNumbers.Length - 1)}");
            }
        }
    }
}
