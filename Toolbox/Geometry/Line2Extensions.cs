using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class Line2Extensions
{
    public static T Slope<T>(this Line2<T> l) where T : INumber<T> =>
        (l.P2.Y - l.P1.Y) / (l.P2.X - l.P1.X);

    public static T YIntercept<T>(this Line2<T> l) where T : INumber<T> =>
        l.P1.Y - l.Slope() * l.P1.X;

    public static T YIntercept<T>(this Point2<T> p, T m) where T : INumber<T> =>
        p.Y - m * p.X;

    public static T Length<T>(this Line2<T> l) where T : INumber<T>, IRootFunctions<T>
    {
        var dx = l.P2.X - l.P1.X;
        var dy = l.P2.Y - l.P1.Y;

        var dx2 = dx * dx;
        var dy2 = dy * dy;

        return T.Sqrt(dx2 + dy2);
    }

    public static bool Intersects<T>(this Line2<T> l1, Line2<T> l2, out Point2<T> p) where T : INumber<T>
    {
        p = default;

        var d = (l1.P1.X - l1.P2.X) * (l2.P1.Y - l2.P2.Y) - (l1.P1.Y - l1.P2.Y) * (l2.P1.X - l2.P2.X);

        if (d != T.Zero)
        {
            var x = ((l1.P1.X * l1.P2.Y - l1.P1.Y * l1.P2.X) * (l2.P1.X - l2.P2.X) - (l1.P1.X - l1.P2.X) * (l2.P1.X * l2.P2.Y - l2.P1.Y * l2.P2.X)) / d;
            var y = ((l1.P1.X * l1.P2.Y - l1.P1.Y * l1.P2.X) * (l2.P1.Y - l2.P2.Y) - (l1.P1.Y - l1.P2.Y) * (l2.P1.X * l2.P2.Y - l2.P1.Y * l2.P2.X)) / d;

            var t = new Point2<T>(x, y);

            if (((l1.P1.X <= t.X && t.X <= l1.P2.X) || (l1.P2.X <= t.X && t.X <= l1.P1.X)) && ((l2.P1.X <= t.X && t.X <= l2.P2.X) || (l2.P2.X <= t.X && t.X <= l2.P1.X)) &&
                ((l1.P1.Y <= t.Y && t.Y <= l1.P2.Y) || (l1.P2.Y <= t.Y && t.Y <= l1.P1.Y)) && ((l2.P1.Y <= t.Y && t.Y <= l2.P2.Y) || (l2.P2.Y <= t.Y && t.Y <= l2.P1.Y)) &&
                l1.P1 != t && l1.P2 != t && l2.P1 != t && l2.P2 != t)
            {
                p = t;

                return true;
            }
        }

        return false;
    }

    public static Point2<T> ReflectPoint<T>(this Line2<T> l, Point2<T> p) where T : INumber<T>
    {
        var m = l.Slope();
        var c = l.YIntercept();
        var d = (p.X + (p.Y - c) * m) / (T.One + m * m);
        var x = T.CreateChecked(2) * d - p.X;
        var y = T.CreateChecked(2) * d * m - p.Y + T.CreateChecked(2) * c;

        return new(x, y);
    }
}
