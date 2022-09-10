namespace ProjectEuler.Toolbox;

public record struct Circle2double
{
    public Point2double C { get; }
    public double R { get; }

    public Circle2double(Point2double c, double r)
    {
        C = c;
        R = r;
    }

    public double Area => Math.PI * R * R;

    public double Circumfrence => 2 * Math.PI * R;

    public override string ToString() => $"{C} R = {R}";
}
