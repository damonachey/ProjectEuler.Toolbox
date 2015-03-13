using System;
using System.Linq;
using System.Windows;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void Diamonds()
        {
            var expected = 3669546;
            var actual = Geometry.Diamonds(77, 36);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PointInTriangleTrue()
        {
            var actual = Geometry.IsPointInTriangle(
                new Microsoft.Xna.Framework.Vector3(0),
                new Microsoft.Xna.Framework.Vector3(0, 1, 0),
                new Microsoft.Xna.Framework.Vector3(1, -1, 0),
                new Microsoft.Xna.Framework.Vector3(-1, -1, 0));

            Assert.IsTrue(actual);
        }

        [Test]
        public void PointInTriangleFalse()
        {
            var actual = Geometry.IsPointInTriangle(
                new Microsoft.Xna.Framework.Vector3(2, 0, 0),
                new Microsoft.Xna.Framework.Vector3(0, 1, 0),
                new Microsoft.Xna.Framework.Vector3(1, -1, 0),
                new Microsoft.Xna.Framework.Vector3(-1, -1, 0));

            Assert.IsFalse(actual);
        }

        [Test]
        public void PythagoreanTriples()
        {
            var expected = new Tuple<int, int, int>[]
                {
                    Tuple.Create(3, 4, 5),
                    Tuple.Create(6, 8, 10),
                    Tuple.Create(9, 12, 15),
                    Tuple.Create(8, 15, 17),
                    Tuple.Create(5, 12, 13),
                };

            var actual = Geometry.PythagoreanTriples(42);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void Distance()
        {
            var expected = new BigRational(5);
            var p1 = new Point2<BigRational>(1, 2);
            var p2 = new Point2<BigRational>(4, 6);
            var actual = Geometry.Distance(p1, p2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rectangles()
        {
            var expected = 1999998;
            var actual = Geometry.Rectangles(77, 36);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BigRationalPointConstructor()
        {
            var p = new Point2<BigRational>(1, 2);

            Assert.IsNotNull(p);
        }

        [Test]
        public void Point3()
        {
            var actual = new Point3<long>(1, 2, 3);

            Assert.AreEqual(1, actual.X);
            Assert.AreEqual(2, actual.Y);
            Assert.AreEqual(3, actual.Z);
        }

        [Test]
        public void BigRationalSquare2()
        {
            var expected = "((INF, INF), (INF, INF), (INF, INF), (INF, INF))";
            var actual = new Polygon2<BigRational>(default(Point2<BigRational>), default(Point2<BigRational>), default(Point2<BigRational>), default(Point2<BigRational>)).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BigRationalPoint2()
        {
            var expected = "(INF, INF)";
            var actual = new Point2<BigRational>().ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}