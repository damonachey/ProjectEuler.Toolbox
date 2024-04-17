using System.Numerics;

namespace ProjectEuler.Toolbox;

/// <summary>
/// Class for all factorization functions
/// </summary>
public static class Factorization
{
    /// <summary>
    /// Count the number of factors (divisors) of n
    ///
    /// We begin by writing the number as a product of prime factors: n = (p^a)(q^b)(r^c)...
    /// then the number of divisors, d(n) = (a+1)(b+1)(c+1)...
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int FactorCount(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        var count = 1;

        if (n % 2 == 0)
        {
            var temp = 1;

            while (n % 2 == 0)
            {
                temp++;
                n /= 2;
            }

            count *= temp;
        }

        var factor = 3;
        var maxFactor = Math.Sqrt(n);

        while (n > 1 && factor <= maxFactor)
        {
            if (n % factor == 0)
            {
                var temp = 1;

                while (n % factor == 0)
                {
                    temp++;
                    n /= factor;
                }

                count *= temp;
                maxFactor = Math.Sqrt(n);
            }

            factor += 2;
        }

        if (n != 1)
        {
            count *= 2;
        }

        return count;
    }

    /// <summary>
    /// Return a list of the factors (divisors) of n
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> Factors(int n)
    {
        var factor = (int)Math.Sqrt(n);

        while (factor > 0)
        {
            if (n % factor == 0)
            {
                yield return factor;

                var temp = n / factor;
                if (temp != factor)
                {
                    yield return temp;
                }
            }

            factor--;
        }
    }

    /// <summary>
    /// Return a list of the factors (divisors) of n
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<long> Factors(long n)
    {
        var factor = (long)Math.Sqrt(n);

        while (factor > 0)
        {
            if (n % factor == 0)
            {
                yield return factor;

                var temp = n / factor;
                if (temp != factor)
                {
                    yield return temp;
                }
            }

            factor--;
        }
    }

    /// <summary>
    /// Return a list of the factors (divisors) of n
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<BigInteger> Factors(BigInteger n)
    {
        var factor = PowersAndRoots.SqrtFloor(n);

        while (factor > 0)
        {
            if (n % factor == 0)
            {
                yield return factor;

                var temp = n / factor;
                if (temp != factor)
                {
                    yield return temp;
                }
            }

            factor--;
        }
    }

    /// <summary>
    /// Return a list of the prime factors (divisors) of n
    ///
    /// Will return all prime factors, including repeats i.e. 12 => { 2, 2, 3 }
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> PrimeFactors(int n)
    {
        if (n == 0)
        {
            yield break;
        }

        while (n % 2 == 0)
        {
            yield return 2;
            n /= 2;
        }

        var factor = 3;
        var maxFactor = Math.Sqrt(n);

        while (factor <= maxFactor)
        {
            if (n % factor == 0)
            {
                while (n % factor == 0)
                {
                    yield return factor;
                    n /= factor;
                }

                maxFactor = Math.Sqrt(n);
            }

            factor += 2;
        }

        if (n != 1)
        {
            yield return n;
        }
    }

    /// <summary>
    /// Return a list of the prime factors (divisors) of n
    ///
    /// Will return all prime factors, including repeats i.e. 12 => { 2, 2, 3 }
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<long> PrimeFactors(long n)
    {
        if (n == 0)
        {
            yield break;
        }

        while (n % 2 == 0)
        {
            yield return 2;
            n /= 2;
        }

        var factor = 3;
        var maxFactor = Math.Sqrt(n);

        while (n > 1 && factor <= maxFactor)
        {
            if (n % factor == 0)
            {
                while (n % factor == 0)
                {
                    yield return factor;
                    n /= factor;
                }

                maxFactor = Math.Sqrt(n);
            }

            factor += 2;
        }

        if (n != 1)
        {
            yield return n;
        }
    }

    /// <summary>
    /// Return a list of the prime factors (divisors) of n
    ///
    /// Will return all prime factors, including repeats i.e. 12 => { 2, 2, 3 }
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<BigInteger> PrimeFactors(BigInteger n)
    {
        if (n == 0)
        {
            yield break;
        }

        while (n % 2 == 0)
        {
            yield return 2;
            n /= 2;
        }

        var factor = 3;
        var maxFactor = PowersAndRoots.SqrtFloor(n);

        while (n > 1 && factor <= maxFactor)
        {
            if (n % factor == 0)
            {
                while (n % factor == 0)
                {
                    yield return factor;
                    n /= factor;
                }

                maxFactor = PowersAndRoots.SqrtFloor(n);
            }

            factor += 2;
        }

        if (n != 1)
        {
            yield return n;
        }
    }

    /// <summary>
    /// Compute the greatest common divisor of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int GreatestCommonDivisor(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }

        return a != 0 ? a : b;
    }

    /// <summary>
    /// Compute the greatest common divisor of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long GreatestCommonDivisor(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }

        return a != 0 ? a : b;
    }

    /// <summary>
    /// Compute the least common multiple of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int LeastCommonMultiple(int a, int b)
    {
        ArgumentOutOfRangeException.ThrowIfZero(a);

        a = Math.Abs(a);
        b = Math.Abs(b);

        return a * (b / GreatestCommonDivisor(a, b));
    }

    /// <summary>
    /// Compute the least common multiple of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long LeastCommonMultiple(long a, long b)
    {
        ArgumentOutOfRangeException.ThrowIfZero(a);

        a = Math.Abs(a);
        b = Math.Abs(b);

        return a * (b / GreatestCommonDivisor(a, b));
    }

    /// <summary>
    /// Compute the least common multiple of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static BigInteger LeastCommonMultiple(BigInteger a, BigInteger b)
    {
        ArgumentOutOfRangeException.ThrowIfZero(a);

        a = BigInteger.Abs(a);
        b = BigInteger.Abs(b);

        return a * (b / BigInteger.GreatestCommonDivisor(a, b));
    }
}
