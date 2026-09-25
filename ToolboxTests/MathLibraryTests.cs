using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class MathLibraryTests
{
    [Fact]
    public void BinomialBadParameter()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathLibrary.Binomial(0, 5));
    }

    [Fact]
    public void Binomial()
    {
        var expected = new BigInteger(792);
        var actual = MathLibrary.Binomial(12, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Factorial()
    {
        var expected = BigInteger.Parse("1551118753287382280224243016469303211063259720016986112000000000000");
        var actual = MathLibrary.Factorial(51);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FibonacciNumbers()
    {
        var expected = BigInteger.Parse("222232244629420445529739893461909967206666939096499764990979600");
        var actual = MathLibrary.FibonacciNumbers().Skip(300).First();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsBouncyLongTrue()
    {
        var actual = MathLibrary.IsBouncy(123934);

        Assert.True(actual);
    }

    [Fact]
    public void IsBouncyLongFalse()
    {
        var actual = MathLibrary.IsBouncy(12389);

        Assert.False(actual);
    }

    [Fact]
    public void CycleLengthHasCycle()
    {
        // 1/452 = 0.002212389... repeats with period 112 (452 = 2^2 * 113,
        // and the order of 10 mod 113 is 112). The old implementation counted
        // the pre-period q/r states and returned 115.
        var expected = 112;
        var actual = MathLibrary.CycleLength(1, 452);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthNoCycle()
    {
        var expected = 0;
        var actual = MathLibrary.CycleLength(12, 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthSeven()
    {
        // 1/7 = 0.142857... (length 6, not 7: the leading 0 digit is not part
        // of the repetend).
        var expected = 6;
        var actual = MathLibrary.CycleLength(1, 7);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthTerminating()
    {
        var expected = 0;
        var actual = MathLibrary.CycleLength(1, 4);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthTwelve()
    {
        // 1/12 = 0.08333...: pre-period "08", then a single repeating digit.
        var expected = 1;
        var actual = MathLibrary.CycleLength(1, 12);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthIntegerPartIgnored()
    {
        // 22/7 = 3.142857... has the same repetend as 1/7.
        var expected = 6;
        var actual = MathLibrary.CycleLength(22, 7);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthZeroNumerator()
    {
        var expected = 0;
        var actual = MathLibrary.CycleLength(0, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CycleLengthZeroDenominatorThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathLibrary.CycleLength(1, 0));
    }

    [Fact]
    public void CycleLengthDenominatorWithFive()
    {
        // 1/25 = 0.04 terminates once the factor of 5 is stripped.
        Assert.Equal(0, MathLibrary.CycleLength(1, 25));
        // 1/35 = 0.0285714...: the 5 is stripped, leaving period of 1/7.
        Assert.Equal(6, MathLibrary.CycleLength(1, 35));
    }

    [Fact]
    public void MaximumSubsetSum()
    {
        var expected = 9;
        var actual = MathLibrary.MaximumSubsetSum([1, 4, -6, 2, 3, 4, -3, -4, 6]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsCyclicTrue()
    {
        var actual = MathLibrary.IsCyclic("2034", "3498");

        Assert.True(actual);
    }

    [Fact]
    public void IsCyclicFalse()
    {
        var actual = MathLibrary.IsCyclic("2034", "3598");

        Assert.False(actual);
    }

    [Fact]
    public void IsPalindromeTrue()
    {
        var actual = MathLibrary.IsPalindrome("amanaplanacanalpanama");

        Assert.True(actual);
    }

    [Fact]
    public void IsPalindromeFalse()
    {
        var actual = MathLibrary.IsPalindrome("fred");

        Assert.False(actual);
    }

    [Fact]
    public void PascalsTriangle()
    {
        var expected = new long[] { 1, 5, 10, 10, 5, 1 };
        var actual = MathLibrary.PascalsTriangle().Skip(5).First();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void RadOne()
    {
        var expected = 1;
        var actual = MathLibrary.Rad(1);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Rad()
    {
        var expected = 10;
        var actual = MathLibrary.Rad(50);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CountInBase()
    {
        var expected = new[] { 0L, 1, 2, 10, 11 };
        var actual = MathLibrary.CountInBase(3).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void CountInBaseDecade()
    {
        var expected = Enumerable.Range(0, 20).Select(i => (long)i).ToArray();
        var actual = MathLibrary.CountInBase(10).Take(20);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void CountInBaseBaseTooSmallThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathLibrary.CountInBase(1).ToArray());
    }

    [Fact]
    public void CountInBaseAllBaseTwo()
    {
        // The counter cycles through every c-digit base-2 number and then wraps
        // back to 0; c is chosen so no emitted value exceeds long.MaxValue and
        // none wrap negative (the old hard-coded 19-digit implementation could
        // silently wrap for radix 10).
        var all = MathLibrary.CountInBase(2).Take((1 << 19) + 3).ToArray();

        Assert.Equal((1 << 19) + 3, all.Length);
        Assert.Equal(1111111111111111111L, all[^4]); // (10^19 - 1)/9: last of the first cycle
        Assert.Equal(new[] { 0L, 1, 10 }, all[^3..]); // wraps back to 0 and repeats
        Assert.DoesNotContain(all, v => v < 0);
        Assert.DoesNotContain(all, v => v > long.MaxValue);
    }

    [Fact]
    public void BinomialZeroZero()
    {
        var expected = BigInteger.One;
        var actual = MathLibrary.Binomial(0, 0);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FactorialNegativeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MathLibrary.Factorial(-5));
    }

    [Fact]
    public void IsPalindromeEmpty()
    {
        Assert.True(MathLibrary.IsPalindrome(string.Empty));
    }

    [Fact]
    public void IsPalindromeNullThrows()
    {
        Assert.Throws<ArgumentNullException>(() => MathLibrary.IsPalindrome(null!));
    }

    [Fact]
    public void NumberOfSetBits()
    {
        var expected = 5;
        var actual = MathLibrary.NumberOfSetBits(361);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NewtonsMethod()
    {
        var epsilon = 0.00001;
        var expected = 1.73205;
        var actual = MathLibrary.NewtonsMethod(x => x * x - 3, x => 2 * x, 2, epsilon);

        Assert.Equal(expected, actual, 5);
    }

    [Fact]
    public void NewtonsMethodOutOfRange()
    {
        var epsilon = 0.0005;

        Assert.Throws<OverflowException>(() => MathLibrary.NewtonsMethod(x => 3 - x * x, x => 2 * x, 2, epsilon));
    }
}
