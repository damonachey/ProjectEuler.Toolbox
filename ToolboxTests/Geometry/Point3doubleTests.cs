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
}
