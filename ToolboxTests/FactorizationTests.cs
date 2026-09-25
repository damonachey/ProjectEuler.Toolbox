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
        var expected = Array.Empty<int>();
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
        var expected = Array.Empty<long>();
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
        var expected = Array.Empty<BigInteger>();
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

    [Fact]
    public void PrimeFactorsIntNegative()
    {
        // Old code yielded [2, 2, 2, -1] for -8; prime factorization is only
        // defined for positive integers.
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.PrimeFactors(-8).ToArray());
    }

    [Fact]
    public void PrimeFactorsLongNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.PrimeFactors(-8L).ToArray());
    }

    [Fact]
    public void PrimeFactorsBigIntegerNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.PrimeFactors(new BigInteger(-8)).ToArray());
    }

    [Fact]
    public void FactorCountNegative()
    {
        // Old code returned 4 for -2 (= 2^1); d(2) = 2.
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.FactorCount(-2));
    }

    [Fact]
    public void FactorsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.Factors(-412).ToArray());
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.Factors(-412L).ToArray());
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorization.Factors(new BigInteger(-412)).ToArray());
    }

    [Fact]
    public void GreatestCommonDivisorIntMinValue()
    {
        // Math.Abs(int.MinValue) used to throw even though gcd(-2^31, 4) = 4.
        var expected = 4;
        var actual = Factorization.GreatestCommonDivisor(int.MinValue, 4);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreatestCommonDivisorLongMinValue()
    {
        var expected = 8L;
        var actual = Factorization.GreatestCommonDivisor(long.MinValue, 8L);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreatestCommonDivisorIntMinValueZeroThrows()
    {
        // |gcd(-2^31, 0)| = 2^31 is not representable as an int.
        Assert.Throws<OverflowException>(() => Factorization.GreatestCommonDivisor(int.MinValue, 0));
    }

    [Fact]
    public void GreatestCommonDivisorLongMinValueZeroThrows()
    {
        Assert.Throws<OverflowException>(() => Factorization.GreatestCommonDivisor(long.MinValue, 0L));
    }

    [Fact]
    public void GreatestCommonDivisorNegative()
    {
        var expected = 6;
        var actual = Factorization.GreatestCommonDivisor(-48, 18);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeastCommonMultipleIntOverflow()
    {
        // 65537 * 32768 = 2147549184 > int.MaxValue; old code silently
        // wrapped to a negative value.
        Assert.Throws<OverflowException>(() => Factorization.LeastCommonMultiple(65537, 32768));
    }

    [Fact]
    public void LeastCommonMultipleIntMinValueOverflow()
    {
        Assert.Throws<OverflowException>(() => Factorization.LeastCommonMultiple(int.MinValue, 1));
    }

    [Fact]
    public void LeastCommonMultipleLongOverflow()
    {
        Assert.Throws<OverflowException>(() => Factorization.LeastCommonMultiple(long.MaxValue, 2L));
    }

    [Fact]
    public void LeastCommonMultipleNegative()
    {
        var expected = 336;
        var actual = Factorization.LeastCommonMultiple(-42, 16);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LeastCommonMultipleLongZero()
    {
        // Math convention: lcm(a, 0) = 0.
        var expected = 0L;
        var actual = Factorization.LeastCommonMultiple(5L, 0L);

        Assert.Equal(expected, actual);
    }
}
