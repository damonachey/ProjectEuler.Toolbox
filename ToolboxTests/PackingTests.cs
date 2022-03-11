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
        var expected = new long[] { 3, 2 };
        var actual = Packing.Knapsack(new long[] { 1, 2, 3 }, 5);

        Assert.True(expected.SequenceEqual(actual));
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
    }

    [Fact]
    public void Knapsack01ZeroItems()
    {
        var items = Array.Empty<BigInteger>();

        var expected = new BigInteger(0);
        var actual = Packing.Knapsack01(15, items, out _);

        Assert.Equal(expected, actual);
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
    }
}
