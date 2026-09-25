using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class Triangle2Extensions
{
    /// <summary>
    /// Returns twice the area of the triangle (the magnitude of the cross product of two
    /// edges). Exact for integral coordinate types: unlike <see cref="Area{T}"/> it does not
    /// divide, so a lattice triangle's odd twice-area (e.g. 1) survives the integer type.
    /// </summary>
    public static T DoubledArea<T>(this Triangle2<T> t) where T : INumber<T> =>
        T.Abs(
            (t.P1.X - t.P3.X) *
            (t.P2.Y - t.P1.Y) -
            (t.P1.X - t.P2.X) *
            (t.P3.Y - t.P1.Y));

    /// <summary>
    /// Returns the area of the triangle. For integral coordinate types the result is
    /// truncated to a whole value (a lattice triangle can have a half-integer area that is
    /// not representable); use <see cref="DoubledArea{T}"/> for the exact value.
    /// </summary>
    public static T Area<T>(this Triangle2<T> t) where T : INumber<T> => t.DoubledArea() / T.CreateChecked(2);
}