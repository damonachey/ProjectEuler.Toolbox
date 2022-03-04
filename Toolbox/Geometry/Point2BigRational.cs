namespace ProjectEuler.Toolbox;

public struct Point2BigRational : IEquatable<Point2BigRational>
{
    public BigRational X { get; }
    public BigRational Y { get; }

    public Point2BigRational(BigRational x, BigRational y)
        : this()
    {
        X = x;
        Y = y;
    }

    public override string ToString() =>
        $"({X}, {Y})";

    public override bool Equals(object? obj) =>
        obj is Point2BigRational p && Equals(p);

    public bool Equals(Point2BigRational p) =>
        X == p.X && Y == p.Y;

    public override int GetHashCode() =>
        X.GetHashCode() ^ Y.GetHashCode();

    public static bool operator ==(Point2BigRational p1, Point2BigRational p2) =>
        p1.Equals(p2);

    public static bool operator !=(Point2BigRational p1, Point2BigRational p2) =>
        !p1.Equals(p2);
}
