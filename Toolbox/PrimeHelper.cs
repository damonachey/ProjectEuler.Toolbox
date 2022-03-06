namespace ProjectEuler.Toolbox;

public static class PrimeHelper
{
    private static string PrimeFile { get; } = @"C:\Users\Damon\OneDrive\Development\Data\Primes32bit.bin";
    private static Func<long, bool> IsPrimeMemoizedLocal { get; } = n => IsPrime(n);

    static PrimeHelper()
    {
        IsPrimeMemoizedLocal = IsPrimeMemoizedLocal.Memoize();
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
    public static bool IsPrimeMemoized(long n) => IsPrimeMemoizedLocal(n);

    /// <summary>
    /// Enumerates all prime values previously computed
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<int> Primes(long index = 0)
    {
        using var stream = File.Open(PrimeFile, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var reader = new BinaryReader(stream);

        reader.BaseStream.Seek(index * 4, SeekOrigin.Begin);

        while (true)
        {
            yield return reader.ReadInt32();
        }
    }
}
