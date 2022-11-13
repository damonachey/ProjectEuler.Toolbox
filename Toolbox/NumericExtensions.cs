using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class NumericExtensions
{
    /// <summary>
    /// Reduces a roman numeral string representation to it's minimal length form
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ReduceRomanNumeral(this string s)
    {
        return s
            .Replace("IIII", "IV")
            .Replace("VIV", "IX")
            .Replace("VV", "X")
            .Replace("XXXX", "XL")
            .Replace("LXL", "XC")
            .Replace("LL", "C")
            .Replace("CCCC", "CD")
            .Replace("DCD", "CM")
            .Replace("DD", "M");
    }

    /// <summary>
    /// Reverses the digits.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static T ReverseDigits<T>(this T n) where T : INumber<T>
    {
        var r = T.Zero;

        while (n != T.Zero)
        {
            r = r * T.CreateChecked(10) + n % T.CreateChecked(10);
            n /= T.CreateChecked(10);
        }

        return r;
    }

    /// <summary>
    /// Digits from right to left.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<T> ToDigits<T>(this T n) where T : INumber<T>
    {
        while (n != T.Zero)
        {
            yield return n % T.CreateChecked(10);
            n /= T.CreateChecked(10);
        }
    }
}
