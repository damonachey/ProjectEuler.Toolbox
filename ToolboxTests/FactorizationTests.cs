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
    public void GCDInt()
    {
        var expected = 4;
        var actual = Factorization.GCD(412, 612);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GCDLong()
    {
        var expected = 4;
        var actual = Factorization.GCD(412L, 612L);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LCMIntArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LCM(0, 5));
    }

    [Fact]
    public void LCMLongArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LCM(0L, 5));
    }

    [Fact]
    public void LCMBigIntegerArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.LCM(BigInteger.Zero, 5));
    }

    [Fact]
    public void LCMInt()
    {
        var expected = 336;
        var actual = Factorization.LCM(42, 16);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LCMLong()
    {
        var expected = 336;
        var actual = Factorization.LCM(42L, 16L);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LCMBigInteger()
    {
        var expected = new BigInteger(336);
        var actual = Factorization.LCM(new BigInteger(42), 16L);

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
