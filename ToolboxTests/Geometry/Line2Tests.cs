using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Line2Tests
    {
        [TestMethod]
        public void Line2()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var actual = new Line2(p1, p2);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
        }

        [TestMethod]
        public void Line2Slope()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(0, 1.5);
            var slope = 0.5;
            var actual = new Line2(p1, slope);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Line2SlopeInfinate()
        {
            var p1 = new Point2(0, 2);
            var p2 = new Point2(0, 1.5);
            var slope = 0.5;

            new Line2(p1, slope);
        }

        [TestMethod]
        public void Slope()
        {
            var expected = 0.5;
            var p1 = new Point2(1, 2);
            var p2 = new Point2(0, 1.5);
            var actual = new Line2(p1, p2).Slope();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intercept()
        {
            var expected = 0.5;
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 5);
            var actual = new Line2(p1, p2).Intercept();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Length()
        {
            var expected = 3.60555;
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 5);
            var actual = new Line2(p1, p2).Length();

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void IntersectsTrue()
        {
            var expected = new Point2(1, 3);
            var p1 = new Point2(1, 2);
            var p2 = new Point2(1, 4);
            var line1 = new Line2(p1, p2);

            var p3 = new Point2(0, 3);
            var p4 = new Point2(2, 3);
            var line2 = new Line2(p3, p4);

            var actual = line1.Intersects(line2, out Point2 p);

            Assert.IsTrue(actual);
            Assert.AreEqual(expected, p);
        }

        [TestMethod]
        public void IntersectsFalse()
        {
            var expected = default(Point2);
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var line1 = new Line2(p1, p2);

            var p3 = new Point2(2, 2);
            var p4 = new Point2(4, 3);
            var line2 = new Line2(p3, p4);

            var actual = line1.Intersects(line2, out Point2 p);

            Assert.IsFalse(actual);
            Assert.AreEqual(expected, p);
        }

        [TestMethod]
        public void ReflectPoint()
        {
            var expected = new Point2(0.2, 2.6);
            var p1 = new Point2(1, 2);
            var p2 = new Point2(0, 1.5);
            var p3 = new Point2(1, 1);
            var actual = new Line2(p1, p2).ReflectPoint(p3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4))";
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var actual = new Line2(p1, p2).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}