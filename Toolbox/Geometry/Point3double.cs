namespace ProjectEuler.Toolbox;

public struct Point3double : IEquatable<Point3double>
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Point3double(double x, double y, double z)
        : this()
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Point3double operator -(Point3double p1, Point3double p2) =>
        new(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

    public override string ToString() =>
        $"({X}, {Y}, {Z})";

    public override bool Equals(object? obj) =>
        obj is Point3double other && Equals(other);

    public bool Equals(Point3double p) =>
        X.Equals(p.X) && Y.Equals(p.Y) && Z.Equals(p.Z);

    public override int GetHashCode() =>
        X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

    public static bool operator ==(Point3double left, Point3double right) =>
        left.Equals(right);

    public static bool operator !=(Point3double left, Point3double right) =>
        !left.Equals(right);
}
