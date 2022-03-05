using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Triangle2doubleTests
{
    [Fact]
    public void Triangle2doubleConstructor()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var actual = new Triangle2double(p1, p2, p3);

        Assert.Equal(p1, actual.P1);
        Assert.Equal(p2, actual.P2);
        Assert.Equal(p3, actual.P3);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "((1, 2), (3, 4), (5, 6))";
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var actual = new Triangle2double(p1, p2, p3).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EqualsObjectFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var p4 = new Point2double(7, 8);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p4);

        Assert.False(t1.Equals((object)t2));
    }

    [Fact]
    public void EqualsObjectTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p3);

        Assert.True(t1.Equals((object)t2));
    }

    [Fact]
    public void EqualsTriangle2doubleFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var p4 = new Point2double(7, 8);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p4);

        Assert.False(t1.Equals(t2));
    }

    [Fact]
    public void EqualsTriangle2doubleTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p3);

        Assert.True(t1.Equals(t2));
    }

    [Fact]
    public void GetHashCodeTest()
    {
        var expected = 2145648640;
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var actual = new Triangle2double(p1, p2, p3).GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorEqualsFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var p4 = new Point2double(7, 8);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p4);

        Assert.False(t1 == t2);
    }

    [Fact]
    public void OperatorEqualsTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p3);

        Assert.True(t1 == t2);
    }

    [Fact]
    public void OperatorNotEqualsFalse()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p3);

        Assert.False(t1 != t2);
    }

    [Fact]
    public void OperatorNotEqualsTrue()
    {
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(3, 4);
        var p3 = new Point2double(5, 6);
        var p4 = new Point2double(7, 8);
        var t1 = new Triangle2double(p1, p2, p3);
        var t2 = new Triangle2double(p1, p2, p4);

        Assert.True(t1 != t2);
    }
}
