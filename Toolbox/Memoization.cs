using System.Collections.Concurrent;

namespace ProjectEuler.Toolbox;

// also see http://explodingcoder.com/blog/content/painless-caching-memoization-net
public static class Memoization
{
    public static Func<A, R> Memoize<A, R>(this Func<A, R> f) where A : notnull
    {
        var map = new ConcurrentDictionary<A, R>();

        return a =>
        {
            if (!map.TryGetValue(a, out R? value))
            {
                map.TryAdd(a, value = f(a));
            }

            return value;
        };
    }

    public static Func<A, B, R> Memoize<A, B, R>(this Func<A, B, R> f)
    {
        Func<(A, B), R> tuplified = t => f(t.Item1, t.Item2);
        Func<(A, B), R> memoized = tuplified.Memoize();
        return (a, b) => memoized((a, b));
    }

    public static Func<A, B, C, R> Memoize<A, B, C, R>(this Func<A, B, C, R> f)
    {
        Func<(A, B, C), R> tuplified = t => f(t.Item1, t.Item2, t.Item3);
        Func<(A, B, C), R> memoized = tuplified.Memoize();
        return (a, b, c) => memoized((a, b, c));
    }

    public static Func<A, B, C, D, R> Memoize<A, B, C, D, R>(this Func<A, B, C, D, R> f)
    {
        Func<(A, B, C, D), R> tuplified = t => f(t.Item1, t.Item2, t.Item3, t.Item4);
        Func<(A, B, C, D), R> memoized = tuplified.Memoize();
        return (a, b, c, d) => memoized((a, b, c, d));
    }

    public static Func<A, B, C, D, E, R> Memoize<A, B, C, D, E, R>(this Func<A, B, C, D, E, R> f)
    {
        Func<(A, B, C, D, E), R> tuplified = t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        Func<(A, B, C, D, E), R> memoized = tuplified.Memoize();
        return (a, b, c, d, e) => memoized((a, b, c, d, e));
    }
}
