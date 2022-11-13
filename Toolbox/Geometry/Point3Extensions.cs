using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class Point3Extensions
{
    public static Point3<T> Cross<T>(this Point3<T> p1, Point3<T> p2) where T : INumber<T> =>
        new(
            p1.Y * p2.Z - p1.Z * p2.Y,
            p1.Z * p2.X - p1.X * p2.Z,
            p1.X * p2.Y - p1.Y * p2.X
            );

    public static T Dot<T>(this Point3<T> p1, Point3<T> p2) where T : INumber<T> =>
        p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z;
}
