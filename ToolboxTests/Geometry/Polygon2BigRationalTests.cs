﻿using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Polygon2BigRationalTests
{
    [Fact]
    public void ToStringTest()
    {
        var expected = "((1, 2), (3, 4), (5, 6), (7, 8))";
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var actual = new Polygon2BigRational(p1, p2, p3, p4).ToString();

        Assert.Equal(expected, actual);
    }
}
