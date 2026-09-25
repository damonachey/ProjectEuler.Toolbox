using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

#pragma warning disable CA1861 // Avoid constant arrays as arguments
public class CombinatoricsTests
{
    [Fact]
    public void AnagramCount()
    {
        var expected = 60;
        var actual = Combinatorics.AnagramCount([1, 2, 3]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CircularPermutationCount()
    {
        var expected = 120;
        var actual = Combinatorics.CircularPermutationCount(6);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CombinationCount()
    {
        var expected = new BigInteger(84);
        var actual = Combinatorics.CombinationCount(9, 6);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CombinationCountInvalidArgument()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Combinatorics.CombinationCount(0, 0));
    }

    [Fact]
    public void CombinationsString()
    {
        var expected = 84;
        var actual = "123456789".Combinations(6).ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());

        // Every combination is a sorted selection of 6 distinct characters.
        Assert.All(actual, c =>
        {
            Assert.Equal(6, c.Distinct().Count());
            Assert.True(c.SequenceEqual(c.OrderBy(ch => ch)), c);
        });

        Assert.Contains("123456", actual);
        Assert.Contains("456789", actual);
    }

    [Fact]
    public void CombinationsEnumerable()
    {
        var expected = 84;
        var actual = Enumerable.Range(1, 9)
            .Combinations(6)
            .Select(c => string.Concat(c))
            .ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());

        Assert.All(actual, c =>
        {
            Assert.Equal(6, c.Distinct().Count());
            Assert.True(c.SequenceEqual(c.OrderBy(ch => ch)), c);
        });

        Assert.Contains("123456", actual);
        Assert.Contains("456789", actual);
    }

    [Fact]
    public void PartitionCountInt()
    {
        var expected = new BigInteger(30);
        var actual = Combinatorics.PartitionCount(9);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartitionCountUnits()
    {
        var expected = new BigInteger(292);
        var actual = Combinatorics.PartitionCount(100, [1, 5, 10, 25, 50]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartitionsInt()
    {
        var expected = 30;
        var actual0 = Combinatorics.Partitions(9).ToArray();

        Assert.Equal(expected, actual0.Length);

        // Every partition is a multiset of positive integers summing to 9.
        Assert.All(actual0, p => Assert.Equal(9, p.Sum()));
        Assert.All(actual0, p => Assert.All(p, part => Assert.True(part > 0)));
        Assert.Contains(actual0, p => p.SequenceEqual(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        Assert.Contains(actual0, p => p.SequenceEqual(new[] { 9 }));
    }

    [Fact]
    public void PartitionsUnits()
    {
        var units = new[] { 1, 5, 10, 25, 50 };
        var expected = 292;
        var actual = Combinatorics.Partitions(100, units).ToArray();

        Assert.Equal(expected, actual.Length);

        // Every partition sums to 100 using only the allowed units.
        Assert.All(actual, p => Assert.Equal(100, p.Sum()));
        Assert.All(actual, p => Assert.All(p, part => Assert.Contains(part, units)));
    }

    [Fact]
    public void IsPermutationTrue()
    {
        var actual = "1234567890".IsPermutation("0192837465");

        Assert.True(actual);
    }

    [Fact]
    public void IsPermutationFalse()
    {
        var actual = "1234567890".IsPermutation("0192827465");

        Assert.False(actual);
    }

    [Fact]
    public void PermutationCountNK()
    {
        var expected = new BigInteger(970200);
        var actual = Combinatorics.PermutationCount(100, 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PermutationCountDistinct()
    {
        var expected = new BigInteger(120);
        var actual = Combinatorics.PermutationCountDistinct("ABCDAA");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PermutationCountInvalidArguments()
    {
        Assert.Throws< ArgumentOutOfRangeException>(() => Combinatorics.PermutationCount(0, 0));
    }

    [Fact]
    public void PermutationsString()
    {
        var expected = 720;
        var actual = "113456".Permutations().ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected / 2, actual.Distinct().Count());

        // Every string is a permutation of the input (two 1s, one each of 3-6).
        Assert.All(actual, p => Assert.True("113456".IsPermutation(p), p));
    }

    [Fact]
    public void PermutationsDistinctString()
    {
        var expected = 360;
        var actual = "113456".PermutationsDistinct().ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());
        Assert.All(actual, p => Assert.True("113456".IsPermutation(p), p));
    }

    [Fact]
    public void PermutationsDistinctEnumerable()
    {
        var expected = 360;
        var actual = new[] { 1, 1, 3, 4, 5, 6 }.PermutationsDistinct().ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Select(p => string.Concat(p)).Distinct().Count());

        // Every sequence is a permutation of the input multiset.
        Assert.All(actual, p => Assert.True(p.OrderBy(x => x).SequenceEqual(new[] { 1, 1, 3, 4, 5, 6 }), p.EnumerableToString()));
    }

    [Fact]
    public void PermutationsEnumerableK()
    {
        var expected = 720;
        var actual = new[] { 1, 1, 3, 4, 5, 6 }.Permutations(6).ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected / 2, actual.Select(p => string.Concat(p)).Distinct().Count());
        Assert.All(actual, p => Assert.True(p.OrderBy(x => x).SequenceEqual(new[] { 1, 1, 3, 4, 5, 6 }), p.EnumerableToString()));
    }
}
