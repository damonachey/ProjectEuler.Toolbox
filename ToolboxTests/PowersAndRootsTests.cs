using ProjectEuler.Toolbox;
using System;
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
        var actual = PowersAndRoots.IsPerfectSquare(9223372036854775808);

        Assert.False(actual);
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
