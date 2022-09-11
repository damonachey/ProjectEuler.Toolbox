﻿using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Point3doubleTests
{
    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 2, 3)";
        var p = new Point3double(1, 2, 3);
        var actual = p.ToString();

        Assert.Equal(expected, actual);
    }
}
