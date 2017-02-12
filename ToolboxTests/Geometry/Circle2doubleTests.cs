using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Circle2doubleTests
    {
        [TestMethod]
        public void Circle2doubleConstructor()
        {
            var c = new Point2double(1, 1);
            var r = 1;
            var actual = new Circle2double(c, r);

            Assert.AreEqual(c, actual.C);
            Assert.AreEqual(r, actual.R);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "(1, 1) R = 1";
            var c = new Point2double(1, 1);
            var r = 1;
            var actual = new Circle2double(c, r).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsObjectFalse()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 2);

            Assert.IsFalse(c1.Equals((object)c2));
        }

        [TestMethod]
        public void EqualsObjectTrue()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 1);

            Assert.IsTrue(c1.Equals((object)c2));
        }

        [TestMethod]
        public void EqualsCircle2doubleFalse()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 2);

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void EqualsCircle2doubleTrue()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 1);

            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 1072693248;
            var c = new Point2double(1, 1);
            var actual = new Circle2double(c, 1).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorEqualsFalse()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 2);

            Assert.IsFalse(c1 == c2);
        }

        [TestMethod]
        public void OperatorEqualsTrue()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 1);

            Assert.IsTrue(c1 == c2);
        }

        [TestMethod]
        public void OperatorNotEqualsFalse()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 1);

            Assert.IsFalse(c1 != c2);
        }

        [TestMethod]
        public void OperatorNotEqualsTrue()
        {
            var c = new Point2double(1, 1);
            var c1 = new Circle2double(c, 1);
            var c2 = new Circle2double(c, 2);

            Assert.IsTrue(c1 != c2);
        }
    }
}