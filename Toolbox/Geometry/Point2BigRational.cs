namespace ProjectEuler.Toolbox;

public record struct Point2BigRational
{
    public BigRational X { get; }
    public BigRational Y { get; }

    public Point2BigRational(BigRational x, BigRational y)
        : this()
    {
        X = x;
        Y = y;
    }

    public override string ToString() =>
        $"({X}, {Y})";
}
