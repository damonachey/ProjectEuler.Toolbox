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
}
