namespace ProjectEuler.Toolbox;

public record struct Ellipse2double
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

    public override string ToString() => $"{C} A = {A}, B = {B}";
}
