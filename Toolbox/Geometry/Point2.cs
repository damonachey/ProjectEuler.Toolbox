using System;

namespace ProjectEuler.Toolbox
{
    public struct Point2<T> : IEquatable<Point2<T>>
    {
        public T X { get; }
        public T Y { get; }

        public Point2(T x, T y)
            : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}, {Y})";

        public override bool Equals(object obj) => obj is Point2<T> && Equals((Point2<T>)obj);

        public bool Equals(Point2<T> p)
        {
            if (p is Point2<double>)
            {
                return
                    Math.Abs(Convert.ToDouble(p.X) - Convert.ToDouble(X)) < 0.000001 &&
                    Math.Abs(Convert.ToDouble(p.Y) - Convert.ToDouble(Y)) < 0.000001;
            }

            return X.Equals(p.X) && Y.Equals(p.Y);
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        public static bool operator ==(Point2<T> left, Point2<T> right) => left.X.Equals(right.X) && left.Y.Equals(right.Y);

        public static bool operator !=(Point2<T> left, Point2<T> right) => !left.X.Equals(right.X) || !left.Y.Equals(right.Y);
    }
}
