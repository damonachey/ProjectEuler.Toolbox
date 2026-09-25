using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Triangle2ExtensionsTests
{
    [Fact]
    public void AreaDouble()
    {
        var expected = 1.5;
        var p1 = new Point2<double>(0, 0);
        var p2 = new Point2<double>(1, 1);
        var p3 = new Point2<double>(3, 0);
        var actual = new Triangle2<double>(p1, p2, p3).Area();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AreaDoubleHalfUnit()
    {
        // lattice triangle with a half-integer area
        var expected = 0.5;
        var p1 = new Point2<double>(0, 0);
        var p2 = new Point2<double>(1, 1);
        var p3 = new Point2<double>(0, 1);
        var actual = new Triangle2<double>(p1, p2, p3).Area();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AreaIntExact()
    {
        var expected = 6;
        var p1 = new Point2<int>(0, 0);
        var p2 = new Point2<int>(3, 0);
        var p3 = new Point2<int>(0, 4);
        var actual = new Triangle2<int>(p1, p2, p3).Area();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AreaIntTruncatesHalf()
    {
        // The half-integer area is not representable as an int, so Area truncates.
        var expected = 0;
        var p1 = new Point2<int>(0, 0);
        var p2 = new Point2<int>(1, 1);
        var p3 = new Point2<int>(0, 1);
        var actual = new Triangle2<int>(p1, p2, p3).Area();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubledAreaIntExact()
    {
        var expected = 1;
        var p1 = new Point2<int>(0, 0);
        var p2 = new Point2<int>(1, 1);
        var p3 = new Point2<int>(0, 1);
        var actual = new Triangle2<int>(p1, p2, p3).DoubledArea();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubledAreaLong()
    {
        var expected = 3000000000L;
        var p1 = new Point2<long>(0, 0);
        var p2 = new Point2<long>(1000000000, 1000000000);
        var p3 = new Point2<long>(0, 3);
        var actual = new Triangle2<long>(p1, p2, p3).DoubledArea();

        Assert.Equal(expected, actual);
    }
}