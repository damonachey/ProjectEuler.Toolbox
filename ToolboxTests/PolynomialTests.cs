using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System.Linq;
using System.Windows;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void Lagrange()
        {
            var input = new Point2[]
                {
                    new Point2(1, 1),
                    new Point2(2, 8),
                    new Point2(3, 27),
                    new Point2(4, 64),
                };
            var expected = new Point2[]
                {
                    new Point2(1, 1),
                    new Point2(2, 8),
                    new Point2(3, 27),
                    new Point2(4, 64),
                    new Point2(5, 125),
                    new Point2(6, 216),
                };
            var actual = Polynomial
                .Lagrange(input, 1, 1)
                .Take(6)
                .ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void LagrangeDouble()
        {
            var input = new Point2[]
                {
                    new Point2(1, 1),
                    new Point2(2, 8),
                    new Point2(3, 27),
                };
            var expected = new Point2[]
                {
                    new Point2(1.0, 1),
                    new Point2(1.5, 3),
                    new Point2(2.0, 8),
                    new Point2(2.5, 16),
                    new Point2(3.0, 27),
                };
            var actual = Polynomial
                .Lagrange(input, 1, 0.5)
                .Take(5)
                .ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}