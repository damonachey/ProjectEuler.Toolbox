using NUnit.Framework;
using ProjectEuler.Toolbox;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class PackingTests
    {
        [Test]
        public void Knapsack()
        {
            var expected = new long[] { 3, 2 };
            var actual = Packing.Knapsack(new long[] { 1, 2, 3 }, 5);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void Knapsack01()
        {
            var items = Enumerable.Range(1, 45)
                .Select(i => new BigInteger(i))
                .ToList();

            var expected = new BigInteger(15);
            var actual = Packing.Knapsack01(15, items, out List<BigInteger> bag);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Knapsack01ZeroItems()
        {
            var items = new List<BigInteger>();

            var expected = new BigInteger(0);
            var actual = Packing.Knapsack01(15, items, out List<BigInteger> bag);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Knapsack01OneItem()
        {
            var items = Enumerable.Range(1, 1)
                .Select(i => new BigInteger(i))
                .ToList();

            var expected = new BigInteger(1);
            var actual = Packing.Knapsack01(15, items, out List<BigInteger> bag);

            Assert.AreEqual(expected, actual);
        }
    }
}