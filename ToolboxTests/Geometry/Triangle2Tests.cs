using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class Triangle2Tests
    {
        [Test]
        public void Triangle2()
        {
            var p1 = new Point2<long>(1, 2);
            var p2 = new Point2<long>(3, 4);
            var p3 = new Point2<long>(5, 6);
            var actual = new Triangle2<long>(p1, p2, p3);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
            Assert.AreEqual(p3, actual.P3);
        }

        [Test]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4), (5, 6))";
            var p1 = new Point2<long>(1, 2);
            var p2 = new Point2<long>(3, 4);
            var p3 = new Point2<long>(5, 6);
            var actual = new Triangle2<long>(p1, p2, p3).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}