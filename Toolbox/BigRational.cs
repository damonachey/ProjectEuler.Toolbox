using System.Globalization;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Toolbox;

public struct BigRational : IFormattable, IComparable, IComparable<BigRational>, IEquatable<BigRational>
{
    public BigInteger Numerator { get; }
    public BigInteger Denominator { get; }

    public static BigRational Zero { get; } = new(0);
    public static BigRational One { get; } = new(1);
    public static BigRational MinusOne { get; } = new(-1);
    public static BigRational PI { get; } = new(BigInteger.Parse("31415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679"), BigInteger.Pow(10, 100));
    public static BigRational E { get; } = new(BigInteger.Parse("27182818284590452353602874713526624977572470936999595749669676277240766303535475945713821785251664274"), BigInteger.Pow(10, 100));

    public bool IsOne => Numerator == Denominator;
    public bool IsZero => Numerator == 0;
    public int Sign => Numerator.Sign;

    public BigRational(BigInteger i)
        : this()
    {
        Numerator = i;
        Denominator = 1;
    }

    public BigRational(BigInteger numerator, BigInteger denominator)
        : this()
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException();
        }

        var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

        if (denominator.Sign < 0)
        {
            gcd = BigInteger.Negate(gcd);
        }

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public BigRational(BigRational value)
        : this()
    {
        Numerator = value.Numerator;
        Denominator = value.Denominator;
    }

    public static BigRational operator -(BigRational value) => new(-value.Numerator, value.Denominator);

    public static BigRational operator -(BigRational left, BigRational right) => new(left.Numerator * right.Denominator - right.Numerator * left.Denominator, left.Denominator * right.Denominator);

    public static bool operator !=(BigRational left, BigRational right) => left.Numerator * right.Denominator != right.Numerator * left.Denominator;

    public static BigRational operator %(BigRational dividend, BigRational divisor) => new((dividend.Numerator * divisor.Denominator) % (dividend.Denominator * divisor.Numerator), dividend.Denominator * divisor.Denominator);

    public static BigRational operator *(BigRational left, BigRational right) => new(left.Numerator * right.Numerator, left.Denominator * right.Denominator);

    public static BigRational operator /(BigRational dividend, BigRational divisor) => new(dividend.Numerator * divisor.Denominator, dividend.Denominator * divisor.Numerator);

    public static BigRational operator +(BigRational left, BigRational right) => new(left.Numerator * right.Denominator + right.Numerator * left.Denominator, left.Denominator * right.Denominator);

    public static bool operator <(BigRational left, BigRational right) => left.Numerator * right.Denominator < right.Numerator * left.Denominator;

    public static bool operator <=(BigRational left, BigRational right) => left.Numerator * right.Denominator <= right.Numerator * left.Denominator;

    public static bool operator ==(BigRational left, BigRational right) => left.Numerator * right.Denominator == right.Numerator * left.Denominator;

    public static bool operator >(BigRational left, BigRational right) => left.Numerator * right.Denominator > right.Numerator * left.Denominator;

    public static bool operator >=(BigRational left, BigRational right) => left.Numerator * right.Denominator >= right.Numerator * left.Denominator;

    public static explicit operator double(BigRational value) => (double)value.Numerator / (double)value.Denominator;

    public static explicit operator decimal(BigRational value) => (decimal)value.Numerator / (decimal)value.Denominator;

    public static explicit operator BigInteger(BigRational value) => value.Numerator / value.Denominator;

    public static implicit operator BigRational(double value)
    {
        //var dstr = value.ToString("R");
        var dstr = ToLongString(value);
        var dlen = dstr.Length;
        var dot = dstr.IndexOf(".", StringComparison.Ordinal);

        dstr = dstr.Replace(".", "");

        var denominator = BigInteger.Pow(10, dot == -1 ? 1 : dlen - dot);
        var numerator = 10 * BigInteger.Parse(dstr);

        return new(numerator, denominator);
    }

    private static string ToLongString(double input)
    {
        var str = input.ToString().ToUpper();

        // if string representation was collapsed from scientific notation, just return it:
        if (!str.Contains('E'))
        {
            return str;
        }

        var negativeNumber = false;

        if (str[0] == '-')
        {
            str = str.Remove(0, 1);
            negativeNumber = true;
        }

        var decSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        var exponentParts = str.Split('E');
        var decimalParts = exponentParts[0].Split(decSeparator);

        // fix missing decimal point:
        if (decimalParts.Length == 1)
        {
            decimalParts = new[] { exponentParts[0], "0" };
        }

        var exponentValue = int.Parse(exponentParts[1]);

        var newNumber = decimalParts[0] + decimalParts[1];

        string result;

        if (exponentValue > 0)
        {
            result = newNumber + new string('0', Math.Abs(exponentValue - decimalParts[1].Length));
        }
        else // negative exponent
        {
            result = ("0" + decSeparator + new string('0', Math.Abs(exponentValue + decimalParts[0].Length)) + newNumber)
               .TrimEnd('0');
        }

        if (negativeNumber)
        {
            result = "-" + result;
        }

        return result;
    }

    public static implicit operator BigRational(decimal value)
    {
        var dstr = value.ToString("G");
        var dlen = dstr.Length;
        var dot = dstr.IndexOf(".", StringComparison.Ordinal);

        dstr = dstr.Replace(".", "");

        var denominator = BigInteger.Pow(10, dlen - dot);
        var numerator = 10 * BigInteger.Parse(dstr);

        return new(numerator, denominator);
    }

    public static implicit operator BigRational(long value) => new(value);

    public static implicit operator BigRational(BigInteger value) => new(value);

    public static BigRational Pow(BigRational value, int exponent) => new(BigInteger.Pow(value.Numerator, exponent), BigInteger.Pow(value.Denominator, exponent));

    public static double Log(BigRational value) => BigInteger.Log(value.Numerator) - BigInteger.Log(value.Denominator);

    public static double Log10(BigRational value) => BigInteger.Log10(value.Numerator) - BigInteger.Log10(value.Denominator);

    public static BigRational Abs(BigRational value) => new(BigInteger.Abs(value.Numerator), value.Denominator);

    public static BigRational Inverse(BigRational value) => new(value.Denominator, value.Numerator);

    public static BigRational Max(BigRational left, BigRational right) => left > right ? left : right;

    public static BigRational Min(BigRational left, BigRational right) => left < right ? left : right;

    /// <summary>
    /// Square root of the value to the specified precision.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="precision">The precision.</param>
    /// <returns></returns>
    public static BigRational Sqrt(BigRational n, int precision)
    {
        var epsilon = new BigRational(1, BigInteger.Pow(10, precision));

        var nums = SqrtAsRationals(n.Numerator);
        var dens = SqrtAsRationals(n.Denominator);

        var list = nums.MergeRepeatLast(dens, (num, den) => num / den);
        var last = Zero;

        foreach (var test in list)
        {
            if (Abs(test - last) < epsilon)
            {
                return test;
            }

            last = test;
        }

        return last;
    }

    /// <summary>
    /// Returns the series that represents the fractional form of the square root of n.
    /// http://en.wikipedia.org/wiki/Square_root#As_periodic_continued_fractions
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> SqrtAsContinuedFraction(int n)
    {
        var a = (int)Math.Sqrt(n);

        if (PowersAndRoots.IsPerfectSquare(n))
        {
            yield return a;
            yield break;
        }

        var m = 0;
        var d = 1;
        var a0 = a;

        var tup = (m, d, a);
        var tuplist = new HashSet<(int, int, int)>();

        while (!tuplist.Contains(tup))
        {
            yield return a;

            tuplist.Add(tup);
            m = d * a - m;
            d = (n - m * m) / d;
            a = (a0 + m) / d;

            tup = (m, d, a);
        }
    }

    /// <summary>
    /// Returns the series that represents the fractional form of the square root of n.
    /// http://en.wikipedia.org/wiki/Square_root#As_periodic_continued_fractions
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<BigInteger> SqrtAsContinuedFraction(BigInteger n)
    {
        var a = PowersAndRoots.SqrtFloor(n);

        if (PowersAndRoots.IsPerfectSquare(n))
        {
            yield return a;
            yield break;
        }

        var m = BigInteger.Zero;
        var d = BigInteger.One;
        var a0 = a;

        var tup = (m, d, a);
        var tuplist = new HashSet<(BigInteger, BigInteger, BigInteger)>();

        while (!tuplist.Contains(tup))
        {
            yield return a;

            tuplist.Add(tup);
            m = d * a - m;
            d = (n - m * m) / d;
            a = (a0 + m) / d;

            tup = (m, d, a);
        }
    }

    /// <summary>
    /// Returns the square root of n as a list of continued rationals.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<BigRational> SqrtAsRationals(int n) => SqrtAsContinuedFraction(n).ToBigRationals();

    /// <summary>
    /// Returns the square root of n as a list of continued rationals.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<BigRational> SqrtAsRationals(BigInteger n) => SqrtAsContinuedFraction(n).ToBigRationals();

    /// <summary>
    /// Gets the whole part of the ratio
    /// </summary>
    /// <returns></returns>
    public BigInteger GetWholePart() => BigInteger.Divide(Numerator, Denominator);

    /// <summary>
    /// Gets the fractional part of the ratio
    /// </summary>
    /// <returns></returns>
    public BigRational GetFractionPart() => new(BigInteger.Remainder(Numerator, Denominator), Denominator);

    public int CompareTo(object? obj)
    {
        if (obj is BigRational other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException("object is not a BigRational");
    }

    public int CompareTo(BigRational other) => (this - other).Numerator.Sign;

    public override bool Equals(object? obj) => obj is BigRational other && Equals(other);

    public bool Equals(BigRational f)
    {
        if (Denominator == f.Denominator)
        {
            return Numerator == f.Numerator;
        }

        return Numerator * f.Denominator == f.Numerator * Denominator;
    }

    public override int GetHashCode() => Numerator.GetHashCode() ^ Denominator.GetHashCode();

    public override string ToString()
    {
        if (Denominator == 1)
        {
            return ToString("{0}");
        }

        return ToString("{0}/{1}");
    }

    public string ToString(string? format, IFormatProvider? formatProvider = null)
    {
        if (string.IsNullOrEmpty(format))
        {
            return ToString();
        }

        return string.Format(formatProvider ?? CultureInfo.CurrentCulture, format, Numerator, Denominator);
    }

    public string ToDecimalString(int precision)
    {
        if (Denominator == 1)
        {
            return Numerator + ".0";
        }

        var fraction = GetFractionPart();
        var adjustedNumerator = (fraction.Numerator * BigInteger.Pow(10, precision));
        var decimalPlaces = BigInteger.Abs(adjustedNumerator / fraction.Denominator);

        // Case where precision wasn't large enough.
        if (decimalPlaces == 0)
        {
            return "0.0";
        }

        var sb = new StringBuilder();

        var noMoreTrailingZeros = false;
        for (var i = precision; i > 0; i--)
        {
            if (!noMoreTrailingZeros)
            {
                if ((decimalPlaces % 10) == 0)
                {
                    decimalPlaces /= 10;
                    continue;
                }

                noMoreTrailingZeros = true;
            }

            // Add the right most decimal to the string
            sb.Insert(0, decimalPlaces % 10);
            decimalPlaces /= 10;
        }

        // Insert the whole part and decimal
        sb.Insert(0, ".");
        sb.Insert(0, GetWholePart());

        return sb.ToString();
    }
}
