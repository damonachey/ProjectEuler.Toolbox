
namespace ProjectEuler.Toolbox
{
    public struct Triangle2<T>
    {
        public Point2<T> P1 { get; }
        public Point2<T> P2 { get; }
        public Point2<T> P3 { get; }

        public Triangle2(Point2<T> p1, Point2<T> p2, Point2<T> p3)
            : this()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public override string ToString() => $"({P1}, {P2}, {P3})";
    }
}
