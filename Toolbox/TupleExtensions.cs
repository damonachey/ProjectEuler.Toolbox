namespace ProjectEuler.Toolbox;

public static class TupleExtensions
{
    public static int Sum(this (int, int, int) tuple) => tuple.Item1 + tuple.Item2 + tuple.Item3;
}
