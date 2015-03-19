using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Windows;
using Microsoft.Xna.Framework;

namespace ProjectEuler.Toolbox
{
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
        public static bool IsPointInTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
        {
            return SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b);
        }

        /// <summary>
        /// Generate Pythagorean triples with a sum no greater than maxPerimeter, answers are NOT unique but a &lt; b &lt; c.
        /// </summary>
        /// <param name="maxPerimeter"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<int, int, int>> PythagoreanTriples(int maxPerimeter)
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
                            var t = a;
                            a = b;
                            b = t;
                        }

                        yield return Tuple.Create(a, b, c);
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
        private static bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
        {
            var cp1 = Vector3.Cross(b - a, p1 - a);
            var cp2 = Vector3.Cross(b - a, p2 - a);

            return Vector3.Dot(cp1, cp2) >= 0;
        }

        public static BigRational Distance(Point2<BigRational> p1, Point2<BigRational> p2)
        {
            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;

            var dx2 = dx * dx;
            var dy2 = dy * dy;

            return BigRational.Sqrt(dx2 + dy2, 10);
        }
    }

    public struct Point2<T> : IEquatable<Point2<T>>
    {
        public T X { get; private set; }
        public T Y { get; private set; }

        public Point2(T x, T y)
            : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Point2<T> && Equals((Point2<T>)obj);
        }

        public bool Equals(Point2<T> p)
        {
            return X.Equals(p.X) && Y.Equals(p.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public static bool operator ==(Point2<T> left, Point2<T> right)
        {
            return left.X.Equals(right.X) && left.Y.Equals(right.Y);
        }

        public static bool operator !=(Point2<T> left, Point2<T> right)
        {
            return !left.X.Equals(right.X) || !left.Y.Equals(right.Y);
        }
    }

    public struct Point3<T> : IEquatable<Point3<T>>
    {
        public T X { get; private set; }
        public T Y { get; private set; }
        public T Z { get; private set; }

        public Point3(T x, T y, T z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Point3<T> && Equals((Point3<T>)obj);
        }

        public bool Equals(Point3<T> p)
        {
            return X.Equals(p.X) && Y.Equals(p.Y) && Z.Equals(p.Z);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public static bool operator ==(Point3<T> left, Point3<T> right)
        {
            return left.X.Equals(right.X) && left.Y.Equals(right.Y) && left.Z.Equals(right.Z);
        }

        public static bool operator !=(Point3<T> left, Point3<T> right)
        {
            return !left.X.Equals(right.X) || !left.Y.Equals(right.Y) || !left.Z.Equals(right.Z);
        }
    }

    public struct Line2
    {
        public Point2<double> P1 { get; private set; }
        public Point2<double> P2 { get; private set; }

        public Line2(Point2<double> p1, Point2<double> p2)
            : this()
        {
            P1 = p1;
            P2 = p2;
        }

        public Line2(Point2<double> p1, double m)
            : this()
        {
            P1 = p1;
            P2 = new Point2<double>(0, Intercept(p1, m));

            if (P1 == P2) throw new ArgumentOutOfRangeException("Point is Y intercept");
        }

        public double Slope()
        {
            return (P2.Y - P1.Y) / (P2.X - P1.X);
        }

        public double Intercept()
        {
            return P1.Y - Slope() * P1.X;
        }

        private double Intercept(Point2<double> p, double m)
        {
            return p.Y - m * p.X;
        }
        
        public bool Intersects(Line2 s, out Point2<double> p)
        {
            p = default(Point2<double>);

            var d = (P1.X - P2.X) * (s.P1.Y - s.P2.Y) - (P1.Y - P2.Y) * (s.P1.X - s.P2.X);

            if (d != 0)
            {
                var x = ((P1.X * P2.Y - P1.Y * P2.X) * (s.P1.X - s.P2.X) - (P1.X - P2.X) * (s.P1.X * s.P2.Y - s.P1.Y * s.P2.X)) / d;
                var y = ((P1.X * P2.Y - P1.Y * P2.X) * (s.P1.Y - s.P2.Y) - (P1.Y - P2.Y) * (s.P1.X * s.P2.Y - s.P1.Y * s.P2.X)) / d;

                var t = new Point2<double>(x, y);

                if (((P1.X <= t.X && t.X <= P2.X) || (P2.X <= t.X && t.X <= P1.X)) && ((s.P1.X <= t.X && t.X <= s.P2.X) || (s.P2.X <= t.X && t.X <= s.P1.X)) &&
                    ((P1.Y <= t.Y && t.Y <= P2.Y) || (P2.Y <= t.Y && t.Y <= P1.Y)) && ((s.P1.Y <= t.Y && t.Y <= s.P2.Y) || (s.P2.Y <= t.Y && t.Y <= s.P1.Y)) &&
                    P1 != t && P2 != t && s.P1 != t && s.P2 != t)
                {
                    p = t;

                    return true;
                }
            }

            return false;
        }

        public Point2<double> ReflectPoint(Point2<double> p)
        {
            var m = Slope();
            var c = Intercept();
            var d = (p.X + (p.Y - c) * m) / (1 + m * m);

            return new Point2<double>(2 * d - p.X, 2 * d * m - p.Y + 2 * c);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", P1, P2);
        }
    }

    public struct Triangle2<T>
    {
        public Point2<T> P1 { get; private set; }
        public Point2<T> P2 { get; private set; }
        public Point2<T> P3 { get; private set; }

        public Triangle2(Point2<T> p1, Point2<T> p2, Point2<T> p3)
            : this()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", P1, P2, P3);
        }
    }

    public struct Polygon2<T>
    {
        public Point2<T> P1 { get; private set; }
        public Point2<T> P2 { get; private set; }
        public Point2<T> P3 { get; private set; }
        public Point2<T> P4 { get; private set; }

        public Polygon2(Point2<T> p1, Point2<T> p2, Point2<T> p3, Point2<T> p4)
            : this()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", P1, P2, P3, P4);
        }
    }
}