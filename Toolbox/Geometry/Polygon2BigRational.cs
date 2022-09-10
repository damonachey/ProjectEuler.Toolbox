namespace ProjectEuler.Toolbox;

public record struct Polygon2BigRational
{
    public Point2BigRational P1 { get; }
    public Point2BigRational P2 { get; }
    public Point2BigRational P3 { get; }
    public Point2BigRational P4 { get; }

    public Polygon2BigRational(Point2BigRational p1, Point2BigRational p2, Point2BigRational p3, Point2BigRational p4)
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
