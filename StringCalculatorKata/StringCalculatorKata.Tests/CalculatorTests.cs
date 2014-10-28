using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringCalculatorKata.BLL;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AssertEmptyStringReturnsZero()
        {
            int result;
            StringCalculator calculator = new StringCalculator();
            result = calculator.Add("");
            Assert.AreEqual(0, result);

        }

        [Test]
        public void AssertOneNumberReturnsNumber()
        {
            int result;
            StringCalculator calculator = new StringCalculator();
            result = calculator.Add("55");
            Assert.AreEqual(55, result);

        }

        [Test]
        public void AssertTwoNumbersReturnsSum()
        {
            int result;
            StringCalculator calculator = new StringCalculator();
            result = calculator.Add("5,7");
            Assert.AreEqual(12, result);
        }

        [TestCase("3, 5, 7", 15)]
        [TestCase("10, 15, 20, 30", 75)]
        [TestCase("100, 200, 300, 400, 500", 1500)]
        public void AssertManyNumbers(string data, int ExpectedResult)
        {
            int result;
            StringCalculator calculator = new StringCalculator();
            result = calculator.Add(data);
            Assert.AreEqual(ExpectedResult, result);
        }

        [Test]
        public void assertValueswithNewline()
        {
            int result;
            StringCalculator calculator = new StringCalculator();
            result = calculator.Add("5\n7");
            Assert.AreEqual(12, result);
        }

        [Test]
        public void assertValueswithNewDelimiter()
        {
            int result;
            StringCalculator calculator = new StringCalculator();
            result = calculator.Add("//;\n5;7");
            Assert.AreEqual(12, result);
        }

    }
}
