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
    public static int ReverseDigits(this int n)
    {
        var r = 0;

        while (n != 0)
        {
            r = r * 10 + n % 10;
            n /= 10;
        }

        return r;
    }

    /// <summary>
    /// Reverses the digits.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long ReverseDigits(this long n)
    {
        var r = 0L;

        while (n != 0)
        {
            r = r * 10 + n % 10;
            n /= 10;
        }

        return r;
    }

    /// <summary>
    /// Reverses the digits.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static BigInteger ReverseDigits(this BigInteger n)
    {
        var r = BigInteger.Zero;

        while (n != 0)
        {
            r = r * 10 + n % 10;
            n /= 10;
        }

        return r;
    }

    /// <summary>
    /// Digits from right to left.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> ToDigits(this int n)
    {
        while (n != 0)
        {
            yield return n % 10;
            n /= 10;
        }
    }

    /// <summary>
    /// Digits from right to left.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> ToDigits(this long n)
    {
        while (n != 0)
        {
            yield return (int)(n % 10);
            n /= 10;
        }
    }

    /// <summary>
    /// Digits from right to left.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> ToDigits(this BigInteger n)
    {
        while (n != 0)
        {
            yield return (int)(n % 10);
            n /= 10;
        }
    }
}
