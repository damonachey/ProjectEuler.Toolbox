using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Polygon2BigRationalTests
    {
        [TestMethod]
        public void Polygon2BigRationalConstructor()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var actual = new Polygon2BigRational(p1, p2, p3, p4);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
            Assert.AreEqual(p3, actual.P3);
            Assert.AreEqual(p4, actual.P4);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4), (5, 6), (7, 8))";
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var actual = new Polygon2BigRational(p1, p2, p3, p4).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsObjectFalse()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var p5 = new Point2BigRational(9, 10);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

            Assert.IsFalse(pol1.Equals((object)pol2));
        }

        [TestMethod]
        public void EqualsObjectTrue()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

            Assert.IsTrue(pol1.Equals((object)pol2));
        }

        [TestMethod]
        public void EqualsLine2BigRationalFalse()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var p5 = new Point2BigRational(9, 10);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

            Assert.IsFalse(pol1.Equals(pol2));
        }

        [TestMethod]
        public void EqualsLine2BigRationalTrue()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

            Assert.IsTrue(pol1.Equals(pol2));
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 8;
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var actual = new Polygon2BigRational(p1, p2, p3, p4).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorEqualsFalse()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var p5 = new Point2BigRational(9, 10);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

            Assert.IsFalse(pol1 == pol2);
        }

        [TestMethod]
        public void OperatorEqualsTrue()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

            Assert.IsTrue(pol1 == pol2);
        }

        [TestMethod]
        public void OperatorNotEqualsFalse()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p4);

            Assert.IsFalse(pol1 != pol2);
        }

        [TestMethod]
        public void OperatorNotEqualsTrue()
        {
            var p1 = new Point2BigRational(1, 2);
            var p2 = new Point2BigRational(3, 4);
            var p3 = new Point2BigRational(5, 6);
            var p4 = new Point2BigRational(7, 8);
            var p5 = new Point2BigRational(9, 10);
            var pol1 = new Polygon2BigRational(p1, p2, p3, p4);
            var pol2 = new Polygon2BigRational(p1, p2, p3, p5);

            Assert.IsTrue(pol1 != pol2);
        }
    }
}