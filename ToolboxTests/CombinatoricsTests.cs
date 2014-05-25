using System;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class CombinatoricsTests
    {
        [Test]
        public void CombinationCount()
        {
            var expected = new BigInteger(84);
            var actual = Combinatorics.CombinationCount(9, 6);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CombinationCountInvalidArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Combinatorics.CombinationCount(0, 0));
        }

        [Test]
        public void CombinationsString()
        {
            var expected = 84;
            var actual = "123456789".Combinations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [Test]
        public void CombinationsEnumerable()
        {
            var expected = 84;
            var actual = Enumerable.Range(1, 9).Combinations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [Test]
        public void PartitionCountInt()
        {
            var expected = new BigInteger(30);
            var actual = Combinatorics.PartitionCount(9);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PartitionCountUnits()
        {
            var expected = new BigInteger(292);
            var actual = Combinatorics.PartitionCount(100, new int[] { 1, 5, 10, 25, 50 });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PartitionsInt()
        {
            var expected = 30;
            var actual0 = Combinatorics.Partitions(9).ToList();

            Assert.AreEqual(expected, actual0.Count());
            Assert.AreEqual(expected, actual0.Distinct().Count());
        }

        [Test]
        public void PartitionsUnits()
        {
            var expected = 292;
            var actual = Combinatorics.Partitions(100, new int[] { 1, 5, 10, 25, 50 }).ToList();

            Assert.AreEqual(expected, actual.Count());
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [Test]
        public void IsPermutationTrue()
        {
            var actual = "1234567890".IsPermutation("0192837465");

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPermutationFalse()
        {
            var actual = "1234567890".IsPermutation("0192827465");

            Assert.IsFalse(actual);
        }

        [Test]
        public void PermutationCountNK()
        {
            var expected = new BigInteger(970200);
            var actual = Combinatorics.PermutationCount(100, 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PermutationCountInvalidArguments()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Combinatorics.PermutationCount(0, 0));
        }

        [Test]
        public void PermutationsString()
        {
            var expected = 720;
            var actual = "123456".Permutations().ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [Test]
        public void PermutationsStringK()
        {
            var expected = 720;
            var actual = "123456".Permutations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [Test]
        public void PermutationsEnumerable()
        {
            var expected = 720;
            var actual = Enumerable.Range(1, 6).Permutations().ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }

        [Test]
        public void PermutationsEnumerableK()
        {
            var expected = 720;
            var actual = Enumerable.Range(1, 6).Permutations(6).ToList();

            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual(expected, actual.Distinct().Count());
        }
    }
}