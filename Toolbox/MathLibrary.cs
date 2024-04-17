using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class MathLibrary
{
    /// <summary>
    /// Binomial coefficients are a family of positive integers that occur as 
    /// coefficients in the binomial theorem. They are indexed by two nonnegative 
    /// integers; the binomial coefficient indexed by n and k is usually written 
    /// nCk. It is the coefficient of the x^k term in the polynomial expansion of 
    /// the binomial power (1 + x)^n. Under suitable circumstances the value of 
    /// the coefficient is given by the expression n! / k!(n-k)!. Arranging 
    /// binomial coefficients into rows for successive values of n, and in which 
    /// k ranges from 0 to n, gives a triangular array called Pascal's triangle.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static BigInteger Binomial(int n, int k)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(k, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(k, n);

        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    /// <summary>
    /// Generates the factorial of a number, n!
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static BigInteger Factorial(long n)
    {
        var factorial = BigInteger.One;

        while (n > 1)
        {
            factorial *= n--;
        }

        return factorial;
    }

    /// <summary>
    /// Enumerates all Fibonacci numbers starting at 0, 1, 1, 2, 3, 5, 8, ...
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<BigInteger> FibonacciNumbers()
    {
        var n1 = BigInteger.Zero;
        yield return n1;

        var n2 = BigInteger.One;
        yield return n2;

        while (true)
        {
            var temp = n2;
            n2 += n1;
            n1 = temp;

            yield return n2;
        }
    }

    /// <summary>
    /// Determines if the numbers digits are neither increasing or decreasing
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsBouncy(long n)
    {
        var incr = false;
        var decr = false;

        var d1 = n % 10;
        n /= 10;

        while (n != 0)
        {
            var d2 = n % 10;

            if (d2 < d1)
            {
                incr = true;
            }
            else if (d2 > d1)
            {
                decr = true;
            }

            if (incr && decr)
            {
                return true;
            }

            n /= 10;
            d1 = d2;
        }

        return false;
    }

    /// <summary>
    /// Find the cycle length of n / d
    /// </summary>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    public static int CycleLength(long n, long d)
    {
        var qrSet = new HashSet<(long, long)>();

        while (true)
        {
            var q = n / d;
            var r = n % d;

            if (r == 0)
            {
                return qrSet.Count;
            }

            var qr = (q, r);

            if (qrSet.Contains(qr))
            {
                return qrSet.Count;
            }

            qrSet.Add(qr);
            n = r * 10;
        }
    }

    /// <summary>
    /// Computes the maximum subset sum for the set of values
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    public static long MaximumSubsetSum(long[] set)
    {
        var maxSum = 0L;
        var curSum = 0L;

        foreach (var item in set)
        {
            curSum += item;

            if (curSum > maxSum)
            {
                maxSum = curSum;
            }
            else if (curSum < 0)
            {
                curSum = 0;
            }
        }

        return maxSum;
    }

    /// <summary>
    /// Checks strings for unidirectional cyclic pattern.
    /// 2034 -> 3498, first ends in 34 and second starts with 34
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool IsCyclic(string s1, string s2)
    {
        var mid = s1.Length / 2;

        for (var i = 0; i < mid; i++)
        {
            if (s1[mid + i] != s2[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines if the string is a character by character palindrome
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// NOTE: The string version is faster than int or long versions in many
    /// cases because of the short circuit without having to reverse the entire
    /// number first.
    public static bool IsPalindrome(string s)
    {
        for (var i = s.Length / 2; i >= 0; i--)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Generate successive rows of Pascal's Triangle
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<long[]> PascalsTriangle()
    {
        var row = new long[] { 1 };

        while (true)
        {
            yield return row;

            var previous = row;
            row = new long[row.Length + 1];
            row[0] = 1;

            for (var i = 1; i < previous.Length; i++)
            {
                row[i] = previous[i - 1] + previous[i];
            }

            row[^1] = 1;
        }
    }

    /// <summary>
    /// Returns the product of the distinct prime factors of n
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long Rad(long n)
    {
        if (n == 1)
        {
            return 1;
        }

        return Factorization
            .PrimeFactors(n)
            .Distinct()
            .Aggregate((prod, next) => prod * next);
    }

    /// <summary>
    /// Counts in the requested number base.
    /// </summary>
    /// <param name="b">The base.</param>
    /// <returns></returns>
    public static IEnumerable<long> CountInBase(int b)
    {
        var c = long.MaxValue.ToString().Length;
        var n = new int[c];

        while (n[c - 1] != b)
        {
            var sum = 0L;

            for (var i = 0; i < c; i++)
            {
                sum = sum * 10 + n[c - 1 - i];
            }

            yield return sum;

            for (var i = 0; i < c; i++)
            {
                n[i]++;

                if (n[i] < b)
                {
                    break;
                }

                n[i] = 0;
            }
        }
    }

    /// <summary>
    /// Numbers the of set bits.
    /// </summary>
    /// <param name="i">The number.</param>
    /// <returns></returns>
    public static int NumberOfSetBits(long i)
    {
        i -= ((i >> 1) & 0x5555555555555555);
        i = (i & 0x3333333333333333) + ((i >> 2) & 0x3333333333333333);
        return (int)((((i + (i >> 4)) & 0xF0F0F0F0F0F0F0F) * 0x101010101010101) >> 56);
    }

    public static double NewtonsMethod(Func<double, double> f, Func<double, double> fPrime, double guess, double epsilon)
    {
        var x = guess;
        var xlast = x;

        while (true)
        {
            x -= f(x) / fPrime(x);

            if (Math.Abs(x - xlast) < epsilon)
            {
                return x;
            }

            xlast = x;

            if (double.IsNaN(x))
            {
                throw new OverflowException();
            }
        }
    }
}
