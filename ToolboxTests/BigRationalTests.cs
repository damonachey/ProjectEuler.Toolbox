using ProjectEuler.Toolbox;

using System;
using System.Linq;
using System.Numerics;

using Xunit;
using Xunit.Abstractions;

namespace ProjectEuler.ToolboxTests;

public class BigRationalTests
{
    private readonly ITestOutputHelper _output;

    public BigRationalTests(ITestOutputHelper output) => _output = output;

    [Fact]
    public void ConstructorFromInt()
    {
        var expectedNumerator = new BigInteger(2);
        var expectedDenominator = new BigInteger(1);
        var actual = new BigRational(2);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromLong()
    {
        var expectedNumerator = new BigInteger(2);
        var expectedDenominator = new BigInteger(1);
        var actual = new BigRational(2L);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromIntIrrationalNumber()
    {
        var expectedNumerator = new BigInteger(2);
        var expectedDenominator = new BigInteger(3);
        var actual = new BigRational(2, 3);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromBigIntegerIrrationalNumber()
    {
        var expectedNumerator = new BigInteger(2);
        var expectedDenominator = new BigInteger(3);
        var actual = new BigRational(expectedNumerator, expectedDenominator);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromIntIrrationalReduction()
    {
        var expectedNumerator = new BigInteger(2);
        var expectedDenominator = new BigInteger(3);
        var actual = new BigRational(4, 6);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromDouble()
    {
        var expectedNumerator = new BigInteger(1);
        var expectedDenominator = new BigInteger(2);
        var actual = new BigRational(0.5);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromDoubleENotation()
    {
        var expectedNumerator = new BigInteger(621);
        var expectedDenominator = new BigInteger(10000000000000);
        var actual = new BigRational(6.21e-11);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromDecimal()
    {
        var expectedNumerator = new BigInteger(1);
        var expectedDenominator = new BigInteger(2);
        var actual = new BigRational(0.5m);

        Assert.Equal(expectedNumerator, actual.Numerator);
        Assert.Equal(expectedDenominator, actual.Denominator);
    }

    [Fact]
    public void ConstructorFromBigRational()
    {
        var expected = new BigRational(2, 3);
        var actual = new BigRational(expected);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructorDenominatorZero()
    {
        Assert.Throws<DivideByZeroException>(() => new BigRational(1, 0));
    }

    [Fact]
    public void One()
    {
        var expected = new BigInteger(1);
        var actual = BigRational.One.Numerator / BigRational.One.Denominator;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Zero()
    {
        var expected = new BigInteger(0);
        var actual = BigRational.Zero.Numerator / BigRational.Zero.Denominator;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MinusOne()
    {
        var expected = new BigInteger(-1);
        var actual = BigRational.MinusOne.Numerator / BigRational.MinusOne.Denominator;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Denominator()
    {
        var expected = new BigInteger(4);
        var actual = new BigRational(3, 4).Denominator;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Numerator()
    {
        var expected = new BigInteger(3);
        var actual = new BigRational(3, 4).Numerator;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsOneTrue()
    {
        var actual = new BigRational(3, 3).IsOne;

        Assert.True(actual);
    }

    [Fact]
    public void IsOneFalse()
    {
        var actual = new BigRational(2, 3).IsOne;

        Assert.False(actual);
    }

    [Fact]
    public void IsZeroTrue()
    {
        var actual = new BigRational(0, 3).IsZero;

        Assert.True(actual);
    }

    [Fact]
    public void IsZeroFalse()
    {
        var actual = new BigRational(2, 3).IsZero;

        Assert.False(actual);
    }

    [Fact]
    public void SignNegativeNumerator()
    {
        var expected = -1;
        var actual = new BigRational(-2, 3).Sign;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SignNegativeDenominator()
    {
        var expected = -1;
        var actual = new BigRational(1, -3).Sign;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SignPositive()
    {
        var expected = 1;
        var actual = new BigRational(2, 3).Sign;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SignZero()
    {
        var expected = 0;
        var actual = new BigRational(0, 3).Sign;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_SubtractionRational()
    {
        var expected = new BigRational(-2, 5);
        var actual = new BigRational(1, 5) - new BigRational(3, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_SubtractionWholeNumber()
    {
        var expected = new BigRational(-2, 3);
        var actual = new BigRational(1, 3) - 1;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_SubtractionDifferentDenominator()
    {
        var expected = new BigRational(3, 4);
        var actual = new BigRational(1, 3) - new BigRational(2, 5);

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void Op_UnaryNegationNegativeToPositive()
    {
        var expected = new BigRational(-1, 2);
        var actual = -new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_UnaryNegationPositiveToNegative()
    {
        var expected = new BigRational(1, 2);
        var actual = -new BigRational(1, 2);

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void Op_InequalityBigRationalNotEqualRationalTrue()
    {
        var actual = new BigRational(1, 3) != new BigRational(1, 2);

        Assert.True(actual);
    }

    [Fact]
    public void Op_InequalityRationalNotEqualIntTrue()
    {
        var actual = new BigRational(1, 3) != 2;

        Assert.True(actual);
    }

    [Fact]
    public void Op_InequalityIntNotEqualRationalTrue()
    {
        var actual = 2 != new BigRational(1, 3);

        Assert.True(actual);
    }

    [Fact]
    public void Op_InequalityIntNotEqualRationalFalse()
    {
        var actual = 2 != new BigRational(4, 2);

        Assert.False(actual);
    }

    [Fact]
    public void Op_Modulus()
    {
        var expected = new BigRational(1, 5);
        var actual = new BigRational(3, 5) % new BigRational(2, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_MultiplyWholeNumber()
    {
        var expected = new BigRational(2, 3);
        var actual = new BigRational(1, 3) * 2;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_MultiplyRational()
    {
        var expected = new BigRational(1, 12);
        var actual = new BigRational(1, 6) * new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_DivisionWholeNumber()
    {
        var expected = new BigRational(1, 6);
        var actual = new BigRational(1, 3) / 2;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_DivisionRational()
    {
        var expected = new BigRational(1, 3);
        var actual = new BigRational(1, 6) / new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_AdditionRationalSameDenominator()
    {
        var expected = new BigRational(4, 5);
        var actual = new BigRational(1, 5) + new BigRational(3, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_AdditionWholeNumber()
    {
        var expected = new BigRational(4, 3);
        var actual = new BigRational(1, 3) + 1;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_AdditionDifferentDenominator()
    {
        var expected = new BigRational(3, 4);
        var actual = new BigRational(1, 3) + new BigRational(2, 5);

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void Op_LessThanRational()
    {
        var actual = new BigRational(1, 3) < new BigRational(2, 5);

        Assert.True(actual);
    }

    [Fact]
    public void Op_LessThanRationalLessThanWholeNumber()
    {
        var actual = new BigRational(2, 5) < 1;

        Assert.True(actual);
    }

    [Fact]
    public void Op_LessThanWholeNumberLessThanRational()
    {
        var actual = 1 < new BigRational(3, 2);

        Assert.True(actual);
    }

    [Fact]
    public void Op_LessThanWholeNumberLessThanRationalFalse()
    {
        var actual = 2 < new BigRational(1, 3);

        Assert.False(actual);
    }

    [Fact]
    public void Op_LessThanOrEqual()
    {
        var actual = new BigRational(4, 6) <= new BigRational(2, 3);

        Assert.True(actual);
    }

    [Fact]
    public void Op_LessThanOrEqualLessWholeNumberLeft()
    {
        var actual = 1 <= new BigRational(3, 2);

        Assert.True(actual);
    }

    [Fact]
    public void Op_LessThanOrEqualGreaterWholeNumberLeft()
    {
        var actual = 2 <= new BigRational(3, 2);

        Assert.False(actual);
    }

    [Fact]
    public void Op_LessThanOrEqualLessWholeNumberRight()
    {
        var actual = new BigRational(3, 2) <= 1;

        Assert.False(actual);
    }

    [Fact]
    public void Op_LessThanOrEqualGreaterWholeNumberRight()
    {
        var actual = new BigRational(3, 2) <= 2;

        Assert.True(actual);
    }

    [Fact]
    public void Op_EqualityReduction()
    {
        var actual = new BigRational(2, 3) == new BigRational(4, 6);

        Assert.True(actual);
    }

    [Fact]
    public void Op_EqualityWholeNumberRight()
    {
        var actual = new BigRational(9, 3) == 3;

        Assert.True(actual);
    }

    [Fact]
    public void Op_EqualityWholeNumberLeft()
    {
        var actual = 3 == new BigRational(9, 3);

        Assert.True(actual);
    }

    [Fact]
    public void Op_EqualityNotEqualWholeNumber()
    {
        var actual = 4 == new BigRational(1, 3);

        Assert.False(actual);
    }

    [Fact]
    public void Op_GreaterThan()
    {
        var actual = new BigRational(2, 5) > new BigRational(1, 3);

        Assert.True(actual);
    }

    [Fact]
    public void Op_GreaterThanWholeNumberLeft()
    {
        var actual = 1 > new BigRational(2, 5);

        Assert.True(actual);
    }

    [Fact]
    public void Op_GreaterThanWholeNumberRight()
    {
        var actual = new BigRational(3, 2) > 1;

        Assert.True(actual);
    }

    [Fact]
    public void Op_GreaterThanWholeNumberRightFalse()
    {
        var actual = new BigRational(1, 3) > 2;

        Assert.False(actual);
    }

    [Fact]
    public void Op_GreaterThanOrEqual()
    {
        var actual = new BigRational(2, 3) >= new BigRational(4, 6);

        Assert.True(actual);
    }

    [Fact]
    public void Op_GreaterThanOrEqualWholeNumberSmaller()
    {
        var actual = new BigRational(3, 2) >= 1;

        Assert.True(actual);
    }

    [Fact]
    public void Op_GreaterThanOrEqualWholeNumberBigger()
    {
        var actual = new BigRational(3, 2) >= 2;

        Assert.False(actual);
    }

    [Fact]
    public void Op_GreaterThanOrEqualWholeNumberBiggerLeft()
    {
        var actual = 2 >= new BigRational(3, 2);

        Assert.True(actual);
    }

    [Fact]
    public void Op_ExplicitDouble()
    {
        var expected = 0.5;
        var actual = (double)new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ExplicitDoubleENotation()
    {
        var expected = 6.21e-11;
        var actual = (double)new BigRational(621, 10000000000000);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ExplicitDecimal()
    {
        var expected = 0.5m;
        var actual = (decimal)new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ExplicitBigIntegerTrue()
    {
        var expected = new BigInteger(3);
        var actual = (BigInteger)new BigRational(9, 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ExplicitBigIntegerFalse()
    {
        var expected = new BigInteger(4);
        var actual = (BigInteger)new BigRational(13, 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitInt()
    {
        var expected = new BigRational(4, 1);
        var actual = (BigRational)4;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitLong()
    {
        var expected = new BigRational(4, 1);
        var actual = (BigRational)4L;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitBigInteger()
    {
        var expected = new BigRational(4, 1);
        var actual = (BigRational)new BigInteger(4);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitDouble()
    {
        var expected = new BigRational(1, 2);
        var actual = (BigRational)0.5;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitDoubleNegativeENotation1()
    {
        var expected = new BigRational(-100, 1);
        var actual = (BigRational)(-1e2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitDoubleNegativeENotation2()
    {
        var expected = new BigRational(-120, 1);
        var actual = (BigRational)(-1.2e2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitDoubleNegativeENotation3()
    {
        var expected = -1.2 * new BigRational(BigInteger.Pow(10, 20), 1);
        var actual = (BigRational)(-1.2e20);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitDoubleNegativeENotation4()
    {
        var expected = new BigRational(BigInteger.Pow(10, 20), 1);
        var actual = (BigRational)(1e20);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Op_ImplicitDecimal()
    {
        var expected = new BigRational(1, 2);
        var actual = (BigRational)0.5m;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PowSquaredRational()
    {
        var expected = new BigRational(1, 4);
        var actual = BigRational.Pow(new(1, 2), 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PowCubedRational()
    {
        var expected = new BigRational(8, 27);
        var actual = BigRational.Pow(new(2, 3), 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PowCubedWholeNumber()
    {
        var expected = new BigRational(27, 1);
        var actual = BigRational.Pow(new(3, 1), 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Log()
    {
        var expected = BigInteger.Log(1) - BigInteger.Log(3);
        var actual = BigRational.Log(new(1, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Log10()
    {
        var expected = BigInteger.Log10(1) - BigInteger.Log10(3);
        var actual = BigRational.Log10(new(1, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Sin()
    {
        var expected = "0.3271946967961522441733440852676206060643014068937597915900562770";
        var precision = expected.Length - 2;

        var actual = BigRational.Sin(new(1, 3), precision);

        Assert.Equal(expected, actual.ToDecimalString(precision));
    }

    [Fact]
    public void Cos()
    {
        var expected = "0.9449569463147376643882840076758806078458526995651407376776457337";
        var precision = expected.Length - 2;

        var actual = BigRational.Cos(new(1, 3), precision);

        _output.WriteLine($"expected: {expected}");
        _output.WriteLine($"actual  : {actual.ToDecimalString(precision)}");

        Assert.Equal(expected, actual.ToDecimalString(precision));
    }

    [Fact]
    public void Tan()
    {
        var expected = "0.3462535495105754910385435656097407745957039161898002179764440648";
        var precision = expected.Length - 2;

        var actual = BigRational.Tan(new(1, 3), precision);

        Assert.Equal(expected, actual.ToDecimalString(precision));
    }

    [Fact]
    public void AbsNegative()
    {
        var expected = new BigRational(2, 3);
        var actual = BigRational.Abs(new(-2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AbsPositive()
    {
        var expected = new BigRational(2, 3);
        var actual = BigRational.Abs(new(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Inverse()
    {
        var expected = new BigRational(3, 2);
        var actual = BigRational.Inverse(new(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MaxRight()
    {
        var r1 = new BigRational(2, 3);
        var r2 = new BigRational(3, 4);

        var actual = BigRational.Max(r1, r2);

        Assert.Equal(r2, actual);
    }

    [Fact]
    public void MaxLeft()
    {
        var r1 = new BigRational(2, 3);
        var r2 = new BigRational(3, 4);

        var actual = BigRational.Max(r2, r1);

        Assert.Equal(r2, actual);
    }

    [Fact]
    public void MinLeft()
    {
        var r1 = new BigRational(2, 3);
        var r2 = new BigRational(3, 4);

        var actual = BigRational.Min(r1, r2);

        Assert.Equal(r1, actual);
    }

    [Fact]
    public void MinRight()
    {
        var r1 = new BigRational(2, 3);
        var r2 = new BigRational(3, 4);

        var actual = BigRational.Min(r2, r1);

        Assert.Equal(r1, actual);
    }

    [Fact]
    public void SqrtPerfectSquare()
    {
        var expected = new BigRational(5, 2);
        var actual = BigRational.Sqrt(new(25, 4), 10);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtIrrational()
    {
        var expected = BigRational.SqrtAsRationals(2).Skip(100).First();
        var actual = BigRational.Sqrt(new(2), 13);

        Assert.True(BigRational.Abs(expected - actual) < new BigRational(1, 1000000000));
    }

    [Fact]
    public void SumBigRational()
    {
        var expected = new BigRational(6);
        var actual = Enumerable.Range(1, 3).Select(i => new BigRational(i)).Sum();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtAsContinuedFractionSquareInt()
    {
        var expected = new int[] { 5 };
        var actual = BigRational.SqrtAsContinuedFraction(25).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void SqrtAsContinuedFraction()
    {
        var expected = new int[] { 1, 2 };
        var actual = BigRational.SqrtAsContinuedFraction(2).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void SqrtAsContinuedFractionSquare()
    {
        var expected = new BigInteger[] { 5 };
        var actual = BigRational.SqrtAsContinuedFraction(new BigInteger(25)).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void SqrtAsRationalInt()
    {
        var expected = new BigRational[]
            {
                new(1, 1),
                new(3, 2),
                new(7, 5),
                new(17, 12),
                new(41, 29),
            };
        var actual = BigRational.SqrtAsRationals(2).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void SqrtAsRational()
    {
        var expected = new BigRational[]
            {
                new(1, 1),
                new(3, 2),
                new(7, 5),
                new(17, 12),
                new(41, 29),
            };
        var actual = BigRational.SqrtAsRationals(new BigInteger(2)).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void WholePart()
    {
        var expected = new BigInteger(6);
        var actual = new BigRational(25, 4).GetWholePart();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FractionPart()
    {
        var expected = new BigRational(1, 4);
        var actual = new BigRational(25, 4).GetFractionPart();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToEqual()
    {
        var expected = 0;
        var actual = new BigRational(2, 3).CompareTo(new(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToLess()
    {
        var expected = -1;
        var actual = new BigRational(1, 3).CompareTo(new(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToGreater()
    {
        var expected = 1;
        var actual = new BigRational(4, 3).CompareTo(new(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToObjectEqual()
    {
        var expected = 0;
        var actual = new BigRational(2, 3).CompareTo((object)new BigRational(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToObjectGreater()
    {
        var expected = -1;
        var actual = new BigRational(1, 3).CompareTo((object)new BigRational(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToObjectLess()
    {
        var expected = 1;
        var actual = new BigRational(4, 3).CompareTo((object)new BigRational(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToNotBigRational()
    {
        var br = new BigRational(4, 3);
        var tup = (object)(2, 3);

        Assert.Throws<ArgumentException>(() => br.CompareTo(tup));
    }

    [Fact]
    public void EqualsRationalTrue()
    {
        var actual = new BigRational(2, 3).Equals(new(2, 3));

        Assert.True(actual);
    }

    [Fact]
    public void EqualsRationalFalse()
    {
        var actual = new BigRational(2, 3).Equals(new(1, 3));

        Assert.False(actual);
    }

    [Fact]
    public void EqualsRationalObjectTrue()
    {
        var actual = new BigRational(2, 3).Equals((object)new BigRational(2, 3));

        Assert.True(actual);
    }

    [Fact]
    public void EqualsRationalObjectFalse()
    {
        var actual = new BigRational(2, 3).Equals((object)new BigRational(1, 3));

        Assert.False(actual);
    }

    [Fact]
    public void GetHashCodeTrue()
    {
        var expected = new BigRational(2, 3).GetHashCode();
        var actual = new BigRational(2, 3).GetHashCode();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetHashCodeFalse()
    {
        var expected = new BigRational(2, 3).GetHashCode();
        var actual = new BigRational(3, 5).GetHashCode();

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = "2/3";
        var actual = new BigRational(2, 3).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringFormat()
    {
        var expected = "2/3";
        var actual = new BigRational(2, 3).ToString("{0}/{1}", null);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringZero()
    {
        var expected = "0";
        var actual = new BigRational(0, 2).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringWholeNumber()
    {
        var expected = "2";
        var actual = new BigRational(2, 1).ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringNullFormat()
    {
        var expected = "2";
        var actual = new BigRational(2, 1).ToString(null, null);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalString()
    {
        var expected = "0.33";
        var actual = new BigRational(1, 3).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringWholeNumber()
    {
        var expected = "3.00";
        var actual = new BigRational(3, 1).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringWholeNumberZero()
    {
        var expected = "3";
        var actual = new BigRational(3, 1).ToDecimalString(0);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringNotPreciseEnough()
    {
        var expected = "0.00";
        var actual = new BigRational(1, 300).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringTrailingZeros()
    {
        var expected = "0.50";
        var actual = new BigRational(1, 2).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringLeadingZeros()
    {
        var expected = "0.09";
        var actual = new BigRational(1, 11).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringNegative()
    {
        var expected = "-3.50";
        var actual = new BigRational(-7, 2).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringNegative2()
    {
        var expected = "-3.50";
        var actual = new BigRational(7, -2).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PI()
    {
        var expected = Math.PI;
        var actual = BigRational.PI;

        Assert.True(BigRational.Abs(expected - actual) < new BigRational(1, 100000000000000));
    }

    [Fact]
    public void E()
    {
        var expected = Math.E;
        var actual = BigRational.E;

        Assert.True(BigRational.Abs(expected - actual) < new BigRational(1, 100000000000000));
    }
}
