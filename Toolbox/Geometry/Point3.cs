using System;

namespace ProjectEuler.Toolbox
{
    public struct Point3 : IEquatable<Point3>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3 Cross(Point3 p1, Point3 p2) =>
            new Point3(
                p1.Y * p2.Z - p1.Z * p2.Y,
                p1.Z * p2.X - p1.X * p2.Z,
                p1.X * p2.Y - p1.Y * p2.X
                );

        public static double Dot(Point3 p1, Point3 p2) =>
            p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z;

        public static Point3 operator -(Point3 p1, Point3 p2) =>
            new Point3(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

        public override string ToString() =>
            $"({X}, {Y}, {Z})";

        public override bool Equals(object obj) =>
            obj is Point3 other && Equals(other);

        public bool Equals(Point3 p) =>
            X.Equals(p.X) && Y.Equals(p.Y) && Z.Equals(p.Z);

        public override int GetHashCode() =>
            X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        public static bool operator ==(Point3 left, Point3 right) =>
            left.X.Equals(right.X) && left.Y.Equals(right.Y) && left.Z.Equals(right.Z);

        public static bool operator !=(Point3 left, Point3 right) =>
            !left.X.Equals(right.X) || !left.Y.Equals(right.Y) || !left.Z.Equals(right.Z);
    }


}
