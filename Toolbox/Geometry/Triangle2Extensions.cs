using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class Triangle2Extensions
{
    public static T Area<T>(this Triangle2<T> t) where T : INumber<T> =>
        T.Abs(
            (t.P1.X - t.P3.X) *
            (t.P2.Y - t.P1.Y) -
            (t.P1.X - t.P2.X) *
            (t.P3.Y - t.P1.Y)) / T.CreateChecked(2);
}
