using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ProjectEuler.Toolbox
{
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
        public static IEnumerable<Vector> Lagrange(IList<Vector> points, double x, double dx)
        {
            while (true)
            {
                var l = Enumerable
                    .Repeat(1.0, points.Count)
                    .ToList();

                for (var j = 0; j < l.Count; j++)
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

                yield return new Vector(x, y);

                x += dx;
            }
        }

        /// <summary>
        /// Generate the Lagrange coefficients given a set of points
        ///
        /// http://en.wikipedia.org/wiki/Lagrange_polynomial
        ///
        /// TODO: Finish Lagrange simplification
        /// </summary>
        /// <param name="points">List of points to compute coefficients from.</param>
        /// <returns></returns>
        public static IEnumerable<Point2DBigRational> LagrangeCoefficients(IList<Point2DBigRational> points)
        {
            var l = Enumerable
                .Repeat("1", points.Count)
                .ToList();

            for (var j = 0; j < l.Count; j++)
            {
                for (var k = 0; k < points.Count; k++)
                {
                    if (k != j)
                    {
                        // l[j] *= (x - points[k].X) / (points[j].X - points[k].X);
                        l[j] += " * (x - " + points[k].X + ") / " + (points[j].X - points[k].X);
                    }
                }
            }

            var y = "0";

            for (int i = 0; i < points.Count; i++)
            {
                y += " + " + points[i].Y + " * " + l[i];
            }

            System.Diagnostics.Debug.WriteLine(y);

            y = Expression.Simplify(y);

            System.Diagnostics.Debug.WriteLine(y);

            throw new NotImplementedException();
        }
    }
}