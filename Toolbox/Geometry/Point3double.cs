namespace ProjectEuler.Toolbox;

public readonly record struct Point3double(double X, double Y, double Z)
{
    public static Point3double operator -(Point3double p1, Point3double p2) =>
        new(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

    public override string ToString() =>
        $"({X}, {Y}, {Z})";
}
