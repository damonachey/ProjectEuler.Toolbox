using System;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class BigRationalTests
    {
        [Test]
        public void ConstructorFromInt()
        {
            var expectedNumerator = new BigInteger(2);
            var expectedDenominator = new BigInteger(1);
            var actual = new BigRational(2);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromLong()
        {
            var expectedNumerator = new BigInteger(2);
            var expectedDenominator = new BigInteger(1);
            var actual = new BigRational(2L);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromIntsIrrationalNumber()
        {
            var expectedNumerator = new BigInteger(2);
            var expectedDenominator = new BigInteger(3);
            var actual = new BigRational(2, 3);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromBigIntegerIrrationalNumber()
        {
            var expectedNumerator = new BigInteger(2);
            var expectedDenominator = new BigInteger(3);
            var actual = new BigRational(expectedNumerator, expectedDenominator);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromIntsIrrationalReduction()
        {
            var expectedNumerator = new BigInteger(2);
            var expectedDenominator = new BigInteger(3);
            var actual = new BigRational(4, 6);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromDouble()
        {
            var expectedNumerator = new BigInteger(1);
            var expectedDenominator = new BigInteger(2);
            var actual = new BigRational(0.5);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromDecimal()
        {
            var expectedNumerator = new BigInteger(1);
            var expectedDenominator = new BigInteger(2);
            var actual = new BigRational(0.5m);

            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        [Test]
        public void ConstructorFromBigRational()
        {
            var expected = new BigRational(2, 3);
            var actual = new BigRational(expected);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorDenominatorZero()
        {
            Assert.Throws<DivideByZeroException>(() => new BigRational(1, 0));
        }

        [Test]
        public void One()
        {
            var expected = new BigInteger(1);
            var actual = BigRational.One.Numerator / BigRational.One.Denominator;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Zero()
        {
            var expected = new BigInteger(0);
            var actual = BigRational.Zero.Numerator / BigRational.Zero.Denominator;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MinusOne()
        {
            var expected = new BigInteger(-1);
            var actual = BigRational.MinusOne.Numerator / BigRational.MinusOne.Denominator;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Denominator()
        {
            var expected = new BigInteger(4);
            var actual = new BigRational(3, 4).Denominator;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Numerator()
        {
            var expected = new BigInteger(3);
            var actual = new BigRational(3, 4).Numerator;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsOneTrue()
        {
            var actual = new BigRational(3, 3).IsOne;

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsOneFalse()
        {
            var actual = new BigRational(2, 3).IsOne;

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsZeroTrue()
        {
            var actual = new BigRational(0, 3).IsZero;

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsZeroFalse()
        {
            var actual = new BigRational(2, 3).IsZero;

            Assert.IsFalse(actual);
        }

        [Test]
        public void SignNegativeNumerator()
        {
            var expected = -1;
            var actual = new BigRational(-2, 3).Sign;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SignNegativeDenominator()
        {
            var expected = -1;
            var actual = new BigRational(1, -3).Sign;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SignPositive()
        {
            var expected = 1;
            var actual = new BigRational(2, 3).Sign;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SignZero()
        {
            var expected = 0;
            var actual = new BigRational(0, 3).Sign;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_SubtractionRational()
        {
            var expected = new BigRational(-2, 5);
            var actual = new BigRational(1, 5) - new BigRational(3, 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_SubtractionWholeNumber()
        {
            var expected = new BigRational(-2, 3);
            var actual = new BigRational(1, 3) - 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_SubtractionDifferentDenominator()
        {
            var expected = new BigRational(3, 4);
            var actual = new BigRational(1, 3) - new BigRational(2, 5);

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void op_UnaryNegationNegativeToPositive()
        {
            var expected = new BigRational(-1, 2);
            var actual = -new BigRational(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_UnaryNegationPositiveToNegative()
        {
            var expected = new BigRational(1, 2);
            var actual = -new BigRational(1, 2);

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void op_Decrement()
        {
            var expected = new BigRational(1, 3);
            var actual = new BigRational(2, 3);
            actual--;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_InequalityBigRationalNotEqualRationalTrue()
        {
            var actual = new BigRational(1, 3) != new BigRational(1, 2);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_InequalityRationalNotEqualIntTrue()
        {
            var actual = new BigRational(1, 3) != 2;

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_InequalityIntNotEqualRationalTrue()
        {
            var actual = 2 != new BigRational(1, 3);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_InequalityIntNotEqualRationalFalse()
        {
            var actual = 2 != new BigRational(4, 2);

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_Modulus()
        {
            var expected = new BigRational(1, 5);
            var actual = new BigRational(3, 5) % new BigRational(2, 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_MultiplyWholeNumber()
        {
            var expected = new BigRational(2, 3);
            var actual = new BigRational(1, 3) * 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_MultiplyRational()
        {
            var expected = new BigRational(1, 12);
            var actual = new BigRational(1, 6) * new BigRational(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_DivisionWholeNumber()
        {
            var expected = new BigRational(1, 6);
            var actual = new BigRational(1, 3) / 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_DivisionRational()
        {
            var expected = new BigRational(1, 3);
            var actual = new BigRational(1, 6) / new BigRational(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_AdditionRationalSameDenominator()
        {
            var expected = new BigRational(4, 5);
            var actual = new BigRational(1, 5) + new BigRational(3, 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_AdditionWholeNumber()
        {
            var expected = new BigRational(4, 3);
            var actual = new BigRational(1, 3) + 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_AdditionDifferentDenominator()
        {
            var expected = new BigRational(3, 4);
            var actual = new BigRational(1, 3) + new BigRational(2, 5);

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void op_Increment()
        {
            var expected = new BigRational(2, 3);
            var actual = new BigRational(1, 3);
            actual++;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_LessThanRational()
        {
            var actual = new BigRational(1, 3) < new BigRational(2, 5);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_LessThanRationalLessThanWholeNumber()
        {
            var actual = new BigRational(2, 5) < 1;

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_LessThanWholeNumberLessThanRational()
        {
            var actual = 1 < new BigRational(3, 2);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_LessThanWholeNumberLessThanRationalFalse()
        {
            var actual = 2 < new BigRational(1, 3);

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_LessThanOrEqual()
        {
            var actual = new BigRational(4, 6) <= new BigRational(2, 3);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_LessThanOrEqualLessWholeNumberLeft()
        {
            var actual = 1 <= new BigRational(3, 2);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_LessThanOrEqualGreaterWholeNumberLeft()
        {
            var actual = 2 <= new BigRational(3, 2);

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_LessThanOrEqualLessWholeNumberRight()
        {
            var actual = new BigRational(3, 2) <= 1;

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_LessThanOrEqualGreaterWholeNumberRight()
        {
            var actual = new BigRational(3, 2) <= 2;

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_EqualityReduction()
        {
            var actual = new BigRational(2, 3) == new BigRational(4, 6);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_EqualityWholeNumberRight()
        {
            var actual = new BigRational(9, 3) == 3;

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_EqualityWholeNumberLeft()
        {
            var actual = 3 == new BigRational(9, 3);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_EqualityNotEqualWholeNumber()
        {
            var actual = 4 == new BigRational(1, 3);

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_EqualityNull()
        {
            var actual = null == new BigRational(1, 3);

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_GreaterThan()
        {
            var actual = new BigRational(2, 5) > new BigRational(1, 3);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_GreaterThanWholeNumberLeft()
        {
            var actual = 1 > new BigRational(2, 5);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_GreaterThanWholeNumberRight()
        {
            var actual = new BigRational(3, 2) > 1;

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_GreaterThanWholeNumberRightFalse()
        {
            var actual = new BigRational(1, 3) > 2;

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_GreaterThanOrEqual()
        {
            var actual = new BigRational(2, 3) >= new BigRational(4, 6);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_GreaterThanOrEqualWholeNumberSmaller()
        {
            var actual = new BigRational(3, 2) >= 1;

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_GreaterThanOrEqualWholeNumberBigger()
        {
            var actual = new BigRational(3, 2) >= 2;

            Assert.IsFalse(actual);
        }

        [Test]
        public void op_GreaterThanOrEqualWholeNumberBiggerLeft()
        {
            var actual = 2 >= new BigRational(3, 2);

            Assert.IsTrue(actual);
        }

        [Test]
        public void op_ExplicitDouble()
        {
            var expected = 0.5;
            var actual = (double)new BigRational(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ExplicitDecimal()
        {
            var expected = 0.5;
            var actual = (decimal)new BigRational(1, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ExplicitBigIntegerTrue()
        {
            var expected = new BigInteger(3);
            var actual = (BigInteger)new BigRational(9, 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ExplicitBigIntergerFalse()
        {
            var expected = new BigInteger(4);
            var actual = (BigInteger)new BigRational(13, 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ImplicitInt()
        {
            var expected = new BigRational(4, 1);
            var actual = (BigRational)4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ImplicitLong()
        {
            var expected = new BigRational(4, 1);
            var actual = (BigRational)4L;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ImplicitBigInteger()
        {
            var expected = new BigRational(4, 1);
            var actual = (BigRational)new BigInteger(4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ImplicitDouble()
        {
            var expected = new BigRational(1, 2);
            var actual = (BigRational)0.5;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_ImplicitDecimal()
        {
            var expected = new BigRational(1, 2);
            var actual = (BigRational)0.5m;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PowSquaredRational()
        {
            var expected = new BigRational(1, 4);
            var actual = BigRational.Pow(new BigRational(1, 2), 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PowCubedRational()
        {
            var expected = new BigRational(8, 27);
            var actual = BigRational.Pow(new BigRational(2, 3), 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PowCubedWholeNumber()
        {
            var expected = new BigRational(27, 1);
            var actual = BigRational.Pow(new BigRational(3, 1), 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AbsNegative()
        {

            var expected = new BigRational(2, 3);
            var actual = BigRational.Abs(new BigRational(-2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AbsPositive()
        {
            var expected = new BigRational(2, 3);
            var actual = BigRational.Abs(new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Inverse()
        {
            var expected = new BigRational(3, 2);
            var actual = BigRational.Inverse(new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MaxRight()
        {
            var r1 = new BigRational(2, 3);
            var r2 = new BigRational(3, 4);

            var actual = BigRational.Max(r1, r2);

            Assert.AreEqual(r2, actual);
        }

        [Test]
        public void MaxLeft()
        {
            var r1 = new BigRational(2, 3);
            var r2 = new BigRational(3, 4);

            var actual = BigRational.Max(r2, r1);

            Assert.AreEqual(r2, actual);
        }

        [Test]
        public void MinLeft()
        {
            var r1 = new BigRational(2, 3);
            var r2 = new BigRational(3, 4);

            var actual = BigRational.Min(r1, r2);

            Assert.AreEqual(r1, actual);
        }

        [Test]
        public void MinRight()
        {
            var r1 = new BigRational(2, 3);
            var r2 = new BigRational(3, 4);

            var actual = BigRational.Min(r2, r1);

            Assert.AreEqual(r1, actual);
        }

        [Test]
        public void SqrtPerfectSquare()
        {
            var expected = new BigRational(5, 2);
            var actual = BigRational.Sqrt(new BigRational(25, 4), 10);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SqrtIrrational()
        {
            var expected = BigRational.SqrtAsRationals(2).Skip(100).First();
            var actual = BigRational.Sqrt(new BigRational(2), 13);

            Assert.Less(BigRational.Abs(expected - actual), new BigRational(1, 1000000000));
        }

        [Test]
        public void SumBigRational()
        {
            var expected = new BigRational(6);
            var actual = Enumerable.Range(1, 3).Select(i => new BigRational(i)).Sum();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SqrtAsContinuedFractionSquareInt()
        {
            var expected = new int[] { 5 };
            var actual = BigRational.SqrtAsContinuedFraction(25).Take(5);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void SqrtAsContinuedFraction()
        {
            var expected = new int[] { 1, 2 };
            var actual = BigRational.SqrtAsContinuedFraction(2).Take(5);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void SqrtAsContinuedFractionSquare()
        {
            var expected = new BigInteger[] { 5 };
            var actual = BigRational.SqrtAsContinuedFraction(new BigInteger(25)).Take(5);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
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

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
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

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void WholePart()
        {
            var expected = new BigInteger(6);
            var actual = new BigRational(25, 4).GetWholePart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FractionPart()
        {
            var expected = new BigRational(1, 4);
            var actual = new BigRational(25, 4).GetFractionPart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToEqual()
        {
            var expected = 0;
            var actual = new BigRational(2, 3).CompareTo(new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToLess()
        {
            var expected = -1;
            var actual = new BigRational(1, 3).CompareTo(new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToGreater()
        {
            var expected = 1;
            var actual = new BigRational(4, 3).CompareTo(new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToObjectEqual()
        {
            var expected = 0;
            var actual = new BigRational(2, 3).CompareTo((object)new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToObjectGreater()
        {
            var expected = -1;
            var actual = new BigRational(1, 3).CompareTo((object)new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToObjectLess()
        {
            var expected = 1;
            var actual = new BigRational(4, 3).CompareTo((object)new BigRational(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareToNotBigRational()
        {
            Assert.Throws<ArgumentException>(() => new BigRational(4, 3).CompareTo((object)Tuple.Create(2, 3)));
        }

        [Test]
        public void EqualsRationalTrue()
        {
            var actual = new BigRational(2, 3).Equals(new BigRational(2, 3));

            Assert.IsTrue(actual);
        }

        [Test]
        public void EqualsRationalFalse()
        {
            var actual = new BigRational(2, 3).Equals(new BigRational(1, 3));

            Assert.IsFalse(actual);
        }

        [Test]
        public void EqualsRationalObjectTrue()
        {
            var actual = new BigRational(2, 3).Equals((object)new BigRational(2, 3));

            Assert.IsTrue(actual);
        }

        [Test]
        public void EqualsRationalObjectFalse()
        {
            var actual = new BigRational(2, 3).Equals((object)new BigRational(1, 3));

            Assert.IsFalse(actual);
        }

        [Test]
        public void GetHashCodeTrue()
        {
            var expected = new BigRational(2, 3).GetHashCode();
            var actual = new BigRational(2, 3).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHashCodeFalse()
        {
            var expected = new BigRational(2, 3).GetHashCode();
            var actual = new BigRational(3, 5).GetHashCode();

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void ToString()
        {
            var expected = "2/3";
            var actual = new BigRational(2, 3).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToStringFormat()
        {
            var expected = "2/3";
            var actual = new BigRational(2, 3).ToString("{0}/{1}", null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToStringZero()
        {
            var expected = "0";
            var actual = new BigRational(0, 2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToStringWholeNumber()
        {
            var expected = "2";
            var actual = new BigRational(2, 1).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToStringNullFormat()
        {
            var expected = "2";
            var actual = new BigRational(2, 1).ToString(null, null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToDecimalString()
        {
            var expected = "0.33";
            var actual = new BigRational(1, 3).ToDecimalString(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToDecimalStringWholeNumber()
        {
            var expected = "3.0";
            var actual = new BigRational(3, 1).ToDecimalString(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToDecimalStringNotPreciseEnough()
        {
            var expected = "0.0";
            var actual = new BigRational(1, 300).ToDecimalString(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToDecimalStringTrailingZeros()
        {
            var expected = "0.5";
            var actual = new BigRational(1, 2).ToDecimalString(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PI()
        {
            var expected = Math.PI;
            var actual = BigRational.PI;

            Assert.Less(BigRational.Abs(expected - actual), new BigRational(1, 100000000000000));
        }

        [Test]
        public void E()
        {
            var expected = Math.E;
            var actual = BigRational.E;

            Assert.Less(BigRational.Abs(expected - actual), new BigRational(1, 100000000000000));
        }
    }
}