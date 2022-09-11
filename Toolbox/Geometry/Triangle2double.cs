namespace ProjectEuler.Toolbox;

public readonly record struct Triangle2double(Point2double P1, Point2double P2, Point2double P3)
{
    public override string ToString() => 
        $"({P1}, {P2}, {P3})";
}
