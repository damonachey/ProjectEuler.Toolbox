using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class Geometry
{
    /// <summary>
    /// Returns the number of diamonds contained in a divided rectangle of size w x h.
    /// </summary>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public static long Diamonds(int w, int h)
    {
        var diamonds = 0;

        for (var y1 = 0.5; y1 < h; y1 += 0.5)
        {
            for (var x1 = y1 % 1; x1 < w; x1++)
            {
                for (var w1 = 1; y1 + w1 / 2.0 <= h && x1 + 0.5 + w1 / 2.0 <= w; w1++)
                {
                    for (var h1 = 1; y1 - h1 / 2.0 >= 0 && x1 + (h1 + w1) / 2.0 <= w; h1++)
                    {
                        diamonds++;
                    }
                }
            }
        }

        return diamonds;
    }

    /// <summary>
    /// Returns the number of sub-rectangles possible in a rectangle of size w x h.
    /// </summary>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public static long Rectangles(int w, int h)
    {
        var rectangles = 0L;

        for (var x1 = 0; x1 <= w; x1++)
        {
            for (var y1 = 0; y1 <= h; y1++)
            {
                for (var x2 = x1 + 1; x2 <= w; x2++)
                {
                    rectangles += h - y1;
                }
            }
        }

        return rectangles;
    }

    /// <summary>
    /// Determines if the point p lies inside the triangle defined by the points a, b, c
    /// </summary>
    /// <param name="p"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool IsPointInTriangle<T>(Point3<T> p, Point3<T> a, Point3<T> b, Point3<T> c) where T : INumber<T> => 
        SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b);

    /// <summary>
    /// Generate Pythagorean triples with a sum no greater than maxPerimeter, answers are NOT unique but a &lt; b &lt; c.
    /// </summary>
    /// <param name="maxPerimeter"></param>
    /// <returns></returns>
    public static IEnumerable<(int, int, int)> PythagoreanTriples(int maxPerimeter)
    {
        var maxn = (int)Math.Sqrt(maxPerimeter / 2);

        for (var n = 1; n < maxn; n++)
        {
            var nn = n * n;
            var maxm = Math.Sqrt(maxPerimeter - nn);

            for (var m = n + 1; m <= maxm; m += 2)
            {
                var mm = m * m;
                var mm_minus_nn = mm - nn;
                var mm_plus_nn = mm + nn;
                var mn2 = 2 * m * n;

                for (var k = 1; ; k++)
                {
                    // formula for a Pythagorean triple
                    var a = k * mm_minus_nn;
                    var b = k * mn2;
                    var c = k * mm_plus_nn;

                    if (a + b + c > maxPerimeter)
                    {
                        break;
                    }

                    // we may not be unique, but lets at least be ordered
                    if (a > b)
                    {
                        (b, a) = (a, b);
                    }

                    yield return (a, b, c);
                }
            }
        }
    }

    /// <summary>
    /// Determines if the points p1 and p2 are on the same side of the line through points a and b
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static bool SameSide<T>(Point3<T> p1, Point3<T> p2, Point3<T> a, Point3<T> b) where T : INumber<T>
    {
        var cp1 = (b - a).Cross(p1 - a);
        var cp2 = (b - a).Cross(p2 - a);

        return cp1.Dot(cp2) >= T.Zero;
    }

    public static T Distance<T>(Point2<T> p1, Point2<T> p2) where T : INumber<T>, IRootFunctions<T>
    {
        var dx = p2.X - p1.X;
        var dy = p2.Y - p1.Y;

        var dx2 = dx * dx;
        var dy2 = dy * dy;

        return T.Sqrt(dx2 + dy2);
    }

    public static BigRational Distance(Point2BigRational p1, Point2BigRational p2)
    {
        var dx = p2.X - p1.X;
        var dy = p2.Y - p1.Y;

        var dx2 = dx * dx;
        var dy2 = dy * dy;

        return BigRational.Sqrt(dx2 + dy2, 6);
    }

    public static T Side<T>(Point2<T> p1, Point2<T> p2, Point2<T> p3) where T : INumber<T> => 
        (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);

    public static double TriangleInscribedCirlceRadius(int a, int b, int c)
    {
        var s = (a + b + c) / 2.0;

        return Math.Sqrt((s - a) * (s - b) * (s - c) / s);
    }

    public static Point2<T> TriangleThirdPoint<T>(Point2<T> B, T ba, Point2<T> C, T ca) where T : INumber<T>, IRootFunctions<T>
    {
        if (B != default)
        {
            throw new Exception();
        }

        if (C.Y != T.Zero)
        {
            throw new Exception();
        }

        var x = (ba * ba - ca * ca + C.X * C.X) / (T.CreateChecked(2) * C.X);
        var y = T.Sqrt(ba * ba - x * x);

        return new(x, y);
    }
}
