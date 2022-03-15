namespace ProjectEuler.Toolbox;

public struct Ellipse2double : IEquatable<Ellipse2double>
{
    public Point2double C { get; }
    public double A { get; }
    public double B { get; }

    public Ellipse2double(Point2double c, double a, double b)
    {
        if (a < b) throw new ArgumentException("a must be the major axis");

        C = c;
        A = a;
        B = b;
    }

    public double Area => Math.PI * A * B;

    public double Eccentricity => Math.Sqrt(A * A - B * B) / A;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Traditional mathematical name")]
    public double h => (A - B) * (A - B) / ((A + B) * (A + B));

    // https://www.mathsisfun.com/geometry/ellipse-perimeter.html
    public double Perimeter =>
        Math.PI * (A + B) *
        (
        1 +
        1 * h / 4 +
        1 * h * h / 64 +
        1 * h * h * h / 256 +
        25 * h * h * h * h / 16384 +
        49 * h * h * h * h * h / 65536 +
        441 * h * h * h * h * h * h / 1048576 +
        1089 * h * h * h * h * h * h * h / 4194304 
        );

    // Ramanujan approximation
    public double PerimeterFast => Math.PI * (A + B) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));

    public override string ToString() => $"{C} A = {A}, B = {B}";

    public override bool Equals(object? obj) => obj is Ellipse2double p && Equals(p);

    public bool Equals(Ellipse2double other) => C == other.C && A == other.A && B == other.B;

    public override int GetHashCode() => C.GetHashCode() ^ A.GetHashCode() ^ B.GetHashCode();

    public static bool operator ==(Ellipse2double e1, Ellipse2double e2) => e1.Equals(e2);

    public static bool operator !=(Ellipse2double e1, Ellipse2double e2) => !e1.Equals(e2);
}
