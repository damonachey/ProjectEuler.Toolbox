using System.Linq;
using System.Windows;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Lagrange()
        {
            var input = new Vector[]
                {
                    new Vector(1, 1),
                    new Vector(2, 8),
                    new Vector(3, 27),
                    new Vector(4, 64),
                };
            var expected = new Vector[]
                {
                    new Vector(1, 1),
                    new Vector(2, 8),
                    new Vector(3, 27),
                    new Vector(4, 64),
                    new Vector(5, 125),
                    new Vector(6, 216),
                };
            var actual = Polynomial
                .Lagrange(input, 1, 1)
                .Take(6)
                .ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void LagrangeDouble()
        {
            var input = new Vector[]
                {
                    new Vector(1, 1),
                    new Vector(2, 8),
                    new Vector(3, 27),
                };
            var expected = new Vector[]
                {
                    new Vector(1.0, 1),
                    new Vector(1.5, 3),
                    new Vector(2.0, 8),
                    new Vector(2.5, 16),
                    new Vector(3.0, 27),
                };
            var actual = Polynomial
                .Lagrange(input, 1, 0.5)
                .Take(5)
                .ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }


        // TODO: [Test]
        public void LagrangeCoefficients()
        {
            var input = new Point2DBigRational[]
                {
                    new Point2DBigRational(1, 1),
                    new Point2DBigRational(2, 8),
                    new Point2DBigRational(3, 27),
                    new Point2DBigRational(4, 64),
                };
            var expected = new BigRational[]
                {
                    new BigRational(0, 1),
                    new BigRational(0, 1),
                    new BigRational(0, 1),
                    new BigRational(1, 1),
                };

            // x^3
            var actual = Polynomial
                .LagrangeCoefficients(input)
                .ToList();

            //Assert.IsTrue(expected.SequenceEqual(actual));
        }

        // TODO: [Test]
        public void LagrangeLarge()
        {
            var input = new Point2DBigRational[]
                {
                    new Point2DBigRational(1, 1),
                    new Point2DBigRational(2, 683),
                    new Point2DBigRational(3, 44287),
                    new Point2DBigRational(4, 838861),
                    new Point2DBigRational(4, 8138021),
                    new Point2DBigRational(4, 51828151),
                    new Point2DBigRational(4, 247165843),
                    new Point2DBigRational(4, 954437177),
                    new Point2DBigRational(4, 3138105961),
                    new Point2DBigRational(4, 9090909091),
                    new Point2DBigRational(4, 23775972551),
                };
            var expected = new BigRational[]
                {
                    new BigRational(1, 1),
                    new BigRational(-1, 1),
                    new BigRational(1, 1),
                    new BigRational(-1, 1),
                    new BigRational(1, 1),
                    new BigRational(-1, 1),
                    new BigRational(1, 1),
                    new BigRational(-1, 1),
                    new BigRational(1, 1),
                    new BigRational(-1, 1),
                    new BigRational(1, 1),
                };

            // 1 - n + n^2 - n^3 + n^4 - n^5 + n^6 - n^7 + n^8 - n^9 + n^10
            var actual = Polynomial
                .LagrangeCoefficients(input)
                .ToList();

            //Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}