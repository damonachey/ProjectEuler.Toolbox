using System.Numerics;
using System.Text;

namespace ProjectEuler.Toolbox;

public static class NumericExtensions
{
    /// <summary>
    /// Reduces a roman numeral string representation to its minimal length form.
    /// The additive value is parsed (allowing the standard subtractive pairs, e.g. IV, IX, XL)
    /// and re-emitted in canonical minimal notation.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ReduceRomanNumeral(this string s)
    {
        var value = 0;
        var previous = 0;

        // Scan right to left: a symbol smaller than its right-hand neighbour is subtractive.
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var current = RomanValue(s[i]);

            value += current < previous ? -current : current;

            previous = current;
        }

        return ToRoman(value);
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

    private static int RomanValue(char c) => c switch
    {
        'I' or 'i' => 1,
        'V' or 'v' => 5,
        'X' or 'x' => 10,
        'L' or 'l' => 50,
        'C' or 'c' => 100,
        'D' or 'd' => 500,
        'M' or 'm' => 1000,
        _ => 0,
    };

    private static string ToRoman(int value)
    {
        if (value <= 0)
        {
            return string.Empty;
        }

        Span<(int Amount, string Symbol)> table =
        [
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
            (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
            (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I"),
        ];

        var result = new StringBuilder();

        foreach (var (amount, symbol) in table)
        {
            while (value >= amount)
            {
                result.Append(symbol);
                value -= amount;
            }
        }

        return result.ToString();
    }
}
