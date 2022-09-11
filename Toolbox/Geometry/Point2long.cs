namespace ProjectEuler.Toolbox;

public readonly record struct Point2long(long X, long Y)
{
    public override string ToString() =>
        $"({X}, {Y})";
}
