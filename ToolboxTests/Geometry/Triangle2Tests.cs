using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Triangle2Tests
    {
        [TestMethod]
        public void Triangle2()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var p3 = new Point2(5, 6);
            var actual = new Triangle2(p1, p2, p3);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
            Assert.AreEqual(p3, actual.P3);
        }

        [TestMethod]
        public void AreaLong()
        {
            var expected = 1.5;
            var p1 = new Point2(0, 0);
            var p2 = new Point2(1, 1);
            var p3 = new Point2(3, 0);
            var actual = new Triangle2(p1, p2, p3).Area();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreaDouble()
        {
            var expected = 1.5;
            var p1 = new Point2(0, 0);
            var p2 = new Point2(1, 1);
            var p3 = new Point2(3, 0);
            var actual = new Triangle2(p1, p2, p3).Area();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsFalse()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var p3 = new Point2(5, 6);
            var t1 = new Triangle2(p1, p2, p3);

            var p4 = new Point2(2, 2);
            var p5 = new Point2(3, 4);
            var p6 = new Point2(5, 6);
            var t2= new Triangle2(p4, p5, p6);

            Assert.AreNotEqual(t1, t2);
        }

        [TestMethod]
        public void EqualsTrue()
        {
            var p1 = new Point2(1.000001, 2);
            var p2 = new Point2(3, 4);
            var p3 = new Point2(5, 6);
            var t1 = new Triangle2(p1, p2, p3);

            var p4 = new Point2(1, 2);
            var p5 = new Point2(3, 4);
            var p6 = new Point2(5, 6);
            var t2 = new Triangle2(p4, p5, p6);

            Assert.AreEqual(t1, t2);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4), (5, 6))";
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var p3 = new Point2(5, 6);
            var actual = new Triangle2(p1, p2, p3).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}