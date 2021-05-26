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

            IList<int> nums = GetNumsFromString(numbers);

            if (nums.Count == 0)
            {
                throw new ArgumentException($"Invalid format {numbers}");
            }

            CheckNegative(nums);

            if (nums.Count == 1)
            {
                return nums[0];
            }

            return nums
                .Where(num => num <= _upperNumLimit)
                .Sum();
        }

        private IList<int> GetNumsFromString(string numbers) =>
            Regex.Matches(numbers, @"-?[0-9]+")
                .Select(match => int.Parse(match.Value))
                .ToList();

        private void CheckNegative(IList<int> nums)
        {
            string joinedNegetiveNumbers = string.Empty;
            foreach (int negativeNum in nums)
            {
                if (negativeNum < 0)
                {
                    joinedNegetiveNumbers = string.Concat(joinedNegetiveNumbers, negativeNum, ',');
                }
            }
            if (!string.IsNullOrEmpty(joinedNegetiveNumbers))
            {
                throw new ArgumentException(
                    $"Negatives not allowed: {joinedNegetiveNumbers.Substring(0, joinedNegetiveNumbers.Length - 1)}");
            }
        }
    }
}
