using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Point3ExtensionsTests
{
    [Fact]
    public void Cross()
    {
        var expected = new Point3double(-1, 2, -1);
        var p1 = new Point3double(1, 2, 3);
        var p2 = new Point3double(2, 3, 4);
        var actual = p1.Cross(p2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Dot()
    {
        var expected = 20;
        var p1 = new Point3double(1, 2, 3);
        var p2 = new Point3double(2, 3, 4);
        var actual = p1.Dot(p2);

        Assert.Equal(expected, actual);
    }
}
