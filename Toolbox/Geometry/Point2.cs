using System.Numerics;

namespace ProjectEuler.Toolbox;

public readonly record struct Point2<T>(T X, T Y) where T : INumber<T>
{
    public override string ToString() =>
        $"({X}, {Y})";
}
