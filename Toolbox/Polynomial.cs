using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class Polynomial
{
    /// <summary>
    /// Generate the Lagrange sequence given a set of points
    ///
    /// http://en.wikipedia.org/wiki/Lagrange_polynomial
    /// </summary>
    /// <param name="points">List of points to compute interpolations from.</param>
    /// <param name="x">Starting x interpolation range.</param>
    /// <param name="dx">Delta x for interpolations.</param>
    /// <returns></returns>
    public static IEnumerable<Point2<T>> Lagrange<T>(IList<Point2<T>> points, T x, T dx) where T : INumber<T>
    {
        // Integral types previously divided per Lagrange basis term, truncating
        // each one and producing wrong results (e.g. the cube points at x = 5
        // gave -34 instead of 125). For integral T the interpolation is computed
        // exactly in BigInteger and only divided once at the end.
        var exact = IsBinaryInteger<T>();

        while (true)
        {
            var y = exact ? LagrangeExact(points, x) : LagrangeApproximate(points, x);

            yield return new(x, y);

            x += dx;
        }
    }

    private static bool IsBinaryInteger<T>() where T : INumber<T> =>
        typeof(T).GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBinaryInteger<>));

    private static T LagrangeApproximate<T>(IList<Point2<T>> points, T x) where T : INumber<T>
    {
        var l = Array.ConvertAll(new T[points.Count], v => T.One);

        for (var j = 0; j < l.Length; j++)
        {
            for (var k = 0; k < points.Count; k++)
            {
                if (k != j)
                {
                    l[j] *= (x - points[k].X) / (points[j].X - points[k].X);
                }
            }
        }

        return points.Select((t, i) => l[i] * t.Y).Sum();
    }

    private static T LagrangeExact<T>(IList<Point2<T>> points, T x) where T : INumber<T>
    {
        var n = points.Count;

        var xs = new BigInteger[n];
        var ys = new BigInteger[n];

        for (var i = 0; i < n; i++)
        {
            xs[i] = BigInteger.CreateChecked(points[i].X);
            ys[i] = BigInteger.CreateChecked(points[i].Y);
        }

        var bx = BigInteger.CreateChecked(x);

        // D_j = Π_{k≠j} (x_j - x_k): denominators of the Lagrange basis terms.
        var denominators = new BigInteger[n];

        for (var j = 0; j < n; j++)
        {
            var d = BigInteger.One;

            for (var k = 0; k < n; k++)
            {
                if (k != j)
                {
                    d *= xs[j] - xs[k];
                }
            }

            denominators[j] = d;
        }

        // Common denominator: lcm of the per-term denominators so each basis
        // term stays an exact integer fraction.
        var lcm = BigInteger.One;

        foreach (var d in denominators)
        {
            lcm = Lcm(lcm, d);
        }

        // P(x) = Σ_j y_j · Π_{k≠j} (x - x_k) / D_j
        var numerator = BigInteger.Zero;

        for (var j = 0; j < n; j++)
        {
            var term = BigInteger.One;

            for (var k = 0; k < n; k++)
            {
                if (k != j)
                {
                    term *= bx - xs[k];
                }
            }

            numerator += ys[j] * term * (lcm / denominators[j]);
        }

        // BigInteger division truncates toward zero; dividing exactly once at
        // the end yields the exact value (integer for polynomial sequences).
        return T.CreateChecked(numerator / lcm);
    }

    private static BigInteger Gcd(BigInteger a, BigInteger b)
    {
        a = BigInteger.Abs(a);
        b = BigInteger.Abs(b);

        while (b != BigInteger.Zero)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }

    private static BigInteger Lcm(BigInteger a, BigInteger b) => BigInteger.Abs(a / Gcd(a, b) * b);
}