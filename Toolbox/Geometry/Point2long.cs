namespace ProjectEuler.Toolbox;

public record struct Point2long
{
    public long X { get; }
    public long Y { get; }

    public Point2long(long x, long y)
        : this()
    {
        X = x;
        Y = y;
    }

    public override string ToString() =>
        $"({X}, {Y})";
}
