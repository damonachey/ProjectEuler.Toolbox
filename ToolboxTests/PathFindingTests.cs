using NUnit.Framework;
using ProjectEuler.Toolbox;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class PathFindingTests
    {
        [Test]
        public void DijkstraMinPathWeightRightAndDown()
        {
            var expected = 16;

            var grid = new long[,]
            {
                { 1, 2, 6, 4 },
                { 4, 4, 3, 4 },
                { 1, 2, 3, 4 },
                { 1, 2, 3, 4 },
            };

            var actual = grid.DijkstraMinPathWeight(grid.UpperLeft(), grid.LowerRight(), PathFinding.NeighborsRightAndDown);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DijkstraMinPathWeightNeighbors4()
        {
            var expected = 16;

            var grid = new long[,]
            {
                { 1, 2, 6, 4 },
                { 4, 4, 3, 4 },
                { 1, 2, 3, 4 },
                { 1, 2, 3, 4 },
            };

            var actual = grid.DijkstraMinPathWeight(grid.UpperLeft(), grid.LowerRight(), PathFinding.Neighbors4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DijkstraMinPathWeightNeighbors8()
        {
            var expected = 12;

            var grid = new long[,]
            {
                { 1, 2, 6, 4 },
                { 4, 4, 3, 4 },
                { 1, 2, 3, 4 },
                { 1, 2, 3, 4 },
            };

            var actual = grid.DijkstraMinPathWeight(grid.UpperLeft(), grid.LowerRight(), PathFinding.Neighbors8);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Astar()
        {
            var expected = new[]
            {
                new PathFinding.Coordinate(0, 0),           
                new PathFinding.Coordinate(1, 0),           
                new PathFinding.Coordinate(2, 0),           
                new PathFinding.Coordinate(3, 0),           
                new PathFinding.Coordinate(3, 1),           
                new PathFinding.Coordinate(3, 2),           
                new PathFinding.Coordinate(3, 3),
            };

            var grid = new long[,]
            {
                { 1, 2, 3, 4 },
                { 1, 2, 3, 4 },
                { 1, 2, 3, 4 },
                { 1, 2, 3, 4 },
            };

            var actual = grid
                .Astar(grid.UpperLeft(), grid.LowerRight(), PathFinding.NeighborsRightAndDown)
                .ToList();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CoordinateEquals()
        {
            var expected = new PathFinding.Coordinate(1, 2);
            var actual = (object)new PathFinding.Coordinate(1, 2);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void CoordinateEqualsCoordinateNull()
        {
            var expected = new PathFinding.Coordinate(1, 2);
            var actual = default(PathFinding.Coordinate);

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void CoordinateEqualsNotCoordinateNull()
        {
            var expected = new PathFinding.Coordinate(1, 2);
            var actual = (object)null;

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void CoordinateEqualsNotCoordinateOther()
        {
            var expected = new PathFinding.Coordinate(1, 2);
            var actual = 1;

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void CoordinateToString()
        {
            var expected = "(1, 2)";
            var actual = new PathFinding.Coordinate(1, 2).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
