using ClassLibrary1;
using System;
using Xunit;

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

        [Fact]
        public void CanHandleDifferentDelimiters()
        {
            int sum = _stringCalculator.Add("//;\n1;2");
            Assert.Equal(3, sum);
        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void CanThrowExceptionForNegetiveNumber(string numbers, string expectedExceptionMessage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => _stringCalculator.Add(numbers));
            Assert.Equal(expectedExceptionMessage, ex.Message);
        }

        [Fact]
        public void CanIgnoreGreaterThan1000()
        {
            int sum = _stringCalculator.Add("1001,2");
            Assert.Equal(2, sum);
        }

        [Fact]
        public void CanHandleDifferentLengthDelimiters()
        {
            int sum = _stringCalculator.Add("//[|||]\n1|||2|||3");
            Assert.Equal(6, sum);
        }

        [Fact]
        public void CanHandleMultipleDelimiters()
        {
            int sum = _stringCalculator.Add("//[|][%]\n1|2%3");
            Assert.Equal(6, sum);
        }

        [Fact]
        public void CanHandleMultipleDelimitersWithAnyLength()
        {
            int sum = _stringCalculator.Add("///[|]4[%]\n1|2%%3_2");
            Assert.Equal(12, sum);
        }
    }
}
