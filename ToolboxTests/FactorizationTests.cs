using System.Linq;
using System.Numerics;
using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class FactorizationTests
    {
        [Test]
        public void FactorCountZero()
        {
            var expected = 0;
            var actual = Factorization.FactorCount(0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FactorCount()
        {
            var expected = 12;
            var actual = Factorization.FactorCount(90);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FactorsInt()
        {

            var expected = new int[] { 1, 2, 4, 103, 206, 412 };
            var actual = Factorization.Factors(412);

            Assert.IsTrue(expected.OrderBy(sequence => sequence).SequenceEqual(actual.OrderBy(sequence => sequence)));
        }

        [Test]
        public void FactorsLong()
        {
            var expected = new long[] { 1, 2, 4, 103, 206, 412 };
            var actual = Factorization.Factors(412L);

            Assert.IsTrue(expected.OrderBy(sequence => sequence).SequenceEqual(actual.OrderBy(sequence => sequence)));
        }

        [Test]
        public void FactorsBigInteger()
        {
            var expected = new BigInteger[] { 1, 2, 4, 103, 206, 412 };
            var actual = Factorization.Factors(new BigInteger(412));

            Assert.IsTrue(expected.OrderBy(sequence => sequence).SequenceEqual(actual.OrderBy(sequence => sequence)));
        }

        [Test]
        public void FactorsBigIntegerPrime()
        {
            var expected = 2;
            var actual = Factorization.Factors(new BigInteger(112272535095293)).Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FactorsBigIntegerNonPrime()
        {
            var expected = 32;
            var actual = Factorization.Factors(new BigInteger(6546235646418)).Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GCDInt()
        {
            var expected = 4;
            var actual = Factorization.GCD(412, 612);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GCDLong()
        {
            var expected = 4;
            var actual = Factorization.GCD(412L, 612L);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LCMIntArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LCM(0, 5));
        }

        [Test]
        public void LCMLongArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LCM(0L, 5));
        }

        [Test]
        public void LCMBigIntegerArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LCM(BigInteger.Zero, 5));
        }

        [Test]
        public void LCMInt()
        {
            var expected = 336;
            var actual = Factorization.LCM(42, 16);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LCMLong()
        {
            var expected = 336;
            var actual = Factorization.LCM(42L, 16L);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LCMBigInteger()
        {
            var expected = new BigInteger(336);
            var actual = Factorization.LCM(new BigInteger(42), 16L);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PrimeFactorsIntZero()
        {
            var expected = new int[] { };
            var actual = Factorization.PrimeFactors(0);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void PrimeFactorsInt()
        {
            var expected = new int[] { 2, 2, 5, 103 };
            var actual = Factorization.PrimeFactors(2060);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void PrimeFactorsLongZero()
        {
            var expected = new long[] { };
            var actual = Factorization.PrimeFactors(0L);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void PrimeFactorsLong()
        {
            var expected = new long[] { 2, 2, 5, 103 };
            var actual = Factorization.PrimeFactors(2060L);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void PrimeFactorsBigIntegerZero()
        {
            var expected = new BigInteger[] { };
            var actual = Factorization.PrimeFactors(BigInteger.Zero);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void PrimeFactorsBigInteger()
        {
            var expected = new BigInteger[] { 2, 3, 13, 163, 514884037 };
            var actual = Factorization.PrimeFactors(new BigInteger(6546235646418));

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void PrimeFactorsPrime()
        {
            var expected = 1;
            var actual = Factorization.PrimeFactors(112272535095293).Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PrimeFactorsNonPrime()
        {
            var expected = 5;
            var actual = Factorization.PrimeFactors(6546235646418).Count();

            Assert.AreEqual(expected, actual);
        }
    }
}