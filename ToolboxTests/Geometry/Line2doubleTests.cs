using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Line2doubleTests
{
    [Fact]
    public void Line2doubleConstructorPointPoint()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var actual = new Line2double(p1, p2);

        Assert.Equal(p1, actual.P1);
        Assert.Equal(p2, actual.P2);
    }

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

        Assert.Throws<ArgumentOutOfRangeException>(() => new Line2double(p1, slope));
    }

    [Fact]
    public new void ToStringTest()
    {
        var expected = "((1, 2), (3, 4))";
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var actual = new Line2double(p1, p2).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EqualsObjectFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 5);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p3);

        Assert.False(l1.Equals((object)l2));
    }

    [Fact]
    public void EqualsObjectTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p2);

        Assert.True(l1.Equals((object)l2));
    }

    [Fact]
    public void EqualsLine2doubleFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 5);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p3);

        Assert.False(l1.Equals(l2));
    }

    [Fact]
    public void EqualsLine2doubleTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p2);

        Assert.True(l1.Equals(l2));
    }

    [Fact]
    public new void GetHashCodeTest()
    {
        var expected = 2145910784;
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var actual = new Line2double(p1, p2).GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorEqualsFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 5);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p3);

        Assert.False(l1 == l2);
    }

    [Fact]
    public void OperatorEqualsTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p2);

        Assert.True(l1 == l2);
    }

    [Fact]
    public void OperatorNotEqualsFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p2);

        Assert.False(l1 != l2);
    }

    [Fact]
    public void OperatorNotEqualsTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 5);
        var l1 = new Line2double(p1, p2);
        var l2 = new Line2double(p1, p3);

        Assert.True(l1 != l2);
    }
}
