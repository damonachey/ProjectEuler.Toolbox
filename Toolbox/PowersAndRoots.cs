using System;
using System.Numerics;

namespace ProjectEuler.Toolbox
{
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

            if (h > 9) return false; // return immediately in 6 cases out of 16.

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

        /// <summary>
        /// Gets the integer value equal to Floor(Sqrt(n))
        /// http://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Babylonian_method
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigInteger SqrtFloor(BigInteger n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot calculate square root from a negative number");
            }

            var current = new BigInteger(Math.Sqrt((double)n) * 1.1);
            var previous = default(BigInteger);

            do
            {
                previous = current;

                if (previous == 0)
                {
                    return 0;
                }

                current = (current + n / current) / 2;
            }
            while (previous > current);

            return previous;
        }

        /// <summary>
        /// SQRTs the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="System.OverflowException"></exception>
        public static decimal Sqrt(decimal n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot calculate square root from a negative number");
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
}