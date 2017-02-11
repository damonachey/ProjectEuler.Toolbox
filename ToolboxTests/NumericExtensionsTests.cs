using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class NumericExtensionsTests
    {
        [TestMethod]
        public void ReduceRomanNumeral()
        {
            var expected = "MCMCXCXLXIXIV";
            var actual = "DDDCDLLLXLXXXXVVVIVIIII".ReduceRomanNumeral();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReverseInt()
        {

            var expected = 321;
            var actual = 123.ReverseDigits();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReverseLong()
        {
            var expected = 321;
            var actual = 123L.ReverseDigits();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReverseBigInteger()
        {
            var expected = new BigInteger(321);
            var actual = new BigInteger(123).ReverseDigits();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDigitsInt()
        {
            var expected = new int[] { 4, 3, 2, 1 };
            var actual = 1234.ToDigits();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void ToDigitsLong()
        {
            var expected = new int[] { 4, 3, 2, 1 };
            var actual = 1234L.ToDigits();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void ToDigitsBigInteger()
        {
            var expected = new int[] { 4, 3, 2, 1 };
            var actual = new BigInteger(1234).ToDigits();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}