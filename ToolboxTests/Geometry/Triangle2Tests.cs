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
        public void AreaLong()
        {
            var expected = 1.5;
            var p1 = new Point2<long>(0, 0);
            var p2 = new Point2<long>(1, 1);
            var p3 = new Point2<long>(3, 0);
            var actual = new Triangle2<long>(p1, p2, p3).Area();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreaDouble()
        {
            var expected = 1.5;
            var p1 = new Point2<double>(0, 0);
            var p2 = new Point2<double>(1, 1);
            var p3 = new Point2<double>(3, 0);
            var actual = new Triangle2<double>(p1, p2, p3).Area();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreaNotSupported()
        {
            var p1 = new Point2<int>(0, 0);
            var p2 = new Point2<int>(1, 1);
            var p3 = new Point2<int>(3, 0);

            Assert.Throws<NotSupportedException>(() => new Triangle2<int>(p1, p2, p3).Area());
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