using System.Numerics;

namespace ProjectEuler.Toolbox;

public readonly record struct Triangle2<T>(Point2<T> P1, Point2<T> P2, Point2<T> P3) where T : INumber<T>
{
    public override string ToString() => 
        $"({P1}, {P2}, {P3})";
}
