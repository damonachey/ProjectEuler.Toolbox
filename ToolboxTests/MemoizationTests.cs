// Ignore Spelling: Memoization Memoize

using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class MemoizationTests
{
    [Fact]
    public void MemoizeOneParameter()
    {
        var count = 0;
        Func<int, int> func = (input) => count++;
        func = func.Memoize();

        var expected = 0;
        var actual = func(1); // first call
        actual = func(1);     // if not memoized this would increment a second time

        Assert.Equal(expected, actual);

        actual = func(2);

        Assert.Equal(expected + 1, actual);
    }

    [Fact]
    public void MemoizeTwoParameters()
    {
        var count = 0;
        Func<int, int, int> func = (input1, input2) => count++;
        func = func.Memoize();

        var expected = 0;
        var actual = func(1, 2); // first call
        actual = func(1, 2);     // if not memoized this would increment a second time

        Assert.Equal(expected, actual);

        actual = func(2, 2);

        Assert.Equal(expected + 1, actual);
    }

    [Fact]
    public void MemoizeThreeParameters()
    {
        var count = 0;
        Func<int, int, int, int> func = (input1, input2, input3) => count++;
        func = func.Memoize();

        var expected = 0;
        var actual = func(1, 2, 3); // first call
        actual = func(1, 2, 3);     // if not memoized this would increment a second time

        Assert.Equal(expected, actual);

        actual = func(2, 2, 3);

        Assert.Equal(expected + 1, actual);
    }

    [Fact]
    public void MemoizeFourParameters()
    {
        var count = 0;
        Func<int, int, int, int, int> func = (input1, input2, input3, input4) => count++;
        func = func.Memoize();

        var expected = 0;
        var actual = func(1, 2, 3, 4); // first call
        actual = func(1, 2, 3, 4);     // if not memoized this would increment a second time

        Assert.Equal(expected, actual);

        actual = func(2, 2, 3, 4);

        Assert.Equal(expected + 1, actual);
    }

    [Fact]
    public void MemoizeFiveParameters()
    {
        var count = 0;
        Func<int, int, int, int, int, int> func = (input, input2, input3, input4, input5) => count++;
        func = func.Memoize();

        var expected = 0;
        var actual = func(1, 2, 3, 4, 5); // first call
        actual = func(1, 2, 3, 4, 5);     // if not memoized this would increment a second time

        Assert.Equal(expected, actual);

        actual = func(2, 2, 3, 4, 5);

        Assert.Equal(expected + 1, actual);
    }
}
