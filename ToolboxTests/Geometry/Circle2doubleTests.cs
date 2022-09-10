using ProjectEuler.Toolbox;

using System;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Circle2doubleTests
{
    [Fact]
    public void Circle2doubleConstructor()
    {
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r);

        Assert.Equal(c, actual.C);
        Assert.Equal(r, actual.R);
    }

    [Fact]
    public void Area()
    {
        var expected = Math.PI;
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r).Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Circumfrence()
    {
        var expected = 2 * Math.PI;
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r).Circumfrence;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 1) R = 1";
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r).ToString();

        Assert.Equal(expected, actual);
    }
}
