using ProjectEuler.Toolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class LinqExtensionsTests
{
    [Fact]
    public void BinarySearchForMatchFound()
    {
        var expected = 5;
        var actual = Enumerable
            .Range(0, 10)
            .ToArray()
            .BinarySearchForMatch(match => match - 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BinarySearchForMatchNotFoundMiddle()
    {
        var expected = -4;
        var actual = Enumerable
            .Range(0, 10)
            .Select(i => i * 2)
            .ToArray()
            .BinarySearchForMatch(match => match - 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BinarySearchForMatchNotFoundLess()
    {
        var expected = -11;
        var actual = Enumerable
            .Range(0, 10)
            .ToArray()
            .BinarySearchForMatch(match => match - 500);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BinarySearchForMatchNotFoundGreater()
    {
        var expected = -1;
        var actual = Enumerable
            .Range(0, 10)
            .ToArray()
            .BinarySearchForMatch(match => match + 500);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReverseRange()
    {
        var expected = new int[] { 0, 1, 2, 3, 4, 5, 9, 8, 7, 6 };
        var actual = Enumerable.Range(0, 10).ToArray();
        actual.ReverseRange(6, 10);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void RandomSampleSubset()
    {
        var expected = Enumerable.Range(1, 5).ToArray();
        var actual = Enumerable.Range(1, 10).RandomSample(5).ToArray();

        Assert.Equal(expected.Length, actual.Length);
        Assert.False(expected.SequenceEqual(actual));
    }

    [Fact]
    public void RandomSampleWholeSet()
    {
        var expected = Enumerable.Range(1, 10).ToArray();
        var actual = Enumerable.Range(1, 10).RandomSample(15).ToArray();

        Assert.Equal(expected.Length, actual.Length);
        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void Shuffle()
    {
        var expected = Enumerable.Range(1, 10);
        var actual = Enumerable.Range(1, 10).ToArray();
        actual.Shuffle();

        Assert.False(expected.SequenceEqual(actual));
    }

    [Fact]
    public void SumBigInteger()
    {
        var expected = new BigInteger(6);
        var actual = Enumerable.Range(1, 3).Select(i => new BigInteger(i)).Sum();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SumBigRational()
    {
        var expected = new BigRational(6);
        var actual = Enumerable.Range(1, 3).Select(i => new BigRational(i)).Sum();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AllExcept()
    {
        var expected = new int[] { 1, 2, 3, 5, 6, 7 };
        var actual = Enumerable.Range(1, 7).AllExcept(3);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ForAll()
    {
        var expected = Enumerable.Range(1, 10).ToArray();
        var actual = new List<int>();

        Enumerable.Range(0, 10).ForAll(i => actual.Add(i + 1));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeFirstLonger()
    {
        var expected = new[] { 2, 4, 6, 4, 5 };
        var actual = new[] { 1, 2, 3, 4, 5 }.Merge(new[] { 1, 2, 3 }, (a, b) => a + b, () => 0, () => 0);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeSecondLonger()
    {
        var expected = new[] { 2, 4, 6, 4, 5 };
        var actual = new[] { 1, 2, 3 }.Merge(new[] { 1, 2, 3, 4, 5 }, (a, b) => a + b, () => 0, () => 0);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastFirstLonger()
    {
        var expected = new[] { 2, 4, 6, 7, 8 };
        var actual = new[] { 1, 2, 3, 4, 5 }.MergeRepeatLast(new[] { 1, 2, 3 }, (a, b) => a + b);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastSecondLonger()
    {
        var expected = new[] { 2, 4, 6, 7, 8 };
        var actual = new[] { 1, 2, 3 }.MergeRepeatLast(new[] { 1, 2, 3, 4, 5 }, (a, b) => a + b);

        Assert.True(expected.SequenceEqual(actual));
    }
}
