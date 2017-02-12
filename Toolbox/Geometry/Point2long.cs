using System;

namespace ProjectEuler.Toolbox
{
    public struct Point2long : IEquatable<Point2long>
    {
        public long X { get; }
        public long Y { get; }

        public Point2long(long x, long y)
            : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString() =>
            $"({X}, {Y})";

        public override bool Equals(object obj) =>
            obj is Point2long p && Equals(p);

        public bool Equals(Point2long p) =>
            X == p.X && Y == p.Y;

        public override int GetHashCode() =>
            X.GetHashCode() ^ Y.GetHashCode();

        public static bool operator ==(Point2long p1, Point2long p2) =>
            p1.Equals(p2);

        public static bool operator !=(Point2long p1, Point2long p2) =>
            !p1.Equals(p2);
    }
}
