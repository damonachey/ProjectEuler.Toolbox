using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Circle2Tests
    {
        [TestMethod]
        public void Circle2Constructor()
        {
            var c = new Point2(1, 1);
            var r = 1;
            var actual = new Circle2(c, r);

            Assert.AreEqual(c, actual.C);
            Assert.AreEqual(r, actual.R);
        }

        [TestMethod]
        public void Area()
        {
            var expected = Math.PI;
            var c = new Point2(1, 1);
            var r = 1;
            var actual = new Circle2(c, r).Area();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circumfrence()
        {
            var expected = 2 * Math.PI;
            var c = new Point2(1, 1);
            var r = 1;
            var actual = new Circle2(c, r).Circumfrence();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChordAngle()
        {
            var expected = 1.047;
            var actual = Circle2.ChordAngle(2, 2);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void SegmentArea()
        {
            var expected = 1.141;
            var actual = Circle2.SegmentArea(Math.PI / 2, 2);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "(1, 1) R = 1";
            var c = new Point2(1, 1);
            var r = 1;
            var actual = new Circle2(c, r).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}