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
    public static IList<T> ReverseRange<T>(this IList<T> list, int start, int end)
    {
        for (var i = (end - start - 1) / 2; i >= 0; i--)
        {
            list.Swap(start + i, end - i - 1);
        }

        return list;
    }

    /// <summary>
    /// Swaps the values of a and b.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static IList<T> Swap<T>(this IList<T> list, int a, int b)
    {
        var temp = list[a];
        list[a] = list[b];
        list[b] = temp;

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
        var sample = new T[nSamples];
        var nSamplesTaken = 0;

        foreach (var item in rows)
        {
            // As the amount of samples increases the probability
            // of including a value gets less..due to the fact
            // that it has a greater chance of surviving if it gets
            // placed into the sample over earlier selections

            if (nSamplesTaken < sample.Length)
            {
                sample[nSamplesTaken] = item;
            }
            else
            {
                if (rand.Next(nSamplesTaken) < nSamples)
                {
                    sample[rand.Next(nSamples)] = item;
                }
            }

            nSamplesTaken++;
        }

        if (nSamplesTaken >= nSamples)
        {
            return sample;
        }

        return sample.Take(nSamplesTaken);
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
            list.Swap(rand.Next(n + 1), n);
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
    /// Enumerates over all items in the input, skipping over the item with the specified offset.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <param name="indexToSkip"></param>
    /// <returns></returns>
    public static IEnumerable<T> AllExcept<T>(this IEnumerable<T> input, int indexToSkip)
    {
        var index = 0;

        return input.Where(item => index++ != indexToSkip);
    }

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
        using (var iter1 = first.GetEnumerator())
        using (var iter2 = second.GetEnumerator())
        {
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
    }

    /// <summary>
    /// Merges two enumerable lists repeating the last value if one enumerable ends before the other
    /// </summary>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <param name="operation">The operation used to merge the two sequences</param>
    /// <returns></returns>
    public static IEnumerable<T3> MergeRepeatLast<T1, T2, T3>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, T3> operation)
    {
        using (var iter1 = first.GetEnumerator())
        using (var iter2 = second.GetEnumerator())
        {
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
    }

    /// <summary>
    /// Enumerates the items of this collection, skipping the last
    /// <paramref name="count"/> items. Note that the memory usage of this method
    /// is proportional to <paramref name="count"/>, but the source collection is
    /// only enumerated once, and in a lazy fashion. Also, enumerating the first
    /// item will take longer than enumerating subsequent items.
    /// </summary>
    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "count cannot be negative.");
        }

        if (count == 0)
        {
            return source;
        }

        return SkipLastIterator(source, count);
    }

    /// <summary>
    /// Skips the last iterator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source.</param>
    /// <param name="count">The count.</param>
    /// <returns></returns>
    private static IEnumerable<T> SkipLastIterator<T>(IEnumerable<T> source, int count)
    {
        var queue = new T[count];
        var headtail = 0; // tail while we're still collecting, both head & tail afterwards because the queue becomes completely full
        var collected = 0;

        foreach (var item in source)
        {
            if (collected < count)
            {
                queue[headtail] = item;
                headtail++;
                collected++;
            }
            else
            {
                if (headtail == count)
                {
                    headtail = 0;
                }

                yield return queue[headtail];
                queue[headtail] = item;
                headtail++;
            }
        }
    }

    /// <summary>
    /// Returns a collection containing only the last <paramref name="count"/>
    /// items of the input collection. This method enumerates the entire
    /// collection to the end once before returning. Note also that the memory
    /// usage of this method is proportional to <paramref name="count"/>.
    /// </summary>
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "count cannot be negative.");
        }

        if (count == 0)
        {
            return new T[0];
        }

        var queue = new Queue<T>(count + 1);

        foreach (var item in source)
        {
            if (queue.Count == count)
            {
                queue.Dequeue();
            }

            queue.Enqueue(item);
        }

        return queue.AsEnumerable();
    }

    public static IEnumerable<TSource> TakeUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            yield return item;

            if (predicate(item)) break;
        }
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        => source
            .GroupBy(keySelector)
            .Select(group => group.First());

    public static T SecondLast<T>(this IEnumerable<T> items)
    {
        var any = false;
        var found = false;
        T current = default;
        T secondLast = default;

        foreach (var item in items)
        {
            if (any)
            {
                secondLast = current;
                found = true;
            }

            current = item;
            any = true;
        }

        if (!found)
        {
            throw new InvalidOperationException("Sequence contains fewer than two elements");
        }

        return secondLast;
    }

    public static List<object> Errors = new List<object>();

    public static IEnumerable<TResult> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
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
        if (action == null)
        {
            throw new ArgumentNullException("action");
        }

        foreach (var item in source)
        {
            action(item);
        }
    }

    public static string EnumerableToString<T>(this IEnumerable<T> source)
    {
        return $"[{string.Join(", ", source.Select(item => item.ToString()))}]";
    }
}
