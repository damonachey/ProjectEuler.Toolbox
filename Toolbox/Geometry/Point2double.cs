namespace ProjectEuler.Toolbox;

public record struct Point2double
{
    public double X { get; }
    public double Y { get; }

    public Point2double(double x, double y)
        : this()
    {
        X = x;
        Y = y;
    }

    public override string ToString() =>
        $"({X}, {Y})";
}
