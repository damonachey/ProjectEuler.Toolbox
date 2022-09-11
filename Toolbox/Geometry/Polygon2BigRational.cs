namespace ProjectEuler.Toolbox;

public readonly record struct Polygon2BigRational(Point2BigRational P1, Point2BigRational P2, Point2BigRational P3, Point2BigRational P4)
{
    public override string ToString() => 
        $"({P1}, {P2}, {P3}, {P4})";
}
