namespace ProjectEuler.Toolbox;

public struct Point2double : IEquatable<Point2double>
{
    public double X { get; }
    public double Y { get; }

    public Point2double(double x, double y)
        : this()
    {
        X = x;
        Y = y;
    }

    public override string ToString() =>
        $"({X}, {Y})";

    public override bool Equals(object? obj) =>
        obj is Point2double p && Equals(p);

    public bool Equals(Point2double p) =>
        Math.Abs(X - p.X) < 1e-15 && Math.Abs(Y - p.Y) < 1e-15;

    public override int GetHashCode() =>
        X.GetHashCode() ^ Y.GetHashCode();

    public static bool operator ==(Point2double p1, Point2double p2) =>
        p1.Equals(p2);

    public static bool operator !=(Point2double p1, Point2double p2) =>
        !p1.Equals(p2);
}
