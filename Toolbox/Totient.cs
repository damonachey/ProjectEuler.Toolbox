namespace ProjectEuler.Toolbox;

public class Totient
{
    private int[] _smallestFactors = default!;
    private int _lastSmallestFactor;
    private readonly object _smallestFactorsLock = new();

    public Totient(int max)
    {
        InitializeSmallestFactors(max);
    }

    /// <summary>
    /// Initialize to the largest n that will be passed to Phi for best performance.
    /// </summary>
    /// <param name="max"></param>
    public void InitializeSmallestFactors(int max)
    {
        max += 2; // to account for zero base

        if (max > _lastSmallestFactor)
        {
            lock (_smallestFactorsLock)
            {
                _smallestFactors = new int[max / 2];

                for (int i = 0; i < max / 2; i++)
                {
                    _smallestFactors[i] = 1;
                }

                for (int i = 3; i < max; i += 2)
                {
                    if (_smallestFactors[i / 2] == 1)
                    {
                        for (int k = i + i; k < max; k += i)
                            if (k % 2 == 1 && _smallestFactors[k / 2] == 1)
                            {
                                _smallestFactors[k / 2] = i;
                            }
                    }
                }

                _lastSmallestFactor = max;
            }
        }
    }

    /// <summary>
    /// the totient of a positive integer n is defined to be the number of positive integers less than or equal to n that are coprime to n (i.e. having no common positive factors other than 1).
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Phi(int n)
    {
        if (n <= 1)
        {
            return 1;
        }

        if (n >= _lastSmallestFactor)
        {
            //InitializeSmallestFactors(n);

            throw new ArgumentOutOfRangeException(nameof(n));
        }

        var f =
            n == 2 ? 1 :
            n % 2 == 0 ? 2 :
            _smallestFactors[n / 2];

        if (f == 1)
        {
            return n - 1;
        }

        var fp = 1;

        while ((n /= f) % f == 0)
        {
            fp *= f;
        }

        return Phi(n) * (f - 1) * fp;
    }

    static long Isqrt(long a)
    {
        var y = default(long);
        var x = a;

        while (x > 1)
        {
            if ((y = ((x + (a / x)) >> 1)) >= x)
                return x;

            x = y;
        }

        return x;
    }

    public static long Phi2(long n)
    {
        var p = 0;

        while(n % 2 == 0)
        {
            n >>= 1;
            p++;
        }

        var r = (p == 0) ? 1L : (1 << (p - 1));
        var m = Isqrt(n) + 1;

        for (var d = 3; d <= m; d += 2)
        {
            if ((n % d) == 0)
            {
                for (n /= d, p = 1; n % d == 0; n /= d, p++)
                    r *= d;
                r *= d - 1;
                m = Isqrt(n) + 1;
            }
        }

        if (n > 1)
            r *= (n - 1);

        return r;
    }

    public static int MaxnOverPhin(int n)
    {
        var product = 1;

        foreach (var prime in PrimeHelper.Primes())
        {
            if (product * prime > n)
                return product;

            product *= prime;
        }

        throw new Exception("Need more primes");
    }

    public static int MinnOverPhin(int n)
    {
        var best = 0;

        var primes = PrimeHelper.Primes().TakeWhile(p => p < Math.Sqrt(n)).ToList();

        for (var i = 0; i < primes.Count; i++)
            for (var j = i; j < primes.Count; j++)
                if (primes[i] * primes[j] < n && n - primes[i] * primes[j] < n - best)
                    best = primes[i] * primes[j];

        return best;
    }
}
