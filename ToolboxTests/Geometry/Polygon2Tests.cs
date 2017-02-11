using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Polygon2Tests
    {
        [TestMethod]
        public void Polygon2()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var p3 = new Point2(5, 6);
            var p4 = new Point2(7, 8);
            var actual = new Polygon2(p1, p2, p3, p4);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
            Assert.AreEqual(p3, actual.P3);
            Assert.AreEqual(p4, actual.P4);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4), (5, 6), (7, 8))";
            var p1 = new Point2(1, 2);
            var p2 = new Point2(3, 4);
            var p3 = new Point2(5, 6);
            var p4 = new Point2(7, 8);
            var actual = new Polygon2(p1, p2, p3, p4).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}