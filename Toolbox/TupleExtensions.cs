namespace ProjectEuler.Toolbox;

public static class TupleExtensions
{
    public static int Sum(this (int, int, int) tup) => tup.Item1 + tup.Item2 + tup.Item3;
}
