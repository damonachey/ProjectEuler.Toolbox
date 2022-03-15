using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Circle2ExtensionsTests
{
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
        var expected = 1.1416;
        var actual = Circle2Extensions.SegmentArea(Math.PI / 2, 2);

        Assert.Equal(expected, actual, 4);
    }
}
