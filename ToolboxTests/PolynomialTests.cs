using NUnit.Framework;
using ProjectEuler.Toolbox;
using System.Linq;
using System.Windows;

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
    }
}