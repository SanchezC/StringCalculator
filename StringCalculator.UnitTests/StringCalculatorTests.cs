using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.UnitTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void GivenAnEmptyString_WhenAdd_ThenReturnZero()
        {
            var result = new StringCalculator().Add(string.Empty);
            result.Should().Be(0);
        }

        [Test]
        public void GivenAStringWithOneNumber_WhenAdd_ThenReturnSum()
        {
            var result = new StringCalculator().Add("1");
            result.Should().Be(1);
        }

        [Test]
        public void GivenAStringWithTwoNumbersSeparatedByCommas_WhenAdd_ThenReturnSum()
        {
            var result = new StringCalculator().Add("1,2");
            result.Should().Be(3);
        }

        [Test]
        public void GivenAStringWithAnyNumbersSeparatedByCommasOrNewLine_WhenAdd_ThenReturnSum()
        {
            var result = new StringCalculator().Add("1\n2,3\n2,1");
            result.Should().Be(9);
        }

        [Test]
        public void GivenAStringWithADelimiterAndNumbersSeparatedByDelimiter_WhenAdd_ThenReturnSum()
        {
            var result = new StringCalculator().Add("//;\n1;2");
            result.Should().Be(3);
        }

        [Test]        
        public void GivenAStringContainingNegativeNumbers_WhenAdd_ThenThrowExceptionWithMessageContainingNegativeNumbers()
        {
            try
            {
                var result = new StringCalculator().Add("-1,2,3,-2");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Negatives not allowed: -1, -2", ex.Message);    
            }
        }
    }
}
