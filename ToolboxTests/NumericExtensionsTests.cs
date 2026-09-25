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
        var expected = "MMCLIII"; // 2153 — the old one-pass chain produced the non-minimal "MCMCXCXLXIXIV" (13 chars)
        var actual = "DDDCDLLLXLXXXXVVVIVIIII".ReduceRomanNumeral();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReduceRomanNumeralSixI()
    {
        // Old chain: "IIIIII" -> "IVII" (length 4); minimal is "VI".
        var expected = "VI";
        var actual = "IIIIII".ReduceRomanNumeral();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReduceRomanNumeralVIVI()
    {
        // 5 + 4 + 1 = 10; old chain gave "IXI".
        var expected = "X";
        var actual = "VIVI".ReduceRomanNumeral();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReduceRomanNumeralAlreadyMinimal()
    {
        var expected = "MCMXCIX";
        var actual = "MCMXCIX".ReduceRomanNumeral();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReduceRomanNumeralLowercase()
    {
        var expected = "VI";
        var actual = "iiiiii".ReduceRomanNumeral();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReduceRomanNumeralEmpty()
    {
        Assert.Equal(string.Empty, string.Empty.ReduceRomanNumeral());
    }

    [Fact]
    public void ReduceRomanNumeralUnknownCharIgnored()
    {
        var expected = "IV"; // 'J' has no value and is dropped; IIII = 4
        var actual = "IIIIJ".ReduceRomanNumeral();

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
