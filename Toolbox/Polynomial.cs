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
        while (true)
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

            var y = points.Select((t, i) => l[i] * t.Y).Sum();

            yield return new(x, y);

            x += dx;
        }
    }
}
