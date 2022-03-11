using ProjectEuler.Toolbox;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class PrimeHelperTests
{
    [Fact]
    public void IsPrimeLessThan2()
    {
        var actual = PrimeHelper.IsPrime(1);

        Assert.False(actual);
    }

    [Fact]
    public void IsPrime2To4()
    {
        var actual = PrimeHelper.IsPrime(3);

        Assert.True(actual);
    }

    [Fact]
    public void IsPrimeOdds4To9()
    {
        var actual = PrimeHelper.IsPrime(7);

        Assert.True(actual);
    }

    [Fact]
    public void IsPrimeEven()
    {
        var actual = PrimeHelper.IsPrime(10);

        Assert.False(actual);
    }

    [Fact]
    public void IsPrimeMultipleOfThree()
    {
        var actual = PrimeHelper.IsPrime(51);

        Assert.False(actual);
    }

    [Fact]
    public void IsPrimeSquare()
    {
        var actual = PrimeHelper.IsPrime(25);

        Assert.False(actual);
    }

    [Fact]
    public void IsPrimePrime()
    {
        var actual = PrimeHelper.IsPrime(8219);

        Assert.True(actual);
    }

    [Fact]
    public void IsPrimeNotPrime()
    {
        var actual = PrimeHelper.IsPrime(8227);

        Assert.False(actual);
    }

    [Fact]
    public void IsPrimeMemoized()
    {
        var actual = PrimeHelper.IsPrimeMemoized(8227);

        Assert.False(actual);
    }

    [Fact]
    public void PrimesRepeatability()
    {
        var primes = PrimeHelper.Primes().Take(20).ToArray();
        var p2 = PrimeHelper.Primes().Take(20).ToArray();

        for (var i = 0; i < p2.Length; i++)
            Assert.Equal(primes[i], p2[i]);
    }

    [Fact]
    public void Primes()
    {
        var expected = 15485863;
        var actual = PrimeHelper.Primes().Skip(1000000 - 1).First();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrimesMax()
    {
        var last = 0L;
        var count = 100000000L;

        try
        {
            foreach (var prime in PrimeHelper.Primes(count))
            {
                last = prime;
                count++;
            }
        }
        catch { };

        Assert.Equal(2147483647, last);
        Assert.Equal(105097565, count);
    }
}
