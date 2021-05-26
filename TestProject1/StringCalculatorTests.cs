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
        public void CanSumTwoNumsSeparatedWithComma()
        {
            int sum = _stringCalculator.Add("2,4");
            Assert.Equal(6, sum);
        }

        [Theory]
        [InlineData("5,4,7", 16)]
        [InlineData("4,7,2,9", 22)]
        [InlineData("4,7,2,9,33,56", 111)]
        [InlineData("4,7,2,9,33,56,337,443,128", 1019)]
        [InlineData("4,7,2\n9,33,56\n337,443,128", 1019)]
        public void CanSumUnknownNumberOfNumbers(string numbers, int expectedSum)
        {
            int sum = _stringCalculator.Add(numbers);
            Assert.Equal(expectedSum, sum);
        }

        [Fact]
        public void CanSumTwoNumsSeparatedWithNewLine()
        {
            int sum = _stringCalculator.Add("2\n4");
            Assert.Equal(6, sum);
        }
    }
}
