namespace ProjectEuler.Toolbox;

public struct Polygon2double : IEquatable<Polygon2double>
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

    public override bool Equals(object? obj) =>
        obj is Polygon2double other && Equals(other);

    public bool Equals(Polygon2double p) =>
        P1.Equals(p.P1) && P2.Equals(p.P2) && P3.Equals(p.P3) && P4.Equals(p.P4);

    public override int GetHashCode() =>
        P1.GetHashCode() ^ P2.GetHashCode() ^ P3.GetHashCode() ^ P4.GetHashCode();

    public static bool operator ==(Polygon2double p1, Polygon2double p2) =>
        p1.Equals(p2);

    public static bool operator !=(Polygon2double p1, Polygon2double p2) =>
        !p1.Equals(p2);
}
