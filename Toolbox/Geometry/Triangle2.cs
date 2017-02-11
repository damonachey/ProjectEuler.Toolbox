
using System;

namespace ProjectEuler.Toolbox
{
    public struct Triangle2
    {
        public Point2 P1 { get; }
        public Point2 P2 { get; }
        public Point2 P3 { get; }

        public Triangle2(Point2 p1, Point2 p2, Point2 p3)
            : this()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public double Area() =>
            0.5 * Math.Abs(
                (P1.X - P3.X) *
                (P2.Y - P1.Y) -
                (P1.X - P2.X) *
                (P3.Y - P1.Y));

        public override string ToString() => 
            $"({P1}, {P2}, {P3})";
    }
}
