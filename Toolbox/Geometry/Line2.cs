using System.Numerics;

namespace ProjectEuler.Toolbox;

public readonly record struct Line2<T>(Point2<T> P1, Point2<T> P2) where T : INumber<T>
{
    public Line2(Point2<T> p1, T m)
        : this(p1, new Point2<T>(T.Zero, p1.YIntercept(m)))
    {
        if (P1 == P2)
        {
            throw new ArithmeticException("Point is Y intercept");
        }
    }

    public override string ToString() =>
        $"({P1}, {P2})";
}
