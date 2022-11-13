using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class NumericExtensionsTests
{
    [Fact]
    public void ReduceRomanNumeral()
    {
        var expected = "MCMCXCXLXIXIV";
        var actual = "DDDCDLLLXLXXXXVVVIVIIII".ReduceRomanNumeral();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReverseInt()
    {

        var expected = 321;
        var actual = 123.ReverseDigits();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReverseLong()
    {
        var expected = 321;
        var actual = 123L.ReverseDigits();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReverseBigInteger()
    {
        var expected = new BigInteger(321);
        var actual = new BigInteger(123).ReverseDigits();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDigitsInt()
    {
        var expected = new int[] { 4, 3, 2, 1 };
        var actual = 1234.ToDigits();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ToDigitsLong()
    {
        var expected = new long[] { 4, 3, 2, 1 };
        var actual = 1234L.ToDigits();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ToDigitsBigInteger()
    {
        var expected = new BigInteger[] { 4, 3, 2, 1 };
        var actual = new BigInteger(1234).ToDigits();

        Assert.True(expected.SequenceEqual(actual));
    }
}
