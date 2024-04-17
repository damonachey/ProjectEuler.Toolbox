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
        var expected = 115;
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
