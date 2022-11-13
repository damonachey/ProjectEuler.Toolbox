using System.Numerics;

namespace ProjectEuler.Toolbox;

public readonly record struct Point3<T>(T X, T Y, T Z) where T : INumber<T>
{
    public static Point3<T> operator -(Point3<T> p1, Point3<T> p2) =>
        new(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

    public override string ToString() =>
        $"({X}, {Y}, {Z})";
}
