using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Circle2ExtensionsTests
{
    [Fact]
    public void Area()
    {
        var expected = Math.PI;
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r).Area();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Circumfrence()
    {
        var expected = 2 * Math.PI;
        var c = new Point2double(1, 1);
        var r = 1;
        var actual = new Circle2double(c, r).Circumfrence();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ChordAngle()
    {
        var expected = 1.047;
        var actual = Circle2Extensions.ChordAngle(2, 2);

        Assert.Equal(expected, actual, 3);
    }

    [Fact]
    public void SegmentArea()
    {
        var expected = 1.141;
        var actual = Circle2Extensions.SegmentArea(Math.PI / 2, 2);

        Assert.Equal(expected, actual, 3);
    }
}
