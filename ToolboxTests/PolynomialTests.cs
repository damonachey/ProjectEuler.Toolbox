using ProjectEuler.Toolbox;

using System.Linq;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class PolynomialTests
{
    [Fact]
    public void Lagrange()
    {
        var input = new Point2<double>[]
            {
                new(1, 1),
                new(2, 8),
                new(3, 27),
                new(4, 64),
            };
        var expected = new Point2<double>[]
            {
                new(1, 1),
                new(2, 8),
                new(3, 27),
                new(4, 64),
                new(5, 125),
                new(6, 216),
            };
        var actual = Polynomial
            .Lagrange(input, 1, 1)
            .Take(6)
            .ToArray();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void LagrangeDouble()
    {
        var input = new Point2<double>[]
            {
                new(1, 1),
                new(2, 8),
                new(3, 27),
            };
        var expected = new Point2<double>[]
            {
                new(1.0, 1),
                new(1.5, 3),
                new(2.0, 8),
                new(2.5, 16),
                new(3.0, 27),
            };
        var actual = Polynomial
            .Lagrange(input, 1, 0.5)
            .Take(5)
            .ToArray();

        Assert.True(expected.SequenceEqual(actual));
    }
}
