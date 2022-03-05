using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Polygon2BigRationalTests
{
    [Fact]
    public void Polygon2BigRationalConstructor()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var actual = new Polygon2BigRational(p1, p2, p3, p4);

        Assert.Equal(p1, actual.P1);
        Assert.Equal(p2, actual.P2);
        Assert.Equal(p3, actual.P3);
        Assert.Equal(p4, actual.P4);
    }

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

    [Fact]
    public void EqualsObjectFalse()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var p5 = new Point2BigRational(9, 10);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

        Assert.False(pol1.Equals((object)pol2));
    }

    [Fact]
    public void EqualsObjectTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

        Assert.True(pol1.Equals((object)pol2));
    }

    [Fact]
    public void EqualsLine2BigRationalFalse()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var p5 = new Point2BigRational(9, 10);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

        Assert.False(pol1.Equals(pol2));
    }

    [Fact]
    public void EqualsLine2BigRationalTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

        Assert.True(pol1.Equals(pol2));
    }

    [Fact]
    public void GetHashCodeTest()
    {
        var expected = 8;
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var actual = new Polygon2BigRational(p1, p2, p3, p4).GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorEqualsFalse()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var p5 = new Point2BigRational(9, 10);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

        Assert.False(pol1 == pol2);
    }

    [Fact]
    public void OperatorEqualsTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

        Assert.True(pol1 == pol2);
    }

    [Fact]
    public void OperatorNotEqualsFalse()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

        Assert.False(pol1 != pol2);
    }

    [Fact]
    public void OperatorNotEqualsTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(3, 4);
        var p3 = new Point2BigRational(5, 6);
        var p4 = new Point2BigRational(7, 8);
        var p5 = new Point2BigRational(9, 10);
        var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
        var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

        Assert.True(pol1 != pol2);
    }
}
