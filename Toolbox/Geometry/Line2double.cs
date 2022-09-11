namespace ProjectEuler.Toolbox;

public readonly record struct Line2double(Point2double P1, Point2double P2)
{
    public Line2double(Point2double p1, double m)
        : this(p1, new Point2double(0, p1.YIntercept(m)))
    {
        if (P1 == P2)
        {
            throw new ArithmeticException("Point is Y intercept");
        }
    }

    public override string ToString() =>
        $"({P1}, {P2})";
}
