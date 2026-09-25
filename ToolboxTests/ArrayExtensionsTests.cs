using ProjectEuler.Toolbox;

using System;
using System.Collections.Generic;
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
}
