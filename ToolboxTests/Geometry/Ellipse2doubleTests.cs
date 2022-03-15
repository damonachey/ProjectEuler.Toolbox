using ProjectEuler.Toolbox;

using System;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Ellipse2doubleTests
{
    [Fact]
    public void Ellipse2doubleConstructor()
    {
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b);

        Assert.Equal(c, actual.C);
        Assert.Equal(a, actual.A);
        Assert.Equal(b, actual.B);
    }

    [Fact]
    public void Area()
    {
        var expected = Math.PI * 2;
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b).Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Eccentricity()
    {
        var expected = 0.8660254037844386;
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b).Eccentricity;

        Assert.Equal(expected, actual);
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Traditional mathematical name")]
    public void h()
    {
        var expected = 0.1111111111111111;
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b).h;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PerimeterFast()
    {
        var expected = 9.688448216130086;
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b).PerimeterFast;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Perimeter()
    {
        var expected = 9.688448220506999;
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b).Perimeter;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 1) A = 2, B = 1";
        var c = new Point2double(1, 1);
        var a = 2;
        var b = 1;
        var actual = new Ellipse2double(c, a, b).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EqualsObjectFalse()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 2);

        Assert.False(e1.Equals((object)e2));
    }

    [Fact]
    public void EqualsObjectTrue()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 1);

        Assert.True(e1.Equals((object)e2));
    }

    [Fact]
    public void EqualsEllipse2doubleFalse()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 2);

        Assert.False(e1.Equals(e2));
    }

    [Fact]
    public void EqualsEllipse2doubleTrue()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 1);

        Assert.True(e1.Equals(e2));
    }

    [Fact]
    public void GetHashCodeTest()
    {
        var expected = 2146435072;
        var c = new Point2double(1, 1);
        var actual = new Ellipse2double(c, 2, 1).GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorEqualsFalse()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 2);

        Assert.False(e1 == e2);
    }

    [Fact]
    public void OperatorEqualsTrue()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 1);

        Assert.True(e1 == e2);
    }

    [Fact]
    public void OperatorNotEqualsFalse()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 1);

        Assert.False(e1 != e2);
    }

    [Fact]
    public void OperatorNotEqualsTrue()
    {
        var c = new Point2double(1, 1);
        var e1 = new Ellipse2double(c, 2, 1);
        var e2 = new Ellipse2double(c, 2, 2);

        Assert.True(e1 != e2);
    }
}
