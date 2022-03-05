using ProjectEuler.Toolbox;
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
    public new void ToStringTest()
    {
        var expected = "(1, 1) R = 1";
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EqualsObjectFalse()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 2);

        Assert.False(c1.Equals((object)c2));
    }

    [Fact]
    public void EqualsObjectTrue()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 1);

        Assert.True(c1.Equals((object)c2));
    }

    [Fact]
    public void EqualsCircle2doubleFalse()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 2);

        Assert.False(c1.Equals(c2));
    }

    [Fact]
    public void EqualsCircle2doubleTrue()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 1);

        Assert.True(c1.Equals(c2));
    }

    [Fact]
    public new void GetHashCodeTest()
    {
        var expected = 1072693248;
        var c = new Point2double(1, 1);
        var actual = new Circle2double(c, 1).GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorEqualsFalse()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 2);

        Assert.False(c1 == c2);
    }

    [Fact]
    public void OperatorEqualsTrue()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 1);

        Assert.True(c1 == c2);
    }

    [Fact]
    public void OperatorNotEqualsFalse()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 1);

        Assert.False(c1 != c2);
    }

    [Fact]
    public void OperatorNotEqualsTrue()
    {
        var c = new Point2double(1, 1);
        var c1 = new Circle2double(c, 1);
        var c2 = new Circle2double(c, 2);

        Assert.True(c1 != c2);
    }
}
