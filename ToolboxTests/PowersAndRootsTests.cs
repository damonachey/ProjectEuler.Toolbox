using ProjectEuler.Toolbox;
using System;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class PowersAndRootsTests
{
    [Fact]
    public void IsPerfectSquareFalse()
    {
        var actual = PowersAndRoots.IsPerfectSquare(9223372036854775807);

        Assert.False(actual);
    }

    [Fact]
    public void IsPerfectSquareFalse2()
    {
        var actual = PowersAndRoots.IsPerfectSquare(24);

        Assert.False(actual);
    }

    [Fact]
    public void IsPerfectSquareTrue()
    {
        // 3037000499 = floor(sqrt(long.MaxValue)); its square fits in a long,
        // so this exercises the long overload's upper boundary.
        var actual = PowersAndRoots.IsPerfectSquare(3037000499L * 3037000499L);

        Assert.True(actual);
    }

    [Fact]
    public void IsPerfectSquareBigIntegerTrue()
    {
        var actual = PowersAndRoots.IsPerfectSquare(BigInteger.Parse("119395365954817634641176944193187475791716"));

        Assert.True(actual);
    }

    [Fact]
    public void IsPerfectSquareBigIntegerFalse()
    {
        var actual = PowersAndRoots.IsPerfectSquare(BigInteger.Parse("119395365954817634641176944193187475791715"));

        Assert.False(actual);
    }

    [Fact]
    public void IsPerfectSquareBigIntegerFalse2()
    {
        var actual = PowersAndRoots.IsPerfectSquare(new BigInteger(24));

        Assert.False(actual);
    }

    [Fact]
    public void IsPerfectSquareZero()
    {
        var actual = PowersAndRoots.IsPerfectSquare(0);

        Assert.True(actual);
    }

    [Fact]
    public void IsPerfectSquareOne()
    {
        var actual = PowersAndRoots.IsPerfectSquare(1);

        Assert.True(actual);
    }

    [Fact]
    public void IsPerfectSquareNegative()
    {
        var actual = PowersAndRoots.IsPerfectSquare(-4);

        Assert.False(actual);
    }

    [Fact]
    public void IsPerfectSquareBigIntegerZero()
    {
        var actual = PowersAndRoots.IsPerfectSquare(BigInteger.Zero);

        Assert.True(actual);
    }

    [Fact]
    public void IsPerfectSquareBigIntegerOne()
    {
        var actual = PowersAndRoots.IsPerfectSquare(new BigInteger(1));

        Assert.True(actual);
    }

    [Fact]
    public void IsPerfectSquareBigIntegerNegative()
    {
        var actual = PowersAndRoots.IsPerfectSquare(new BigInteger(-4));

        Assert.False(actual);
    }

    [Fact]
    public void SqrtFloor()
    {
        var expected = new BigInteger(35130);
        var actual = PowersAndRoots.SqrtFloor(1234134534);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtFloorZero()
    {
        var expected = BigInteger.Zero;
        var actual = PowersAndRoots.SqrtFloor(BigInteger.Zero);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtFloorNegative()
    {
        Assert.Throws<ArithmeticException>(() => PowersAndRoots.SqrtFloor(BigInteger.MinusOne));
    }

    [Fact]
    public void SqrtIrrational()
    {
        var expected = 1.4142135623730950488016887242m;
        var actual = PowersAndRoots.Sqrt(2m);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtLargeNonSquareTerminates()
    {
        // The old loop never terminated on this value: decimal rounding made
        // the Newton iterate oscillate forever between two adjacent values
        // (a two-cycle) instead of reaching an exact fixed point.
        var expected = 200000000000000.00000000000001m;
        var actual = PowersAndRoots.Sqrt(40000000000000000000000000003m);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtSweepStaysCloseToRoot()
    {
        var values = new List<decimal>();

        for (var i = 2; i <= 200; i++)
        {
            values.Add(i);
        }

        for (var i = 1; i <= 20; i++)
        {
            values.Add(i * 0.5m);
        }

        values.Add(100000000000m);
        values.Add(10000000000000000000000000000m);
        values.Add(40000000000000000000000000003m);

        foreach (var n in values)
        {
            var actual = PowersAndRoots.Sqrt(n);
            var error = Math.Abs(actual * actual - n);

            Assert.True(error <= Math.Max(0.00000000000000000001m, n * 0.00000000000000000001m), $"Sqrt({n}) is off by {error}");
        }
    }

    [Fact]
    public void SqrtSquare()
    {
        var expected = 4;
        var actual = PowersAndRoots.Sqrt(16m);

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void SqrtZero()
    {
        var expected = 0;
        var actual = PowersAndRoots.Sqrt(0);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtDecimalNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => PowersAndRoots.Sqrt(-2));
    }
}
