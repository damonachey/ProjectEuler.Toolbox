using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Point2BigRationalTests
{
    [Fact]
    public void Point2BigRationalConstructor()
    {
        var p = new Point2BigRational(1, 2);

        Assert.Equal(1, p.X);
        Assert.Equal(2, p.Y);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 2)";
        var p = new Point2BigRational(1, 2);
        var actual = p.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EqualsObjectFalse()
    {
        var p = new Point2BigRational(1, 2);

        Assert.False(p.Equals(1));
    }

    [Fact]
    public void EqualsObjectFalse2()
    {
        var p1 = new Point2BigRational(2, 2);
        var p2 = new Point2BigRational(1, 2);

        Assert.False(p1.Equals((object)p2));
    }

    [Fact]
    public void EqualsObjectTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(1, 2);

        Assert.True(p1.Equals((object)p2));
    }

    [Fact]
    public void EqualsPoint2BigRationalFalse()
    {
        var p1 = new Point2BigRational(2, 2);
        var p2 = new Point2BigRational(1, 2);

        Assert.False(p1.Equals(p2));
    }

    [Fact]
    public void EqualsPoint2BigRationalTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(1, 2);

        Assert.True(p1.Equals(p2));
    }

    [Fact]
    public void GetHashCodeTest()
    {
        var expected = 3;
        var p = new Point2BigRational(1, 2);
        var actual = p.GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorEqualsFalse()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(1, 3);

        Assert.False(p1 == p2);
    }

    [Fact]
    public void OperatorEqualsTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(1, 2);

        Assert.True(p1 == p2);
    }

    [Fact]
    public void OperatorNotEqualsFalse()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(1, 2);

        Assert.False(p1 != p2);
    }

    [Fact]
    public void OperatorNotEqualsTrue()
    {
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(1, 3);

        Assert.True(p1 != p2);
    }
}
