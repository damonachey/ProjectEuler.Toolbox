namespace ProjectEuler.Toolbox;

public record struct Line2double
{
    public Point2double P1 { get; }
    public Point2double P2 { get; }

    public Line2double(Point2double p1, Point2double p2)
        : this()
    {
        P1 = p1;
        P2 = p2;
    }

    public Line2double(Point2double p1, double m)
        : this()
    {
        P1 = p1;
        P2 = new(0, p1.YIntercept(m));

        if (P1 == P2)
        {
            throw new ArithmeticException("Point is Y intercept");
        }
    }

    public override string ToString() =>
        $"({P1}, {P2})";
}
