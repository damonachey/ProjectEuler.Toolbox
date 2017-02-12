using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Circle2ExtensionsTests
    {
        [TestMethod]
        public void Area()
        {
            var expected = Math.PI;
            var c = new Point2double(1, 1);
            var r = 1;
            var actual = new Circle2double(c, r).Area();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circumfrence()
        {
            var expected = 2 * Math.PI;
            var c = new Point2double(1, 1);
            var r = 1;
            var actual = new Circle2double(c, r).Circumfrence();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChordAngle()
        {
            var expected = 1.047;
            var actual = Circle2Extensions.ChordAngle(2, 2);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void SegmentArea()
        {
            var expected = 1.141;
            var actual = Circle2Extensions.SegmentArea(Math.PI / 2, 2);

            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}