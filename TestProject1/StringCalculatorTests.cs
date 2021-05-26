using Xunit;
using ClassLibrary1;

namespace TestProject1
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void CanEmptyStringReturnZero()
        {
            int sum = _stringCalculator.Add(string.Empty);
            Assert.Equal(0, sum);
        }

        [Fact]
        public void CanReturnOneNum()
        {
            int sum = _stringCalculator.Add("2");
            Assert.Equal(2, sum);
        }

        [Fact]
        public void CanSumTwoNums()
        {
            int sum = _stringCalculator.Add("2,4");
            Assert.Equal(6, sum);
        }
    }
}
