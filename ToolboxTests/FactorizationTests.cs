using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class FactorizationTests
{
    [Fact]
    public void FactorCountZero()
    {
        var expected = 0;
        var actual = Factorization.FactorCount(0);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FactorCount()
    {
        var expected = 12;
        var actual = Factorization.FactorCount(90);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FactorsInt()
    {

        var expected = new int[] { 1, 2, 4, 103, 206, 412 };
        var actual = Factorization.Factors(412);

        Assert.True(expected.OrderBy(sequence => sequence).SequenceEqual(actual.OrderBy(sequence => sequence)));
    }

    [Fact]
    public void FactorsLong()
    {
        var expected = new long[] { 1, 2, 4, 103, 206, 412 };
        var actual = Factorization.Factors(412L);

        Assert.True(expected.OrderBy(sequence => sequence).SequenceEqual(actual.OrderBy(sequence => sequence)));
    }

    [Fact]
    public void FactorsBigInteger()
    {
        var expected = new BigInteger[] { 1, 2, 4, 103, 206, 412 };
        var actual = Factorization.Factors(new BigInteger(412));

        Assert.True(expected.OrderBy(sequence => sequence).SequenceEqual(actual.OrderBy(sequence => sequence)));
    }

    [Fact]
    public void FactorsBigIntegerPrime()
    {
        var expected = 2;
        var actual = Factorization.Factors(new BigInteger(112272535095293)).Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FactorsBigIntegerNonPrime()
    {
        var expected = 32;
        var actual = Factorization.Factors(new BigInteger(6546235646418)).Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreatestCommonDivisorInt()
    {
        var expected = 4;
        var actual = Factorization.GreatestCommonDivisor(412, 612);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreatestCommonDivisorLong()
    {
        var expected = 4;
        var actual = Factorization.GreatestCommonDivisor(412L, 612L);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeastCommonMultipleIntArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LeastCommonMultiple(0, 5));
    }

    [Fact]
    public void LeastCommonMultipleLongArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LeastCommonMultiple(0L, 5));
    }

    [Fact]
    public void LeastCommonMultipleBigIntegerArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LeastCommonMultiple(BigInteger.Zero, 5));
    }

    [Fact]
    public void LeastCommonMultipleInt()
    {
        var expected = 336;
        var actual = Factorization.LeastCommonMultiple(42, 16);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeastCommonMultipleLong()
    {
        var expected = 336;
        var actual = Factorization.LeastCommonMultiple(42L, 16L);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeastCommonMultipleBigInteger()
    {
        var expected = new BigInteger(336);
        var actual = Factorization.LeastCommonMultiple(new BigInteger(42), 16L);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrimeFactorsIntZero()
    {
        var expected = new int[] { };
        var actual = Factorization.PrimeFactors(0);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void PrimeFactorsInt()
    {
        var expected = new int[] { 2, 2, 5, 103 };
        var actual = Factorization.PrimeFactors(2060);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void PrimeFactorsLongZero()
    {
        var expected = new long[] { };
        var actual = Factorization.PrimeFactors(0L);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void PrimeFactorsLong()
    {
        var expected = new long[] { 2, 2, 5, 103 };
        var actual = Factorization.PrimeFactors(2060L);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void PrimeFactorsBigIntegerZero()
    {
        var expected = new BigInteger[] { };
        var actual = Factorization.PrimeFactors(BigInteger.Zero);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void PrimeFactorsBigInteger()
    {
        var expected = new BigInteger[] { 2, 3, 13, 163, 514884037 };
        var actual = Factorization.PrimeFactors(new BigInteger(6546235646418));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void PrimeFactorsPrime()
    {
        var expected = 1;
        var actual = Factorization.PrimeFactors(112272535095293).Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrimeFactorsNonPrime()
    {
        var expected = 5;
        var actual = Factorization.PrimeFactors(6546235646418).Count();

        Assert.Equal(expected, actual);
    }
}
