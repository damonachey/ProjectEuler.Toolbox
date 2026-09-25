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

    [Fact]
    public void LagrangeIntCube()
    {
        // y = x^3 through four points; x = 5 must round-trip to 125.
        // Old per-term int division produced -34.
        var input = new Point2<int>[]
            {
                new(1, 1),
                new(2, 8),
                new(3, 27),
                new(4, 64),
            };
        var expected = 125;
        var actual = Polynomial.Lagrange(input, 5, 1).First().Y;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LagrangeIntNonIntegerValueTruncates()
    {
        // Exact interpolated value at x = 2 is 7/3, which is not integral;
        // the single exact division truncates toward zero.
        var input = new Point2<int>[]
            {
                new(0, 0),
                new(1, 1),
                new(3, 4),
            };
        var expected = 2;
        var actual = Polynomial.Lagrange(input, 2, 1).First().Y;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LagrangeLongSameAsDouble()
    {
        // Quadratic through (0,0),(1,1),(3,4) is x^2/6 + 5x/6; at x = 6 it is 11.
        var input = new Point2<long>[]
            {
                new(0, 0),
                new(1, 1),
                new(3, 4),
            };
        var actual = Polynomial.Lagrange(input, 6, 1).First().Y;

        Assert.Equal(11, actual);
    }

    [Fact]
    public void LagrangeBigIntegerCube()
    {
        var input = new Point2<System.Numerics.BigInteger>[]
            {
                new(1, 1),
                new(2, 8),
                new(3, 27),
                new(4, 64),
            };
        var expected = new System.Numerics.BigInteger(125);
        var actual = Polynomial.Lagrange(input, 5, 1).First().Y;

        Assert.Equal(expected, actual);
    }
}
