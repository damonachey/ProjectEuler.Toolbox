﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class MathLibraryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinomialBadParameter()
        {
            MathLibrary.Binomial(0, 5);
        }

        [TestMethod]
        public void Binomial()
        {
            var expected = new BigInteger(792);
            var actual = MathLibrary.Binomial(12, 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Factorial()
        {
            var expected = BigInteger.Parse("1551118753287382280224243016469303211063259720016986112000000000000");
            var actual = MathLibrary.Factorial(51);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FibonacciNumbers()
        {
            var expected = BigInteger.Parse("222232244629420445529739893461909967206666939096499764990979600");
            var actual = MathLibrary.FibonacciNumbers().Skip(300).First();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsBouncyLongTrue()
        {
            var actual = MathLibrary.IsBouncy(123934);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsBouncyLongFalse()
        {
            var actual = MathLibrary.IsBouncy(12389);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CycleLenthHasCycle()
        {
            var expected = 115;
            var actual = MathLibrary.CycleLength(1, 452);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CycleLenthNoCycle()
        {
            var expected = 0;
            var actual = MathLibrary.CycleLength(12, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaximumSubsetSum()
        {
            var expected = 9;
            var actual = MathLibrary.MaximumSubsetSum(new long[] { 1, 4, -6, 2, 3, 4, -3, -4, 6 });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsCyclicTrue()
        {
            var actual = MathLibrary.IsCyclic("2034", "3498");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsCyclicFalse()
        {
            var actual = MathLibrary.IsCyclic("2034", "3598");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPalindromeTrue()
        {
            var actual = MathLibrary.IsPalindrome("amanaplanacanalpanama");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsPalindromeFalse()
        {
            var actual = MathLibrary.IsPalindrome("fred");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void PascalsTriangle()
        {
            var expected = new long[] { 1, 5, 10, 10, 5, 1 };
            var actual = MathLibrary.PascalsTriangle().Skip(5).First();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void RadOne()
        {
            var expected = 1;
            var actual = MathLibrary.Rad(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rad()
        {
            var expected = 10;
            var actual = MathLibrary.Rad(50);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountInBase()
        {
            var expected = new[] { 0L, 1, 2, 10, 11 };
            var actual = MathLibrary.CountInBase(3).Take(5);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void CountIncreasing()
        {
            MathLibrary.CountIncreasing();
        }

        [TestMethod]
        public void NumberOfSetBits()
        {
            var expected = 5;
            var actual = MathLibrary.NumberOfSetBits(361);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NewtonsMethod()
        {
            var epsilon = 0.0005;
            var expected = 1.732;
            var actual = MathLibrary.NewtonsMethod(x => x * x - 3, x => 2 * x, 2, epsilon);

            Assert.AreEqual(expected, actual, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void NewtonsMethodOutOfRange()
        {
            var epsilon = 0.0005;

            MathLibrary.NewtonsMethod(x => 3 - x * x, x => 2 * x, 2, epsilon);
        }
    }
}