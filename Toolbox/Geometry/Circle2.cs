using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Toolbox
{
    public class Circle2
    {
        public Point2<double> C { get; }
        public double R { get; }

        public Circle2(Point2<double> c, double r)
        {
            C = c;
            R = r;
        }

        public double Area() => 
            Math.PI * R * R;

        public double Circumfrence() => 
            2 * Math.PI * R;

        public static double ChordAngle(double length, double radius) =>
            2 * Math.Asin((length / 2) / radius);

        public static double SegmentArea(double angle, double r) =>
            (r * r) / 2 * (angle - Math.Sin(angle));

        public override string ToString() => 
            $"{C} R = {R}";
    }
}
