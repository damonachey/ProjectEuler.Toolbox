using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class LinqExtensions
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
    /// Grab nSample random samples out of an enumerable stream of unknown size
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rows"></param>
    /// <param name="nSamples"></param>
    /// <returns></returns>
    public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> rows, int nSamples)
    {
        var rand = new Random(Guid.NewGuid().GetHashCode());
        var count = rows.Count();

        for (int i = 0; i < count; i++)
        {
            if (rand.Next(count - i) < nSamples)
            {
                yield return rows.ElementAt(i);
                if (--nSamples == 0)
                    yield break;
            }
        }
    }

    /// <summary>
    /// In place Fisher-Yates shuffle a list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static IList<T> Shuffle<T>(this IList<T> list)
    {
        var rand = new Random(Guid.NewGuid().GetHashCode());
        var n = list.Count;

        while (n > 1)
        {
            n--;

            var a = rand.Next(n + 1);

            (list[a], list[n]) = (list[n], list[a]);
        }

        return list;
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

    public static T SecondLast<T>(this IEnumerable<T> items)
    {
        var current = default(T);
        var secondLast = default(T);

        foreach (var item in items)
        {
            if (current is not null)
            {
                secondLast = current;
            }

            current = item;
        }

        return secondLast
            ?? throw new InvalidOperationException("Sequence contains fewer than two elements"); ;
    }

    public static readonly List<object> Errors = new();

    public static IEnumerable<TResult?> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (var item in source)
        {
            var result = default(TResult);
            var wasSuccesful = false;

            try
            {
                result = selector(item);
                wasSuccesful = true;
            }
            catch (Exception ex)
            {
                Errors.Add(new { item, ex });
            }

            if (wasSuccesful)
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
