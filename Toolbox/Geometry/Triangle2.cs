
using System;

namespace ProjectEuler.Toolbox
{
    public struct Triangle2<T>
    {
        public Point2<T> P1 { get; }
        public Point2<T> P2 { get; }
        public Point2<T> P3 { get; }

        public Triangle2(Point2<T> p1, Point2<T> p2, Point2<T> p3)
            : this()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public double Area()
        {
            if (typeof(T) == typeof(long))
            {
                return 0.5 * Math.Abs(
                    (Convert.ToInt64(P1.X) - Convert.ToInt64(P3.X)) *
                    (Convert.ToInt64(P2.Y) - Convert.ToInt64(P1.Y)) -
                    (Convert.ToInt64(P1.X) - Convert.ToInt64(P2.X)) *
                    (Convert.ToInt64(P3.Y) - Convert.ToInt64(P1.Y)));
            }

            if (typeof(T) == typeof(double))
            {
                return 0.5 * Math.Abs(
                    (Convert.ToDouble(P1.X) - Convert.ToDouble(P3.X)) *
                    (Convert.ToDouble(P2.Y) - Convert.ToDouble(P1.Y)) -
                    (Convert.ToDouble(P1.X) - Convert.ToDouble(P2.X)) *
                    (Convert.ToDouble(P3.Y) - Convert.ToDouble(P1.Y)));
            }

            throw new NotSupportedException();
        }

        public override string ToString() => $"({P1}, {P2}, {P3})";
    }
}
