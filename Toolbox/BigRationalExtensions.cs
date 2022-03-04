using System.Numerics;

namespace ProjectEuler.Toolbox;

public static class BigRationalExtensions
{
    /// <summary>
    /// Returns the continued fractions for the fractional represented by the series.
    /// http://en.wikipedia.org/wiki/Continued_fraction
    /// </summary>
    /// <param name="coefficients"></param>
    /// <returns></returns>
    public static IEnumerable<BigRational> ToBigRationals(this IEnumerable<int> coefficients)
    {
        return coefficients
            .Select(i => new BigInteger(i))
            .ToBigRationals();
    }

    /// <summary>
    /// Returns the continued fractions for the fractional represented by the series.
    /// http://en.wikipedia.org/wiki/Continued_fraction
    /// </summary>
    /// <param name="coefficients"></param>
    /// <returns></returns>
    public static IEnumerable<BigRational> ToBigRationals(this IEnumerable<BigInteger> coefficients)
    {
        var coefficientArray = coefficients.ToArray();

        var f0 = new BigRational(coefficientArray[0], 1);
        yield return f0;

        if (coefficientArray.Length == 1) // square number, we're done
        {
            yield break;
        }

        var f1 = new BigRational(coefficientArray[0] * coefficientArray[1] + 1, coefficientArray[1]);
        yield return f1;

        var n = 2;
        while (true)
        {
            if (n == coefficientArray.Length) // loop back to a1
            {
                n = 1;
            }

            var f2 = new BigRational(coefficientArray[n] * f1.Numerator + f0.Numerator, coefficientArray[n] * f1.Denominator + f0.Denominator);
            yield return f2;

            f0 = f1;
            f1 = f2;
            n++;
        }
    }
}
