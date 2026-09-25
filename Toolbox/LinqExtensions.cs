using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class LINQExtensions
{
    /// <summary>
    /// Searches the entire assumed sorted results of Func(T, int) for an element and returns the zero-based index of the element.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static int BinarySearchForMatch<T>(this T[] list, Func<T, int> comparer)
    {
        var min = 0;
        var max = list.Length - 1;

        while (min <= max)
        {
            var mid = (min + max) / 2;
            var comparison = comparer(list[mid]);

            if (comparison < 0)
            {
                min = mid + 1;
            }
            else if (comparison > 0)
            {
                max = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return ~min;
    }

    /// <summary>
    /// Reverse a sub-range of elements of an array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public static T[] ReverseRange<T>(this T[] list, int start, int end)
    {
        for (var i = (end - start - 1) / 2; i >= 0; i--)
        {
            var a = start + i;
            var b = end - i - 1;

            (list[a], list[b]) = (list[b], list[a]);
        }

        return list;
    }

    /// <summary>
    /// Grab nSample random samples out of an enumerable stream of unknown size.
    /// Enumerates the source exactly once (reservoir sampling) and returns a uniform
    /// random subset of exactly min(nSamples, count) elements in source order.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rows"></param>
    /// <param name="nSamples"></param>
    /// <param name="random">The random number generator to use; defaults to <see cref="Random.Shared"/>.</param>
    /// <returns></returns>
    public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> rows, int nSamples, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(rows);
        ArgumentOutOfRangeException.ThrowIfNegative(nSamples);

        var rng = random ?? Random.Shared;

        return RandomSampleCore();

        IEnumerable<T> RandomSampleCore()
        {
            if (nSamples == 0)
            {
                yield break;
            }

            var reservoir = new (long Index, T Item)[nSamples];
            var count = 0L;

            foreach (var item in rows)
            {
                if (count < nSamples)
                {
                    reservoir[(int)count] = (count, item);
                }
                else
                {
                    var j = rng.NextInt64(count + 1);

                    if (j < nSamples)
                    {
                        reservoir[(int)j] = (count, item);
                    }
                }

                count++;
            }

            var filled = (int)Math.Min(count, nSamples);

            foreach (var entry in reservoir.Take(filled).OrderBy(e => e.Index))
            {
                yield return entry.Item;
            }
        }
    }

    /// <summary>
    /// Computes the sum of a sequence of BigInteger value.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static BigInteger Sum(this IEnumerable<BigInteger> list) => list.Aggregate(BigInteger.Zero, (current, i) => current + i);

    /// <summary>
    /// Computes the sum of a sequence of BigRational value.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static BigRational Sum(this IEnumerable<BigRational> list) => list.Aggregate(BigRational.Zero, (current, i) => current + i);

    /// <summary>
    /// Computes the sum of a sequence of T value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T Sum<T>(this IEnumerable<T> list) where T : INumber<T> => list.Aggregate(T.Zero, (current, i) => current + i);

    /// <summary>
    /// Merges the specified first.
    /// </summary>
    /// <typeparam name="T1">The type of the 1.</typeparam>
    /// <typeparam name="T2">The type of the 2.</typeparam>
    /// <typeparam name="T3">The type of the 3.</typeparam>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <param name="operation">The operation.</param>
    /// <param name="default1">The default1.</param>
    /// <param name="default2">The default2.</param>
    /// <returns></returns>
    public static IEnumerable<T3> Merge<T1, T2, T3>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, T3> operation, Func<T1> default1, Func<T2> default2)
    {
        ArgumentNullException.ThrowIfNull(first);
        ArgumentNullException.ThrowIfNull(second);
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(default1);
        ArgumentNullException.ThrowIfNull(default2);

        using var iter1 = first.GetEnumerator();
        using var iter2 = second.GetEnumerator();
        
        while (iter1.MoveNext())
        {
            if (iter2.MoveNext())
            {
                yield return operation(iter1.Current, iter2.Current);
            }
            else
            {
                yield return operation(iter1.Current, default2());
            }
        }

        while (iter2.MoveNext())
        {
            yield return operation(default1(), iter2.Current);
        }
    }

    /// <summary>
    /// Merges two enumerable lists repeating the last value if one enumerable ends before the other
    /// </summary>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <param name="operation">The operation used to merge the two sequences</param>
    /// <returns></returns>
    public static IEnumerable<T3> MergeRepeatLast<T1, T2, T3>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1?, T2?, T3> operation)
    {
        ArgumentNullException.ThrowIfNull(first);
        ArgumentNullException.ThrowIfNull(second);
        ArgumentNullException.ThrowIfNull(operation);

        using var iter1 = first.GetEnumerator();
        using var iter2 = second.GetEnumerator();
        
        var last1 = default(T1);
        var last2 = default(T2);

        while (iter1.MoveNext())
        {
            last1 = iter1.Current;

            if (iter2.MoveNext())
            {
                last2 = iter2.Current;
            }

            yield return operation(last1, last2);
        }

        while (iter2.MoveNext())
        {
            yield return operation(last1, iter2.Current);
        }
    }

    public static T? SecondLast<T>(this IEnumerable<T> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        var current = default(T);
        var secondLast = default(T);
        var seen = 0;

        foreach (var item in items)
        {
            seen++;

            if (seen > 1)
            {
                secondLast = current;
            }

            current = item;
        }

        if (seen < 2)
        {
            throw new InvalidOperationException("Sequence contains fewer than two elements");
        }

        return secondLast;
    }

    public static IEnumerable<TResult?> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Action<TSource, Exception>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);

        foreach (var item in source)
        {
            var result = default(TResult);
            var wasSuccessful = false;

            try
            {
                result = selector(item);
                wasSuccessful = true;
            }
            catch (Exception ex)
            {
                errorHandler?.Invoke(item, ex);
            }

            if (wasSuccessful)
            {
                yield return result;
            }
        }
    }

    /// <summary>
    /// Enumerable ForAll
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source.</param>
    /// <param name="action">The action.</param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static void ForAll<T>(this IEnumerable<T> source, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(action);

        foreach (var item in source)
        {
            action(item);
        }
    }

    public static string EnumerableToString<T>(this IEnumerable<T> source) where T : notnull
    {
        return $"[{string.Join(", ", source.Select(item => item.ToString()))}]";
    }
}
