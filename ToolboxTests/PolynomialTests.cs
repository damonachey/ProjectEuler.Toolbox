using ProjectEuler.Toolbox;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class PolynomialTests
{
    [Fact]
    public void Lagrange()
    {
        var input = new Point2double[]
            {
                new Point2double(1, 1),
                new Point2double(2, 8),
                new Point2double(3, 27),
                new Point2double(4, 64),
            };
        var expected = new Point2double[]
            {
                new Point2double(1, 1),
                new Point2double(2, 8),
                new Point2double(3, 27),
                new Point2double(4, 64),
                new Point2double(5, 125),
                new Point2double(6, 216),
            };
        var actual = Polynomial
            .Lagrange(input, 1, 1)
            .Take(6)
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void LagrangeDouble()
    {
        var input = new Point2double[]
            {
                new Point2double(1, 1),
                new Point2double(2, 8),
                new Point2double(3, 27),
            };
        var expected = new Point2double[]
            {
                new Point2double(1.0, 1),
                new Point2double(1.5, 3),
                new Point2double(2.0, 8),
                new Point2double(2.5, 16),
                new Point2double(3.0, 27),
            };
        var actual = Polynomial
            .Lagrange(input, 1, 0.5)
            .Take(5)
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
    }
}
