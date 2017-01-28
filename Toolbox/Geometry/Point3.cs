using System;

namespace ProjectEuler.Toolbox
{
    public struct Point3<T> : IEquatable<Point3<T>>
    {
        public T X { get; }
        public T Y { get; }
        public T Z { get; }

        public Point3(T x, T y, T z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => $"({X}, {Y}, {Z})";

        public override bool Equals(object obj) => obj is Point3<T> && Equals((Point3<T>)obj);

        public bool Equals(Point3<T> p) => X.Equals(p.X) && Y.Equals(p.Y) && Z.Equals(p.Z);

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        public static bool operator ==(Point3<T> left, Point3<T> right) => left.X.Equals(right.X) && left.Y.Equals(right.Y) && left.Z.Equals(right.Z);

        public static bool operator !=(Point3<T> left, Point3<T> right) => !left.X.Equals(right.X) || !left.Y.Equals(right.Y) || !left.Z.Equals(right.Z);
    }


}
