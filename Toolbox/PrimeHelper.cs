﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler.Toolbox
{
    public static class PrimeHelper
    {
        private const string PrimeFile = @"C:\Users\Damon\OneDrive\Development\Primes32bit.bin";
        private static readonly Func<long, bool> isPrimeMemoized = n => IsPrime(n);

        static PrimeHelper()
        {
            isPrimeMemoized = isPrimeMemoized.Memoize();
        }

        /// <summary>
        /// Determines if the number is a prime.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(long n)
        {
            if (n < 2)
            {
                return false;
            }

            if (n < 4)
            {
                return true;
            }

            if ((n & 1) == 0)
            {
                return false;
            }

            if (n < 9)
            {
                return true;
            }

            if (n % 3 == 0)
            {
                return false;
            }

            //if (primes.Any() && n <= primes.Last())
            //{
            //    return primes.BinarySearch((int)n) >= 0;
            //}

            var r = (long)Math.Sqrt(n);
            var incr = Environment.ProcessorCount * 6;

            var result = Parallel.For(0, Environment.ProcessorCount, (proc, state) =>
            {
                var f = 5L + proc * 6;

                while (f <= r && !state.IsStopped)
                {
                    if (n % f == 0 || n % (f + 2) == 0)
                    {
                        state.Stop();
                        return;
                    }

                    f += incr;
                }
            });

            return result.IsCompleted;
        }

        /// <summary>
        /// Memoized version of IsPrime for performance
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrimeMemoized(long n)
        {
            return isPrimeMemoized(n);
        }

        /// <summary>
        /// Enumerates all prime values previously computed
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> Primes()
        {
            using (var stream = File.Open(PrimeFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new BinaryReader(stream))
            {
                while (true)
                {
                    yield return reader.ReadInt32();
                }
            }
        }
    }
}