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
    /// <exception cref="System.ArgumentOutOfRangeException"></exception>
    public static decimal Sqrt(decimal n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        if (n == 0)
        {
            return 0;
        }

        // Newton-Raphson iteration seeded from the double approximation.
        // Quadratic convergence settles to full decimal precision within a
        // few iterations, but decimal rounding can make the final step
        // oscillate forever between two adjacent values next to an irrational
        // root, so the loop is bounded and stops on the first fixed point or
        // two-cycle it encounters.
        var current = (decimal)Math.Sqrt((double)n);
        decimal previous = default;

        for (var iteration = 0; iteration < 20; iteration++)
        {
            var next = (current + n / current) / 2;

            if (next == current)
            {
                return next;
            }

            if (next == previous)
            {
                // Two-cycle: return whichever value is closer to the root.
                return Math.Abs(next * next - n) <= Math.Abs(current * current - n) ? next : current;
            }

            previous = current;
            current = next;
        }

        return current;
    }
}
