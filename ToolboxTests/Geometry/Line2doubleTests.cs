using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Line2doubleTests
{
    [Fact]
    public void Line2doubleConstructorPointSlope()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(0, 1.5);
        var slope = 0.5;
        var actual = new Line2double(p1, slope);

        Assert.Equal(p1, actual.P1);
        Assert.Equal(p2, actual.P2);
    }

    [Fact]
    public void Line2doubleConstructorSlopeInfinate()
    {
        var p1 = new Point2double(0, 2);
        var p2 = new Point2double(0, 1.5);
        var slope = 0.5;

        Assert.Throws<ArithmeticException>(() => new Line2double(p1, slope));
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "((1, 2), (3, 4))";
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var actual = new Line2double(p1, p2).ToString();

        Assert.Equal(expected, actual);
    }
}
