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

        ArgumentOutOfRangeException.ThrowIfNegative(n);

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
        ArgumentOutOfRangeException.ThrowIfNegative(n);

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
        ArgumentOutOfRangeException.ThrowIfNegative(n);

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
        ArgumentOutOfRangeException.ThrowIfNegative(n);

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

        ArgumentOutOfRangeException.ThrowIfNegative(n);

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

        ArgumentOutOfRangeException.ThrowIfNegative(n);

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

        ArgumentOutOfRangeException.ThrowIfNegative(n);

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
        // Compute in long: the absolute value of int.MinValue is not
        // representable as an int, but fits in a long.
        var gcd = GreatestCommonDivisor((long)a, (long)b);

        if (gcd > int.MaxValue)
        {
            throw new OverflowException("The greatest common divisor exceeds Int32.MaxValue.");
        }

        return (int)gcd;
    }

    /// <summary>
    /// Compute the greatest common divisor of a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long GreatestCommonDivisor(long a, long b)
    {
        // Euclid's algorithm with signed remainders. The modulus sign follows
        // the dividend, which is fine: only the magnitude matters and the
        // intermediate values stay within range (unlike Math.Abs(long.MinValue)).
        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }

        // The gcd magnitude is representable unless the other operand was 0
        // and this one is long.MinValue (a value whose negation is 2^63).
        return a == long.MinValue
            ? throw new OverflowException("The greatest common divisor is not representable as Int64.")
            : Math.Abs(a);
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

        // Compute in long and check the range: the product of two ints can
        // exceed Int32.MaxValue and silently wrap around otherwise.
        var result = LeastCommonMultiple((long)a, (long)b);

        if (result > int.MaxValue)
        {
            throw new OverflowException("The least common multiple exceeds Int32.MaxValue.");
        }

        return (int)result;
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

        if (b == 0)
        {
            return 0;
        }

        // checked: the true lcm of long.MinValue with any non-zero value is
        // always greater than long.MaxValue, and Math.Abs throws for it.
        return checked(Math.Abs(a) * (Math.Abs(b) / GreatestCommonDivisor(a, b)));
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
