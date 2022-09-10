using ProjectEuler.Toolbox;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class ArrayExtensionsTests
{
    [Fact]
    public void ToArrayTest()
    {
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        var actual = ArrayExtensions.ToArray(expected);

        Assert.NotSame(expected, actual);
        Assert.Equal(expected.Length, actual.Length);
        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ToArrayPerformanceTest()
    {
        var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        var sw1 = Stopwatch.StartNew();
        _ = ArrayExtensions.ToArray(arr);
        sw1.Stop();

        var sw2 = Stopwatch.StartNew();
        _ = Enumerable.ToArray(arr);
        sw2.Stop();

        Assert.True(sw1.Elapsed < sw2.Elapsed);
    }
}
