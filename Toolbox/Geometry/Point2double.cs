namespace ProjectEuler.Toolbox;

public readonly record struct Point2double(double X, double Y)
{
    public override string ToString() =>
        $"({X}, {Y})";
}
