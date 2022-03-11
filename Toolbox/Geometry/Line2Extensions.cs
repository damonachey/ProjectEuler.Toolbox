namespace ProjectEuler.Toolbox;

public static class Line2Extensions
{
    public static double Slope(this Line2double l) =>
        (l.P2.Y - l.P1.Y) / (l.P2.X - l.P1.X);

    public static double YIntercept(this Line2double l) =>
        l.P1.Y - l.Slope() * l.P1.X;

    public static double YIntercept(this Point2double p, double m) =>
        p.Y - m * p.X;

    public static double Length(this Line2double l)
    {
        var dx = l.P2.X - l.P1.X;
        var dy = l.P2.Y - l.P1.Y;

        var dx2 = dx * dx;
        var dy2 = dy * dy;

        return Math.Sqrt(dx2 + dy2);
    }

    public static bool Intersects(this Line2double l1, Line2double l2, out Point2double p)
    {
        p = default;

        var d = (l1.P1.X - l1.P2.X) * (l2.P1.Y - l2.P2.Y) - (l1.P1.Y - l1.P2.Y) * (l2.P1.X - l2.P2.X);

        if (d != 0)
        {
            var x = ((l1.P1.X * l1.P2.Y - l1.P1.Y * l1.P2.X) * (l2.P1.X - l2.P2.X) - (l1.P1.X - l1.P2.X) * (l2.P1.X * l2.P2.Y - l2.P1.Y * l2.P2.X)) / d;
            var y = ((l1.P1.X * l1.P2.Y - l1.P1.Y * l1.P2.X) * (l2.P1.Y - l2.P2.Y) - (l1.P1.Y - l1.P2.Y) * (l2.P1.X * l2.P2.Y - l2.P1.Y * l2.P2.X)) / d;

            var t = new Point2double(x, y);

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

    public static Point2double ReflectPoint(this Line2double l, Point2double p)
    {
        var m = l.Slope();
        var c = l.YIntercept();
        var d = (p.X + (p.Y - c) * m) / (1 + m * m);
        var x = 2 * d - p.X;
        var y = 2 * d * m - p.Y + 2 * c;

        return new(x, y);
    }
}
