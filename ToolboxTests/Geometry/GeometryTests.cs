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
        var actual = Geometry.IsPointInTriangle(
            new(0, 0, 0),
            new(0, 1, 0),
            new(1, -1, 0),
            new(-1, -1, 0));

        Assert.True(actual);
    }

    [Fact]
    public void PointInTriangleFalse()
    {
        var actual = Geometry.IsPointInTriangle(
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
                (6, 8, 10),
                (3, 4, 5),
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
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(4, 6);
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
        var p1 = new Point2double(1, 2);
        var p2 = new Point2double(4, 6);
        var p3 = new Point2double(3, 3);
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
}
