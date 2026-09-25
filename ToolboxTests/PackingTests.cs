using ProjectEuler.Toolbox;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class PackingTests
{
    [Fact]
    public void Knapsack()
    {
        var items = new long[] { 1, 2, 3 };
        var actual = Packing.Knapsack(items, 5).ToArray();

        // Any minimal-size subset of items summing to the goal is correct; assert
        // the property rather than a tie-break-dependent ordering like [3, 2].
        Assert.Equal(2, actual.Length);
        Assert.Equal(5, actual.Sum());
        Assert.All(actual, x => Assert.Contains(x, items));
    }

    [Fact]
    public void Knapsack01()
    {
        var items = Enumerable.Range(1, 45)
            .Select(i => new BigInteger(i))
            .ToArray();

        var expected = new BigInteger(15);
        var actual = Packing.Knapsack01(15, items, out List<BigInteger> bag);

        Assert.Equal(expected, actual);

        // The bag holds the chosen items: distinct inputs summing to the result.
        Assert.Equal(expected, bag.Sum());
        Assert.Equal(bag.Count, bag.Distinct().Count());
        Assert.All(bag, x => Assert.Contains(x, items));
    }

    [Fact]
    public void Knapsack01ZeroItems()
    {
        var items = Array.Empty<BigInteger>();

        var expected = new BigInteger(0);
        var actual = Packing.Knapsack01(15, items, out List<BigInteger> bag);

        Assert.Equal(expected, actual);
        Assert.Empty(bag);
    }

    [Fact]
    public void Knapsack01OneItem()
    {
        var items = Enumerable.Range(1, 1)
            .Select(i => new BigInteger(i))
            .ToArray();

        var expected = new BigInteger(1);
        var actual = Packing.Knapsack01(15, items, out List<BigInteger> bag);

        Assert.Equal(expected, actual);
        Assert.True(bag.SequenceEqual(new[] { new BigInteger(1) }));
    }
}
