namespace ProjectEuler.Toolbox;

public struct Line2double : IEquatable<Line2double>
{
    public Point2double P1 { get; }
    public Point2double P2 { get; }

    public Line2double(Point2double p1, Point2double p2)
        : this()
    {
        P1 = p1;
        P2 = p2;
    }

    public Line2double(Point2double p1, double m)
        : this()
    {
        P1 = p1;
        P2 = new Point2double(0, p1.YIntercept(m));

        if (P1 == P2)
        {
            throw new ArgumentOutOfRangeException("Point is Y intercept");
        }
    }

    public override string ToString() =>
        $"({P1}, {P2})";

    public override bool Equals(object? obj) =>
        obj is Line2double p && Equals(p);

    public bool Equals(Line2double l) =>
        P1 == l.P1 && P2 == l.P2;

    public override int GetHashCode() =>
        P1.GetHashCode() ^ P2.GetHashCode();

    public static bool operator ==(Line2double l1, Line2double l2) =>
        l1.Equals(l2);

    public static bool operator !=(Line2double l1, Line2double l2) =>
        !l1.Equals(l2);
}
