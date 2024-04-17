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
    }

    [Fact]
    public void CombinationsEnumerable()
    {
        var expected = 84;
        var actual = Enumerable.Range(1, 9).Combinations(6).ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());
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
        Assert.Equal(expected, actual0.Distinct().Count());
    }

    [Fact]
    public void PartitionsUnits()
    {
        var expected = 292;
        var actual = Combinatorics.Partitions(100, [1, 5, 10, 25, 50]).ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());
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
    }

    [Fact]
    public void PermutationsDistinctString()
    {
        var expected = 360;
        var actual = "113456".PermutationsDistinct().ToArray();

        Assert.Equal(expected, actual.Length);
    }

    [Fact]
    public void PermutationsStringK()
    {
        var expected = 720;
        var actual = "113456".Permutations(6).ToArray();

        Assert.Equal(expected, actual.Length);
    }

    [Fact]
    public void PermutationsDistinctEnumerable()
    {
        var expected = 360;
        var actual = new[] { 1, 1, 3, 4, 5, 6 }.PermutationsDistinct().ToArray();

        Assert.Equal(expected, actual.Length);
    }

    [Fact]
    public void PermutationsEnumerableK()
    {
        var expected = 720;
        var actual = new[] { 1, 1, 3, 4, 5, 6 }.Permutations(6).ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());
    }
}
