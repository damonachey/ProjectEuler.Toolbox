using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class PowersAndRoots
{
    /// <summary>
    /// Determines if the value is a perfect square.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPerfectSquare(long n)
    {
        var h = (int)(n & 0xF); // last hexadecimal "digit"

        if (h > 9)
        {
            return false; // return immediately in 6 cases out of 16.
        }

        // Take advantage of Boolean short-circuit evaluation
        if (h != 2 && h != 3 && h != 5 && h != 6 && h != 7 && h != 8)
        {
            // take square root if you must
            var t = (long)Math.Sqrt(n);
            return t * t == n;
        }

        return false;
    }

    /// <summary>
    /// Determines if the value is a perfect square.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPerfectSquare(BigInteger n)
    {
        var h = (int)(n & 0xF); // last hexadecimal "digit"

        if (h > 9)
        {
            return false; // return immediately in 6 cases out of 16.
        }

        // Take advantage of Boolean short-circuit evaluation
        if (h != 2 && h != 3 && h != 5 && h != 6 && h != 7 && h != 8)
        {
            // take square root if you must
            var t = SqrtFloor(n);
            return t * t == n;
        }

        return false;
    }

    public static BigInteger SqrtFloor(this BigInteger n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n > 0)
        {
            int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
            BigInteger root = BigInteger.One << (bitLength / 2);

            while (!IsSqrt(n, root))
            {
                root += n / root;
                root /= 2;
            }

            return root;
        }

        throw new ArithmeticException("NaN");
    }

    private static bool IsSqrt(BigInteger n, BigInteger root)
    {
        BigInteger lowerBound = root * root;
        
        BigInteger root1 = root + 1;
        BigInteger upperBound = root1 * root1;

        return n >= lowerBound && n < upperBound;
    }


    /// <summary>
    /// SQRTs the specified n.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <returns></returns>
    /// <exception cref="System.OverflowException"></exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
    public static decimal Sqrt(decimal n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        var epsilon = 0.0m;
        var current = (decimal)Math.Sqrt((double)n);
        var previous = default(decimal);

        do
        {
            previous = current;

            if (previous == 0.0m)
            {
                return 0;
            }

            current = (previous + n / previous) / 2;
        }
        while (Math.Abs(previous - current) > epsilon);

        return current;
    }
}
