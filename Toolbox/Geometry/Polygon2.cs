
namespace ProjectEuler.Toolbox
{
    public struct Polygon2
    {
        public Point2 P1 { get; }
        public Point2 P2 { get; }
        public Point2 P3 { get; }
        public Point2 P4 { get; }

        public Polygon2(Point2 p1, Point2 p2, Point2 p3, Point2 p4)
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
}
