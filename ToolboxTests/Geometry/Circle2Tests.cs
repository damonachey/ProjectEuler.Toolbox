using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class Circle2Tests
    {
        [Test]
        public void Circle2Constructor()
        {
            var c = new Point2<double>(1, 1);
            var r = 1;
            var actual = new Circle2(c, r);

            Assert.AreEqual(c, actual.C);
            Assert.AreEqual(r, actual.R);
        }

        [Test]
        public void Area()
        {
            var expected = Math.PI;
            var c = new Point2<double>(1, 1);
            var r = 1;
            var actual = new Circle2(c, r).Area();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Circumfrence()
        {
            var expected = 2 * Math.PI;
            var c = new Point2<double>(1, 1);
            var r = 1;
            var actual = new Circle2(c, r).Circumfrence();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChordAngle()
        {
            var expected = 1.047;
            var actual = Circle2.ChordAngle(2, 2);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public void SegmentArea()
        {
            var expected = 1.141;
            var actual = Circle2.SegmentArea(Math.PI / 2, 2);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public new void ToString()
        {
            var expected = "(1, 1) R = 1";
            var c = new Point2<double>(1, 1);
            var r = 1;
            var actual = new Circle2(c, r).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}