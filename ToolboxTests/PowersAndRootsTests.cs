using System;
using System.Numerics;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class PowersAndRootsTests
    {
        [Test]
        public void IsPerfectSquareFalse()
        {
            var actual = PowersAndRoots.IsPerfectSquare(9223372036854775807);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPerfectSquareFalse2()
        {
            var actual = PowersAndRoots.IsPerfectSquare(24);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPerfectSquareTrue()
        {
            var actual = PowersAndRoots.IsPerfectSquare(9223372036854775808);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPerfectSquareBigIntegerTrue()
        {
            var actual = PowersAndRoots.IsPerfectSquare(BigInteger.Parse("119395365954817634641176944193187475791716"));

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPerfectSquareBigIntegerFalse()
        {
            var actual = PowersAndRoots.IsPerfectSquare(BigInteger.Parse("119395365954817634641176944193187475791715"));

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPerfectSquareBigIntegerFalse2()
        {
            var actual = PowersAndRoots.IsPerfectSquare(new BigInteger(24));

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPerfectSquareZero()
        {
            var actual = PowersAndRoots.IsPerfectSquare(0);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPerfectSquareOne()
        {
            var actual = PowersAndRoots.IsPerfectSquare(1);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPerfectSquareNegative()
        {
            var actual = PowersAndRoots.IsPerfectSquare(-4);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPerfectSquareBigIntegerZero()
        {
            var actual = PowersAndRoots.IsPerfectSquare(BigInteger.Zero);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPerfectSquareBigIntegerOne()
        {
            var actual = PowersAndRoots.IsPerfectSquare(new BigInteger(1));

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPerfectSquareBigIntegerNegative()
        {
            var actual = PowersAndRoots.IsPerfectSquare(new BigInteger(-4));

            Assert.IsFalse(actual);
        }

        [Test]
        public void SqrtFloor()
        {
            var expected = new BigInteger(35130);
            var actual = PowersAndRoots.SqrtFloor(1234134534);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SqrtFloorZero()
        {
            var expected = BigInteger.Zero;
            var actual = PowersAndRoots.SqrtFloor(BigInteger.Zero);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SqrtFloorNegative()
        {
            Assert.Throws<ArithmeticException>(() => PowersAndRoots.SqrtFloor(BigInteger.MinusOne));
        }

        [Test]
        public void SqrtIrrational()
        {
            var expected = 1.4142135623730950488016887242m;
            var actual = PowersAndRoots.Sqrt(2m);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SqrtSquare()
        {
            var expected = 4;
            var actual = PowersAndRoots.Sqrt(16m);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SqrtZero()
        {
            var expected = 0;
            var actual = PowersAndRoots.Sqrt(0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SqrtDecimalNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PowersAndRoots.Sqrt(-2));
        }
    }
}