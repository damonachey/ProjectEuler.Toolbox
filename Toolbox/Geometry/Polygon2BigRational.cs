namespace ProjectEuler.Toolbox;

public struct Polygon2BigRational : IEquatable<Polygon2BigRational>
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

    public override bool Equals(object? obj) =>
        obj is Polygon2BigRational other && Equals(other);

    public bool Equals(Polygon2BigRational p) =>
        P1.Equals(p.P1) && P2.Equals(p.P2) && P3.Equals(p.P3) && P4.Equals(p.P4);

    public override int GetHashCode() =>
        P1.GetHashCode() ^ P2.GetHashCode() ^ P3.GetHashCode() ^ P4.GetHashCode();

    public static bool operator ==(Polygon2BigRational p1, Polygon2BigRational p2) =>
        p1.Equals(p2);

    public static bool operator !=(Polygon2BigRational p1, Polygon2BigRational p2) =>
        !p1.Equals(p2);
}
