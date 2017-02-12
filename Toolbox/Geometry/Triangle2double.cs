using System;

namespace ProjectEuler.Toolbox
{
    public struct Triangle2double : IEquatable<Triangle2double>
    {
        public Point2double P1 { get; }
        public Point2double P2 { get; }
        public Point2double P3 { get; }

        public Triangle2double(Point2double p1, Point2double p2, Point2double p3)
            : this()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public override string ToString() => 
            $"({P1}, {P2}, {P3})";

        public override bool Equals(object obj) =>
            obj is Triangle2double t && Equals(t);

        public bool Equals(Triangle2double t) =>
            P1 == t.P1 && P2 == t.P2 && P3 == t.P3;

        public override int GetHashCode() =>
            P1.GetHashCode() ^ P2.GetHashCode() ^ P3.GetHashCode();

        public static bool operator ==(Triangle2double t1, Triangle2double t2) =>
            t1.Equals(t2);

        public static bool operator !=(Triangle2double t1, Triangle2double t2) =>
            !t1.Equals(t2);
    }
}
