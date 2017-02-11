using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class CombinatoricsTests
    {
        [TestMethod]
        public void AnagramCount()
        {
            var expected = 60;
            var actual = Combinatorics.AnagramCount(new[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CircularPermutationcount()
        {
            var expected = 120;
            var actual = Combinatorics.CircularPermutationCount(6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CombinationCount()
        {
            var expected = new BigInteger(84);
            var actual = Combinatorics.CombinationCount(9, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CombinationCountInvalidArgument()
        {
            Combinatorics.CombinationCount(0, 0);
        }

        [TestMethod]
        public void CombinationsString()
        {
            var expected = 84;
            var actual = "123456789".Combinations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [TestMethod]
        public void CombinationsEnumerable()
        {
            var expected = 84;
            var actual = Enumerable.Range(1, 9).Combinations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [TestMethod]
        public void PartitionCountInt()
        {
            var expected = new BigInteger(30);
            var actual = Combinatorics.PartitionCount(9);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartitionCountUnits()
        {
            var expected = new BigInteger(292);
            var actual = Combinatorics.PartitionCount(100, new int[] { 1, 5, 10, 25, 50 });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartitionsInt()
        {
            var expected = 30;
            var actual0 = Combinatorics.Partitions(9).ToList();

            Assert.AreEqual(expected, actual0.Count());
            Assert.AreEqual(expected, actual0.Distinct().Count());
        }

        [TestMethod]
        public void PartitionsUnits()
        {
            var expected = 292;
            var actual = Combinatorics.Partitions(100, new int[] { 1, 5, 10, 25, 50 }).ToList();

            Assert.AreEqual(expected, actual.Count());
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [TestMethod]
        public void IsPermutationTrue()
        {
            var actual = "1234567890".IsPermutation("0192837465");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsPermutationFalse()
        {
            var actual = "1234567890".IsPermutation("0192827465");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void PermutationCountNK()
        {
            var expected = new BigInteger(970200);
            var actual = Combinatorics.PermutationCount(100, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PermutationCountInvalidArguments()
        {
            Combinatorics.PermutationCount(0, 0);
        }

        [TestMethod]
        public void PermutationsString()
        {
            var expected = 720;
            var actual = "123456".Permutations().ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [TestMethod]
        public void PermutationsStringK()
        {
            var expected = 720;
            var actual = "123456".Permutations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [TestMethod]
        public void PermutationsEnumerable()
        {
            var expected = 720;
            var actual = Enumerable.Range(1, 6).Permutations().ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [TestMethod]
        public void PermutationsEnumerableK()
        {
            var expected = 720;
            var actual = Enumerable.Range(1, 6).Permutations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }
    }
}