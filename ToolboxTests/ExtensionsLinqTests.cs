using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class ExtensionsLinqTests
    {
        [Test]
        public void BinarySearchForMatchFound()
        {
            var expected = 5;
            var actual = Enumerable
                .Range(0, 10)
                .ToArray()
                .BinarySearchForMatch(match => match - 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchForMatchNotFoundMiddle()
        {
            var expected = -4;
            var actual = Enumerable
                .Range(0, 10)
                .Select(i => i * 2)
                .ToArray()
                .BinarySearchForMatch(match => match - 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchForMatchNotFoundLess()
        {
            var expected = -11;
            var actual = Enumerable
                .Range(0, 10)
                .ToArray()
                .BinarySearchForMatch(match => match - 500);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchForMatchNotFoundGreater()
        {
            var expected = -1;
            var actual = Enumerable
                .Range(0, 10)
                .ToArray()
                .BinarySearchForMatch(match => match + 500);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseRange()
        {
            var expected = new int[] { 0, 1, 2, 3, 4, 5, 9, 8, 7, 6 };
            var actual = Enumerable.Range(0, 10).ToList();
            actual.ReverseRange(6, 10);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void Swap()
        {
            var expected = new int[] { 1, 3, 2, 4 };
            var actual = Enumerable.Range(1, 4).ToList();
            actual.Swap(1, 2);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void RandomSampleSubset()
        {
            var expected = Enumerable.Range(1, 5).ToList();
            var actual = Enumerable.Range(1, 10).RandomSample(5).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.IsFalse(expected.SequenceEqual(actual));
        }

        [Test]
        public void RandomSampleWholeSet()
        {
            var expected = Enumerable.Range(1, 10).ToList();
            var actual = Enumerable.Range(1, 10).RandomSample(15).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void Shuffle()
        {
            var expected = Enumerable.Range(1, 10);
            var actual = Enumerable.Range(1, 10).ToList();
            actual.Shuffle();

            Assert.IsFalse(expected.SequenceEqual(actual));
        }

        [Test]
        public void SumBigInteger()
        {
            var expected = new BigInteger(6);
            var actual = Enumerable.Range(1, 3).Select(i => new BigInteger(i)).Sum();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumBigRational()
        {
            var expected = new BigRational(6);
            var actual = Enumerable.Range(1, 3).Select(i => new BigRational(i)).Sum();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllExcept()
        {
            var expected = new int[] { 1, 2, 3, 5, 6, 7 };
            var actual = Enumerable.Range(1, 7).AllExcept(3);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ForAll()
        {
            var expected = Enumerable.Range(1, 10).ToList();
            var actual = new List<int>();

            Enumerable.Range(0, 10).ForAll(i => actual.Add(i + 1));

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ForAllArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Range(1, 2).ForAll(null));
        }

        [Test]
        public void SkipLastArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>)null).SkipLast(2));
        }

        [Test]
        public void SkipLastArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(1, 10).SkipLast(-2));
        }

        [Test]
        public void SkipLastSubset()
        {
            var expected = Enumerable.Range(1, 5).ToList();
            var actual = Enumerable.Range(1, 10).SkipLast(5).ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void SkipLastWholeSet()
        {
            var expected = Enumerable.Range(1, 10).ToList();
            var actual = Enumerable.Range(1, 10).SkipLast(0).ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void TakeLastArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>)null).TakeLast(2));
        }

        [Test]
        public void TakeLastArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(1, 10).TakeLast(-2));
        }

        [Test]
        public void TakeLastSubset()
        {
            var expected = Enumerable.Range(6, 5).ToList();
            var actual = Enumerable.Range(1, 10).TakeLast(5).ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void TakeLastEmptySet()
        {
            var actual = Enumerable.Range(1, 10).TakeLast(0).ToList();

            Assert.IsFalse(actual.TakeLast(0).Any());
        }

        [Test]
        public void MergeFirstLonger()
        {
            var expected = new[] { 2, 4, 6, 4, 5 };
            var actual = new[] { 1, 2, 3, 4, 5 }.Merge(new[] { 1, 2, 3 }, (a, b) => a + b, () => 0, () => 0);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void MergeSecondLonger()
        {
            var expected = new[] { 2, 4, 6, 4, 5 };
            var actual = new[] { 1, 2, 3 }.Merge(new[] { 1, 2, 3, 4, 5 }, (a, b) => a + b, () => 0, () => 0);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void MergeRepeatLastFirstLonger()
        {
            var expected = new[] { 2, 4, 6, 7, 8 };
            var actual = new[] { 1, 2, 3, 4, 5 }.MergeRepeatLast(new[] { 1, 2, 3 }, (a, b) => a + b);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void MergeRepeatLastSecondLonger()
        {
            var expected = new[] { 2, 4, 6, 7, 8 };
            var actual = new[] { 1, 2, 3 }.MergeRepeatLast(new[] { 1, 2, 3, 4, 5 }, (a, b) => a + b);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
