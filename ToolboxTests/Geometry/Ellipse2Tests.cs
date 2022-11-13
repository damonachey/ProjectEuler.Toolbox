using ProjectEuler.Toolbox;

using System;
using System.Numerics;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Ellipse2Tests
{
    [Fact]
    public void Area()
    {
        var expected = Math.Tau;
        var c = new Point2<double>(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2<double>(c, a, b).Area();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Eccentricity()
    {
        var expected = 0.8660254037844386;
        var c = new Point2<double>(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2<double>(c, a, b).Eccentricity();

        Assert.Equal(expected, actual);
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Traditional mathematical name")]
    public void h()
    {
        var expected = 0.1111111111111111;
        var c = new Point2<double>(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2<double>(c, a, b).h;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Perimeter()
    {
        var expected = 9.688448220506999;
        var c = new Point2<double>(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2<double>(c, a, b).Perimeter;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 1) A = 2, B = 1";
        var c = new Point2<double>(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2<double>(c, a, b).ToString();

        Assert.Equal(expected, actual);
    }
}
