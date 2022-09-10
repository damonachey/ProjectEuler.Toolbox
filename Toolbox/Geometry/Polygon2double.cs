namespace ProjectEuler.Toolbox;

public record struct Polygon2double
{
    public Point2double P1 { get; }
    public Point2double P2 { get; }
    public Point2double P3 { get; }
    public Point2double P4 { get; }

    public Polygon2double(Point2double p1, Point2double p2, Point2double p3, Point2double p4)
        : this()
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
        P4 = p4;
    }

    public override string ToString() => 
        $"({P1}, {P2}, {P3}, {P4})";
}
