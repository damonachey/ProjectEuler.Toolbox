using System.Numerics;

namespace ProjectEuler.Toolbox;

public readonly record struct Ellipse2<T> where T : INumber<T>, IRootFunctions<T>
{
    public readonly Point2<T> C;
    public readonly T A;
    public readonly T B;

    public Ellipse2(Point2<T> c, T a, T b)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(b, a, nameof(b));

        C = c;
        A = a;
        B = b;
    }

    public T Area() => T.Pi * A * B;

    public T Eccentricity() => T.Sqrt(A * A - B * B) / A;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Traditional mathematical name")]
    public T h => (A - B) * (A - B) / ((A + B) * (A + B));

    // https://www.mathsisfun.com/geometry/ellipse-perimeter.html
    public T Perimeter =>
        T.Pi * (A + B) *
        (
        T.One +
        T.One * h / T.CreateChecked(4) +
        T.One * h * h / T.CreateChecked(64) +
        T.One * h * h * h / T.CreateChecked(256) +
        T.CreateChecked(25) * h * h * h * h / T.CreateChecked(16384) +
        T.CreateChecked(49) * h * h * h * h * h / T.CreateChecked(65536) +
        T.CreateChecked(441) * h * h * h * h * h * h / T.CreateChecked(1048576) +
        T.CreateChecked(1089) * h * h * h * h * h * h * h / T.CreateChecked(4194304)
        );

    public override string ToString() => $"{C} A = {A}, B = {B}";
}
