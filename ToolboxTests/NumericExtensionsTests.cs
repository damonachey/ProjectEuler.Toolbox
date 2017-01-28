using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class NumericExtensionsTests
    {
        [Test]
        public void ReduceRomanNumeral()
        {
            var expected = "MCMCXCXLXIXIV";
            var actual = "DDDCDLLLXLXXXXVVVIVIIII".ReduceRomanNumeral();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseInt()
        {

            var expected = 321;
            var actual = 123.ReverseDigits();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseLong()
        {
            var expected = 321;
            var actual = 123L.ReverseDigits();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseBigInteger()
        {
            var expected = new BigInteger(321);
            var actual = new BigInteger(123).ReverseDigits();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToDigitsInt()
        {
            var expected = new int[] { 4, 3, 2, 1 };
            var actual = 1234.ToDigits();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ToDigitsLong()
        {
            var expected = new int[] { 4, 3, 2, 1 };
            var actual = 1234L.ToDigits();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ToDigitsBigInteger()
        {
            var expected = new int[] { 4, 3, 2, 1 };
            var actual = new BigInteger(1234).ToDigits();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}