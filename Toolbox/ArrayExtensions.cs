namespace ProjectEuler.Toolbox;

public static class ArrayExtensions
{
    public static T[] ToArray<T>(this T[] arr)
    {
        var result = new T[arr.Length];
        arr.AsSpan().CopyTo(result);
        return result;
    }
}
