using ProjectEuler.Toolbox;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class BigRationalTests
{
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
    public void ConstructorFromIntsIrrationalNumber()
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
    public void ConstructorFromIntsIrrationalReduction()
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
    public void op_SubtractionRational()
    {
        var expected = new BigRational(-2, 5);
        var actual = new BigRational(1, 5) - new BigRational(3, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_SubtractionWholeNumber()
    {
        var expected = new BigRational(-2, 3);
        var actual = new BigRational(1, 3) - 1;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_SubtractionDifferentDenominator()
    {
        var expected = new BigRational(3, 4);
        var actual = new BigRational(1, 3) - new BigRational(2, 5);

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void op_UnaryNegationNegativeToPositive()
    {
        var expected = new BigRational(-1, 2);
        var actual = -new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_UnaryNegationPositiveToNegative()
    {
        var expected = new BigRational(1, 2);
        var actual = -new BigRational(1, 2);

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void op_InequalityBigRationalNotEqualRationalTrue()
    {
        var actual = new BigRational(1, 3) != new BigRational(1, 2);

        Assert.True(actual);
    }

    [Fact]
    public void op_InequalityRationalNotEqualIntTrue()
    {
        var actual = new BigRational(1, 3) != 2;

        Assert.True(actual);
    }

    [Fact]
    public void op_InequalityIntNotEqualRationalTrue()
    {
        var actual = 2 != new BigRational(1, 3);

        Assert.True(actual);
    }

    [Fact]
    public void op_InequalityIntNotEqualRationalFalse()
    {
        var actual = 2 != new BigRational(4, 2);

        Assert.False(actual);
    }

    [Fact]
    public void op_Modulus()
    {
        var expected = new BigRational(1, 5);
        var actual = new BigRational(3, 5) % new BigRational(2, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_MultiplyWholeNumber()
    {
        var expected = new BigRational(2, 3);
        var actual = new BigRational(1, 3) * 2;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_MultiplyRational()
    {
        var expected = new BigRational(1, 12);
        var actual = new BigRational(1, 6) * new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_DivisionWholeNumber()
    {
        var expected = new BigRational(1, 6);
        var actual = new BigRational(1, 3) / 2;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_DivisionRational()
    {
        var expected = new BigRational(1, 3);
        var actual = new BigRational(1, 6) / new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_AdditionRationalSameDenominator()
    {
        var expected = new BigRational(4, 5);
        var actual = new BigRational(1, 5) + new BigRational(3, 5);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_AdditionWholeNumber()
    {
        var expected = new BigRational(4, 3);
        var actual = new BigRational(1, 3) + 1;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_AdditionDifferentDenominator()
    {
        var expected = new BigRational(3, 4);
        var actual = new BigRational(1, 3) + new BigRational(2, 5);

        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void op_LessThanRational()
    {
        var actual = new BigRational(1, 3) < new BigRational(2, 5);

        Assert.True(actual);
    }

    [Fact]
    public void op_LessThanRationalLessThanWholeNumber()
    {
        var actual = new BigRational(2, 5) < 1;

        Assert.True(actual);
    }

    [Fact]
    public void op_LessThanWholeNumberLessThanRational()
    {
        var actual = 1 < new BigRational(3, 2);

        Assert.True(actual);
    }

    [Fact]
    public void op_LessThanWholeNumberLessThanRationalFalse()
    {
        var actual = 2 < new BigRational(1, 3);

        Assert.False(actual);
    }

    [Fact]
    public void op_LessThanOrEqual()
    {
        var actual = new BigRational(4, 6) <= new BigRational(2, 3);

        Assert.True(actual);
    }

    [Fact]
    public void op_LessThanOrEqualLessWholeNumberLeft()
    {
        var actual = 1 <= new BigRational(3, 2);

        Assert.True(actual);
    }

    [Fact]
    public void op_LessThanOrEqualGreaterWholeNumberLeft()
    {
        var actual = 2 <= new BigRational(3, 2);

        Assert.False(actual);
    }

    [Fact]
    public void op_LessThanOrEqualLessWholeNumberRight()
    {
        var actual = new BigRational(3, 2) <= 1;

        Assert.False(actual);
    }

    [Fact]
    public void op_LessThanOrEqualGreaterWholeNumberRight()
    {
        var actual = new BigRational(3, 2) <= 2;

        Assert.True(actual);
    }

    [Fact]
    public void op_EqualityReduction()
    {
        var actual = new BigRational(2, 3) == new BigRational(4, 6);

        Assert.True(actual);
    }

    [Fact]
    public void op_EqualityWholeNumberRight()
    {
        var actual = new BigRational(9, 3) == 3;

        Assert.True(actual);
    }

    [Fact]
    public void op_EqualityWholeNumberLeft()
    {
        var actual = 3 == new BigRational(9, 3);

        Assert.True(actual);
    }

    [Fact]
    public void op_EqualityNotEqualWholeNumber()
    {
        var actual = 4 == new BigRational(1, 3);

        Assert.False(actual);
    }

    [Fact]
    public void op_EqualityNull()
    {
        var actual = null == new BigRational(1, 3);

        Assert.False(actual);
    }

    [Fact]
    public void op_GreaterThan()
    {
        var actual = new BigRational(2, 5) > new BigRational(1, 3);

        Assert.True(actual);
    }

    [Fact]
    public void op_GreaterThanWholeNumberLeft()
    {
        var actual = 1 > new BigRational(2, 5);

        Assert.True(actual);
    }

    [Fact]
    public void op_GreaterThanWholeNumberRight()
    {
        var actual = new BigRational(3, 2) > 1;

        Assert.True(actual);
    }

    [Fact]
    public void op_GreaterThanWholeNumberRightFalse()
    {
        var actual = new BigRational(1, 3) > 2;

        Assert.False(actual);
    }

    [Fact]
    public void op_GreaterThanOrEqual()
    {
        var actual = new BigRational(2, 3) >= new BigRational(4, 6);

        Assert.True(actual);
    }

    [Fact]
    public void op_GreaterThanOrEqualWholeNumberSmaller()
    {
        var actual = new BigRational(3, 2) >= 1;

        Assert.True(actual);
    }

    [Fact]
    public void op_GreaterThanOrEqualWholeNumberBigger()
    {
        var actual = new BigRational(3, 2) >= 2;

        Assert.False(actual);
    }

    [Fact]
    public void op_GreaterThanOrEqualWholeNumberBiggerLeft()
    {
        var actual = 2 >= new BigRational(3, 2);

        Assert.True(actual);
    }

    [Fact]
    public void op_ExplicitDouble()
    {
        var expected = 0.5;
        var actual = (double)new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ExplicitDoubleENotation()
    {
        var expected = 6.21e-11;
        var actual = (double)new BigRational(621, 10000000000000);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ExplicitDecimal()
    {
        var expected = 0.5m;
        var actual = (decimal)new BigRational(1, 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ExplicitBigIntegerTrue()
    {
        var expected = new BigInteger(3);
        var actual = (BigInteger)new BigRational(9, 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ExplicitBigIntergerFalse()
    {
        var expected = new BigInteger(4);
        var actual = (BigInteger)new BigRational(13, 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitInt()
    {
        var expected = new BigRational(4, 1);
        var actual = (BigRational)4;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitLong()
    {
        var expected = new BigRational(4, 1);
        var actual = (BigRational)4L;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitBigInteger()
    {
        var expected = new BigRational(4, 1);
        var actual = (BigRational)new BigInteger(4);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitDouble()
    {
        var expected = new BigRational(1, 2);
        var actual = (BigRational)0.5;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitDoubleNegativeENotation1()
    {
        var expected = new BigRational(-100, 1);
        var actual = (BigRational)(-1e2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitDoubleNegativeENotation2()
    {
        var expected = new BigRational(-120, 1);
        var actual = (BigRational)(-1.2e2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitDoubleNegativeENotation3()
    {
        var expected = -1.2 * new BigRational(BigInteger.Pow(10, 20), 1);
        var actual = (BigRational)(-1.2e20);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitDoubleNegativeENotation4()
    {
        var expected = new BigRational(BigInteger.Pow(10, 20), 1);
        var actual = (BigRational)(1e20);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ImplicitDecimal()
    {
        var expected = new BigRational(1, 2);
        var actual = (BigRational)0.5m;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PowSquaredRational()
    {
        var expected = new BigRational(1, 4);
        var actual = BigRational.Pow(new BigRational(1, 2), 2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PowCubedRational()
    {
        var expected = new BigRational(8, 27);
        var actual = BigRational.Pow(new BigRational(2, 3), 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PowCubedWholeNumber()
    {
        var expected = new BigRational(27, 1);
        var actual = BigRational.Pow(new BigRational(3, 1), 3);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Log()
    {
        var expected = BigInteger.Log(1) - BigInteger.Log(3);
        var actual = BigRational.Log(new BigRational(1, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Log10()
    {
        var expected = BigInteger.Log10(1) - BigInteger.Log10(3);
        var actual = BigRational.Log10(new BigRational(1, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AbsNegative()
    {
        var expected = new BigRational(2, 3);
        var actual = BigRational.Abs(new BigRational(-2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AbsPositive()
    {
        var expected = new BigRational(2, 3);
        var actual = BigRational.Abs(new BigRational(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Inverse()
    {
        var expected = new BigRational(3, 2);
        var actual = BigRational.Inverse(new BigRational(2, 3));

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
        var actual = BigRational.Sqrt(new BigRational(25, 4), 10);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SqrtIrrational()
    {
        var expected = BigRational.SqrtAsRationals(2).Skip(100).First();
        var actual = BigRational.Sqrt(new BigRational(2), 13);

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
                new BigRational(1, 1),
                new BigRational(3, 2),
                new BigRational(7, 5),
                new BigRational(17, 12),
                new BigRational(41, 29),
            };
        var actual = BigRational.SqrtAsRationals(2).Take(5);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void SqrtAsRational()
    {
        var expected = new BigRational[]
            {
                new BigRational(1, 1),
                new BigRational(3, 2),
                new BigRational(7, 5),
                new BigRational(17, 12),
                new BigRational(41, 29),
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
        var actual = new BigRational(2, 3).CompareTo(new BigRational(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToLess()
    {
        var expected = -1;
        var actual = new BigRational(1, 3).CompareTo(new BigRational(2, 3));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompareToGreater()
    {
        var expected = 1;
        var actual = new BigRational(4, 3).CompareTo(new BigRational(2, 3));

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
        var tup = (object)Tuple.Create(2, 3);

        Assert.Throws<ArgumentException>(() => br.CompareTo(tup));
    }

    [Fact]
    public void EqualsRationalTrue()
    {
        var actual = new BigRational(2, 3).Equals(new BigRational(2, 3));

        Assert.True(actual);
    }

    [Fact]
    public void EqualsRationalFalse()
    {
        var actual = new BigRational(2, 3).Equals(new BigRational(1, 3));

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
        var expected = "3.0";
        var actual = new BigRational(3, 1).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringNotPreciseEnough()
    {
        var expected = "0.0";
        var actual = new BigRational(1, 300).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringTrailingZeros()
    {
        var expected = "0.5";
        var actual = new BigRational(1, 2).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringNegative()
    {
        var expected = "-3.5";
        var actual = new BigRational(-7, 2).ToDecimalString(2);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToDecimalStringNegative2()
    {
        var expected = "-3.5";
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
