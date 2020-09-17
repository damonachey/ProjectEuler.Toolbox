using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Toolbox
{
    public static class Combinatorics
    {
        public static BigInteger AnagramCount(IEnumerable<int> m) => 
            MathLibrary.Factorial(m.Aggregate((a, v) => a + v)) / m.Aggregate(BigInteger.One, (a, v) => a * MathLibrary.Factorial(v));

        public static BigInteger CircularPermutationCount(long n) => 
            MathLibrary.Factorial(n - 1);

        /// <summary>
        /// Compute the number of combinations nCk.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static BigInteger CombinationCount(int n, int k)
        {
            if (n < 1 || k < 0 || k > n)
            {
                throw new ArgumentOutOfRangeException();
            }

            return MathLibrary.Factorial(n) / (MathLibrary.Factorial(k) * MathLibrary.Factorial(n - k));
        }

        /// <summary>
        /// Generate all combinations of s of k size
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<string> Combinations(this string s, int k) => 
            Combinations(s.ToCharArray(), k).Select(c => string.Join("", c));

        /// <summary>
        /// Generate all combinations of s of k size
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> s, int k)
        {
            var sa = s.ToArray();
            var numbers = Enumerable.Range(0, k).ToArray();

            yield return numbers.Select(n => sa[n]).ToArray();

            var changed = true;

            while (changed)
            {
                changed = false;

                for (var i = k - 1; i >= 0 && !changed; i--)
                {
                    if (numbers[i] < sa.Length - k + i)
                    {
                        numbers[i]++;

                        if (i < k - 1)
                        {
                            for (var j = i + 1; j < k; j++)
                            {
                                numbers[j] = numbers[j - 1] + 1;
                            }
                        }

                        yield return numbers.Select(n => sa[n]).ToArray();
                        changed = true;
                    }
                }
            }
        }

        /// <summary>
        /// Number of partitions.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigInteger PartitionCount(int n)
        {
            var ways = new BigInteger[n + 1];

            ways[0] = 1;

            for (var i = 0; i < n; i++)
            {
                var t = i + 1;

                for (var j = t; j <= n; j++)
                {
                    ways[j] += ways[j - t];
                }
            }

            return ways[n];
        }

        /// <summary>
        /// Number of partitions using only specified units.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static BigInteger PartitionCount(int n, int[] units)
        {
            var ways = new BigInteger[n + 1];

            ways[0] = 1;

            foreach (int unit in units)
            {
                for (var j = unit; j <= n; j++)
                {
                    ways[j] += ways[j - unit];
                }
            }

            return ways[n];
        }

        /// <summary>
        /// Compute the partitions of 1..n into n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<int[]> Partitions(int n)
        {
            var x = new int[n + 1];

            var k = 0;
            var s = 0;

            for (k = 1; k < n; k++)
            {
                x[k] = -1;
            }

            k = 1;

            while (k > 0)
            {
                if (k == n)
                {
                    x[n] = n - s;
                    yield return x.Skip(1).Where(i => i > 0).ToArray();
                    s -= x[--k];
                }
                else
                {
                    if ((n - k + 1) * (x[k] + 1) <= n - s)
                    {
                        x[k]++;

                        if (x[k] >= x[k - 1])
                        {
                            s += x[k++];
                        }
                    }
                    else
                    {
                        x[k] = -1;
                        s -= x[--k];
                    }
                }
            }
        }

        /// <summary>
        /// Compute the partitions of units into n
        /// </summary>
        /// <param name="n"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static IEnumerable<int[]> Partitions(int n, int[] units)
        {
            var x = new int[n + 1];
            var test = new int[2 + units.Length];

            test[0] = -1;
            test[1] = 0;

            for (var i = 0; i < units.Length; i++)
            {
                test[i + 2] = units[i];
            }

            var k = 0;
            var s = 0;

            for (k = 1; k < n; k++)
            {
                x[k] = -1;
            }

            k = 1;

            while (k > 0)
            {
                if (k == n)
                {
                    x[n] = n - s;

                    if (units.Contains(x[n]))
                    {
                        yield return x.Skip(1).Where(i => i > 0).ToArray();
                    }

                    s -= x[--k];
                }
                else
                {
                    var idx = Array.IndexOf(test, x[k]) + 1;

                    if (idx < test.Length && (n - k + 1) * (test[idx]) <= n - s)
                    {
                        x[k] = test[idx];

                        if (x[k] >= x[k - 1])
                        {
                            s += x[k++];
                        }
                    }
                    else
                    {
                        x[k] = -1;
                        s -= x[--k];
                    }
                }
            }
        }

        /// <summary>
        /// Determines if s1 is a permutation of s2.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool IsPermutation(this string s1, string s2) => 
            s1.Length == s2.Length && s1.OrderBy(c => c).SequenceEqual(s2.OrderBy(c2 => c2));

        /// <summary>
        /// Compute the number of permutations nPk.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigInteger PermutationCount(int n, int k)
        {
            if (n < 1 || k < 0 || k > n)
            {
                throw new ArgumentOutOfRangeException();
            }

            return MathLibrary.Factorial(n) / MathLibrary.Factorial(n - k);
        }

        /// <summary>
        /// Compute the number of distinct permutations when duplicate values are present
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static BigInteger PermutationCountDistinct(string str)
        {
            var digitCounts = str
                .GroupBy(i => i)
                .Select(kvp => kvp.Count())
                .ToList();

            var num = MathLibrary.Factorial(str.Length);
            var den = BigInteger.One;

            foreach (var count in digitCounts)
                den *= MathLibrary.Factorial(count);

            return num / den;
        }

        /// <summary>
        /// Generates all permutations of s.  Guaranteed to be lexicographical if s was sorted initially.  Duplicates are treated as unique.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IEnumerable<string> Permutations(this string s, string p = "")
        {
            if (s.Length == 1)
            {
                yield return p + s;
            }

            for (var i = 0; i < s.Length; i++)
            {
                var s2 = s.Substring(0, i) + s.Substring(i + 1);

                foreach (var perm in Permutations(s2, p + s[i]))
                {
                    yield return perm;
                }
            }
        }

        /// <summary>
        /// Generates all permutations of s.  Guaranteed to be lexicographical if s was sorted initially.  No duplicates.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IEnumerable<string> PermutationsDistinct(this string str)
        {
            foreach (var p in PermutationsDistinct(str.ToCharArray(), 0, str.Length))
                yield return string.Join("", p);

            IEnumerable<T[]> PermutationsDistinct<T>(T[] chrs1, int index, int n)
            {
                if (index >= n)
                {
                    yield return chrs1;
                    yield break;
                }

                for (int i = index; i < n; i++)
                {
                    bool check = shouldSwap(chrs1, index, i);
                    if (check)
                    {
                        chrs1.Swap(index, i);
                        foreach (var r in PermutationsDistinct(chrs1, index + 1, n))
                            yield return r;
                        chrs1.Swap(index, i);
                    }
                }

                bool shouldSwap(T[] chrs2, int start, int curr)
                {
                    for (int i = start; i < curr; i++)
                    {
                        if (chrs2[i].Equals(chrs2[curr]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        /// <summary>
        /// Generate all permutations of s of k size.  Duplicates are treated as unique.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<string> Permutations(this string s, int k)
        {
            if (k == 0)
            {
                yield return String.Empty;
            }
            else
            {
                for (var i = 0; i < s.Length; i++)
                {
                    var s2 = s.Substring(0, i) + s.Substring(i + 1);

                    foreach (var perm in Permutations(s2, k - 1))
                    {
                        yield return s[i] + perm;
                    }
                }
            }
        }

        /// <summary>
        /// Get the next permutations of the sequence in place.  Duplicates are not repeated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> PermutationsDistinct<T>(this IEnumerable<T> s) where T : IComparable
        {
            var sa = s.ToArray();
            yield return sa.ToArray();

            var i = sa.Length - 1;

            while (i != 0)
            {
                var ii = i--;

                if (sa[i].CompareTo(sa[ii]) < 0)
                {
                    var j = sa.Length - 1;

                    while (!(sa[i].CompareTo(sa[j]) < 0))
                    {
                        j--;
                    }

                    sa.Swap(i, j);
                    sa.ReverseRange(ii, sa.Length);
                    yield return sa.ToArray();
                    i = sa.Length - 1;
                }
            }
        }

        /// <summary>
        /// Generates all permutations of s.  Duplicates are treated as unique.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> s, int k)
        {
            if (k == 0)
            {
                yield return new T[0];
            }
            else
            {
                var idx = 0;
                var sa = s.ToArray();

                foreach (var e in sa)
                {
                    var s2 = sa.AllExcept(idx++);

                    foreach (var perm in Permutations(s2, k - 1))
                    {
                        yield return new[] { e }.Concat(perm).ToArray();
                    }
                }
            }
        }
    }
}