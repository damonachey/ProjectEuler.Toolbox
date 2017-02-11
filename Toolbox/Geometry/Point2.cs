using System;

namespace ProjectEuler.Toolbox
{
    public struct Point2 : IEquatable<Point2>
    {
        public double X { get; }
        public double Y { get; }

        public Point2(double x, double y)
            : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString() =>
            $"({X}, {Y})";

        public override bool Equals(object obj) =>
            obj is Point2 other && 
            Equals(other);

        public bool Equals(Point2 p) =>
            Math.Abs(p.X - X) < 0.000001 &&
            Math.Abs(p.Y - Y) < 0.000001;

        public override int GetHashCode() =>
            X.GetHashCode() ^
            Y.GetHashCode();

        public static bool operator ==(Point2 left, Point2 right) =>
            left.X.Equals(right.X) && 
            left.Y.Equals(right.Y);

        public static bool operator !=(Point2 left, Point2 right) =>
            !left.X.Equals(right.X) || 
            !left.Y.Equals(right.Y);
    }
}
