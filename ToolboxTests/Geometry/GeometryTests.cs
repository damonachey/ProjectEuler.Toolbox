using ProjectEuler.Toolbox;
using System;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class GeometryTests
{
    [Fact]
    public void Diamonds()
    {
        var expected = 3669546;
        var actual = Geometry.Diamonds(77, 36);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PointInTriangleTrue()
    {
        var actual = Geometry.IsPointInTriangle<double>(
            new(0, 0, 0),
            new(0, 1, 0),
            new(1, -1, 0),
            new(-1, -1, 0));

        Assert.True(actual);
    }

    [Fact]
    public void PointInTriangleFalse()
    {
        var actual = Geometry.IsPointInTriangle<double>(
            new(2, 0, 0),
            new(0, 1, 0),
            new(1, -1, 0),
            new(-1, -1, 0));

        Assert.False(actual);
    }

    [Fact]
    public void PythagoreanTriples()
    {
        var expected = new[]
            {
                (3, 4, 5),
                (6, 8, 10),
                (9, 12, 15),
                (8, 15, 17),
                (5, 12, 13),
            };

        var actual = Geometry.PythagoreanTriples(42);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void DistanceDouble()
    {
        var expected = 5;
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(4, 6);
        var actual = Geometry.Distance(p1, p2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DistanceBigRational()
    {
        var expected = new BigRational(5);
        var p1 = new Point2BigRational(1, 2);
        var p2 = new Point2BigRational(4, 6);
        var actual = Geometry.Distance(p1, p2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Side()
    {
        var expected = -5;
        var p1 = new Point2<double>(1, 2);
        var p2 = new Point2<double>(4, 6);
        var p3 = new Point2<double>(3, 3);
        var actual = Geometry.Side(p1, p2, p3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Rectangles()
    {
        var expected = 1999998;
        var actual = Geometry.Rectangles(77, 36);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RectanglesLargeInputsNoIntOverflow()
    {
        // 50000² exceeds int.MaxValue: the old int-arithmetic closed form wrapped.
        var expected = 1562562500625000000L;
        var actual = Geometry.Rectangles(50000, 50000);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RectanglesResultBeyondLongThrows()
    {
        Assert.Throws<System.OverflowException>(() => Geometry.Rectangles(int.MaxValue, int.MaxValue));
    }

    [Fact]
    public void TriangleThirdPoint345()
    {
        var actual = Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 3, new Point2<double>(5, 0), 4);

        Assert.Equal(1.8, actual.X, 12);
        Assert.Equal(2.4, actual.Y, 12);
    }

    [Fact]
    public void TriangleThirdPointNegativeBase()
    {
        var actual = Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 3, new Point2<double>(-5, 0), 4);

        Assert.Equal(-1.8, actual.X, 12);
        Assert.Equal(2.4, actual.Y, 12);
    }

    [Fact]
    public void TriangleThirdPointDegenerate()
    {
        var actual = Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 2, new Point2<double>(5, 0), 3);

        Assert.Equal(2, actual.X, 12);
        Assert.Equal(0, actual.Y, 12);
    }

    [Fact]
    public void TriangleThirdPointInvalidThrows()
    {
        // base 5 is longer than ba + ca = 2: no such triangle exists.
        Assert.Throws<ArgumentException>(() => Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 1, new Point2<double>(5, 0), 1));
    }

    [Fact]
    public void TriangleThirdPointNegativeSideThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Geometry.TriangleThirdPoint(new Point2<double>(0, 0), -1, new Point2<double>(5, 0), 4));
        Assert.Throws<ArgumentOutOfRangeException>(() => Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 3, new Point2<double>(5, 0), -1));
    }

    [Fact]
    public void TriangleThirdPointBNotOriginThrows()
    {
        Assert.Throws<ArgumentException>(() => Geometry.TriangleThirdPoint(new Point2<double>(1, 0), 3, new Point2<double>(5, 0), 4));
    }

    [Fact]
    public void TriangleThirdPointCNotOnAxisThrows()
    {
        Assert.Throws<ArgumentException>(() => Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 3, new Point2<double>(5, 1), 4));
    }

    [Fact]
    public void TriangleThirdPointCAtOriginThrows()
    {
        Assert.Throws<ArgumentException>(() => Geometry.TriangleThirdPoint(new Point2<double>(0, 0), 3, new Point2<double>(0, 0), 4));
    }

    [Fact]
    public void TriangleInscribedCircleRadius()
    {
        // 3-4-5 triangle has inradius 1.
        var expected = 1.0;
        var actual = Geometry.TriangleInscribedCircleRadius(3, 4, 5);

        Assert.Equal(expected, actual, 12);
    }
}
