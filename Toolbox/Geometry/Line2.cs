using System;

namespace ProjectEuler.Toolbox
{
    public struct Line2
    {
        public Point2<double> P1 { get; }
        public Point2<double> P2 { get; }

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

        public double Slope() => (P2.Y - P1.Y) / (P2.X - P1.X);

        public double Intercept() => P1.Y - Slope() * P1.X;

        private double Intercept(Point2<double> p, double m) => p.Y - m * p.X;

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

        public override string ToString() => $"({P1}, {P2})";
    }
}
