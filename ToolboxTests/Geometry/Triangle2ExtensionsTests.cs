using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Triangle2ExtensionsTests
{
    [Fact]
    public void Area()
    {
        var expected = 1.5;
        var p1 = new Point2<double>(0, 0);
        var p2 = new Point2<double>(1, 1);
        var p3 = new Point2<double>(3, 0);
        var actual = new Triangle2<double>(p1, p2, p3).Area();

        Assert.Equal(expected, actual);
    }
}
