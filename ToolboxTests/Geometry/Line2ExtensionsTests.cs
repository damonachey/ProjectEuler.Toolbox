using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Line2ExtensionsTests
{
    [Fact]
    public void Slope()
    {
        var expected = 0.5;
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(0, 1.5);
        var actual = new Line2<double>(p1, p2).Slope();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void YInterceptLine()
    {
        var expected = 0.5;
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(3, 5);
        var actual = new Line2<double>(p1, p2).YIntercept();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void YInterceptPointSlope()
    {
        var expected = 1.5;
        var p = new Point2<double>(1, 2);
        var actual = p.YIntercept(0.5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Length()
    {
        var expected = 3.605551;
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(3, 5);
        var actual = new Line2<double>(p1, p2).Length();

        Assert.Equal(expected, actual, 6);
    }

    [Fact]
    public void IntersectsFalse()
    {
        var expected = default(Point2<double>);
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(3, 4);
        var line1 = new Line2<double>(p1, p2);

        var p3 = new Point2<double>(2, 2);
        var p4 = new Point2<double>(4, 3);
        var line2 = new Line2<double>(p3, p4);

        var actual = line1.Intersects(line2, out Point2<double> p);

        Assert.False(actual);
        Assert.Equal(expected, p);
    }

    [Fact]
    public void IntersectsTrue()
    {
        var expected = new Point2<double>(1, 3);
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(1, 4);
        var line1 = new Line2<double>(p1, p2);

        var p3 = new Point2<double>(0, 3);
        var p4 = new Point2<double>(2, 3);
        var line2 = new Line2<double>(p3, p4);

        var actual = line1.Intersects(line2, out Point2<double> p);

        Assert.True(actual);
        Assert.Equal(expected, p);
    }

    [Fact]
    public void ReflectPoint()
    {
        var expected = new Point2<double>(0.2, 2.6);
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(0, 1.5);
        var p3 = new Point2<double>(1, 1);
        var actual = new Line2<double>(p1, p2).ReflectPoint(p3);

        Assert.Equal(expected.X, actual.X, 15);
        Assert.Equal(expected.Y, actual.Y);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "((1, 2), (3, 4))";
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(3, 4);
        var actual = new Line2<double>(p1, p2).ToString();

        Assert.Equal(expected, actual);
    }
}
