namespace ProjectEuler.Toolbox;

public readonly record struct Point2BigRational(BigRational X, BigRational Y)
{
    public override string ToString() =>
        $"({X}, {Y})";
}
