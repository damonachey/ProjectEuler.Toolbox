namespace ProjectEuler.Toolbox;

public record struct Point3double
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
}
