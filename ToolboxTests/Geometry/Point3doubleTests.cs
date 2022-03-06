using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Point3doubleTests
{
    [Fact]
    public void Point3double()
    {
        var p = new Point3double(1, 2, 3);

        Assert.Equal(1, p.X);
        Assert.Equal(2, p.Y);
        Assert.Equal(3, p.Z);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 2, 3)";
        var p = new Point3double(1, 2, 3);
        var actual = p.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EqualsTest()
    {
        var p = new Point3double(1, 2, 3);

        Assert.False(p.Equals(1));
    }

    [Fact]
    public void Equals2()
    {
        var p1 = new Point3double(1, 2, 3);
        var p2 = new Point3double(1, 2, 3);

        Assert.Equal(p1, p2);
    }

    [Fact]
    public void GetHashCodeTest()
    {
        var expected = 1073217536;
        var p = new Point3double(1, 2, 3);
        var actual = p.GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_Equals()
    {
        var p1 = new Point3double(1, 2, 3);
        var p2 = new Point3double(1, 2, 3);

        Assert.True(p1 == p2);
    }

    [Fact]
    public void Op_NotEquals()
    {
        var p1 = new Point3double(1, 2, 3);
        var p2 = new Point3double(1, 2, 4);

        Assert.True(p1 != p2);
    }
}
