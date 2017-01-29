using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class Line2Tests
    {
        [Test]
        public void Line2()
        {
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(3, 4);
            var actual = new Line2(p1, p2);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
        }

        [Test]
        public void Line2Slope()
        {
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(0, 1.5);
            var slope = 0.5;
            var actual = new Line2(p1, slope);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
        }

        [Test]
        public void Slope()
        {
            var expected = 0.5;
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(0, 1.5);
            var actual = new Line2(p1, p2).Slope();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Intercept()
        {
            var expected = 0.5;
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(3, 5);
            var actual = new Line2(p1, p2).Intercept();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Length()
        {
            var expected = 3.60555;
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(3, 5);
            var actual = new Line2(p1, p2).Length();

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [Test]
        public void IntersectsTrue()
        {
            var expected = new Point2<double>(1, 3);
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(1, 4);
            var line1 = new Line2(p1, p2);

            var p3 = new Point2<double>(0, 3);
            var p4 = new Point2<double>(2, 3);
            var line2 = new Line2(p3, p4);

            var p = default(Point2<double>);

            var actual = line1.Intersects(line2, out p);

            Assert.IsTrue(actual);
            Assert.AreEqual(expected, p);
        }

        [Test]
        public void IntersectsFalse()
        {
            var expected = default(Point2<double>);
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(3, 4);
            var line1 = new Line2(p1, p2);

            var p3 = new Point2<double>(2, 2);
            var p4 = new Point2<double>(4, 3);
            var line2 = new Line2(p3, p4);

            var p = default(Point2<double>);

            var actual = line1.Intersects(line2, out p);

            Assert.IsFalse(actual);
            Assert.AreEqual(expected, p);
        }

        [Test]
        public void ReflectPoint()
        {
            var expected = new Point2<double>(0.2, 2.6);
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(0, 1.5);
            var p3 = new Point2<double>(1, 1);
            var actual = new Line2(p1, p2).ReflectPoint(p3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4))";
            var p1 = new Point2<double>(1, 2);
            var p2 = new Point2<double>(3, 4);
            var actual = new Line2(p1, p2).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}