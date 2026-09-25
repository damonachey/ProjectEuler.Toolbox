using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Line2Tests
{
    [Fact]
    public void Line2doubleConstructorPointSlope()
    {
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(0, 1.5);
        var slope = 0.5;
        var actual = new Line2<double>(p1, slope);

        Assert.Equal(p1, actual.P1);
        Assert.Equal(p2, actual.P2);
    }

    [Fact]
    public void Line2doubleConstructorPointOnYAxisThrows()
    {
        // The point-slope constructor computes P2 = (0, p1.YIntercept(m)). For a
        // point on the y-axis (X = 0) the intercept equals p1.Y for any slope, so
        // P2 collapses onto P1 and the line is degenerate.
        var p1 = new Point2<double>(0, 2);
        var slope = 0.5;

        Assert.Throws<ArithmeticException>(() => new Line2<double>(p1, slope));
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "((1, 2), (3, 4))";
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(3, 4);
        var actual = new Line2<double>(p1, p2).ToString();

        Assert.Equal(expected, actual);
    }
}
