using ProjectEuler.Toolbox;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class PathFindingTests
{
    [Fact]
    public void DijkstraMinPathWeightStartGoal()
    {
        var expected = 12;

        var grid = new long[,]
        {
            { 1, 2, 6, 4 },
            { 4, 4, 3, 4 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
        };

        var actual = grid.DijkstraMinPathWeight(grid.UpperLeft(), grid.LowerRight());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DijkstraMinPathWeightStart()
    {
        var expected = new long[,]
        {
            { 1, 3, 9, 10 },
            { 5, 5, 6, 10 },
            { 6, 7, 8, 10 },
            { 7, 8, 10, 12 },
        };

        var grid = new long[,]
        {
            { 1, 2, 6, 4 },
            { 4, 4, 3, 4 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
        };

        var actual = grid.DijkstraMinPathWeights(grid.UpperLeft());

        Assert.Equal(expected.GetLength(0), actual.GetLength(0));
        Assert.Equal(expected.GetLength(1), actual.GetLength(1));

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                Assert.True(expected[i, j] == actual[i, j], $"expected[{i}, {j}]: {expected[i, j]} != actual[{i}, {j}]: {actual[i, j]}");
            }
        }
    }

    [Fact]
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

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DijkstraMinPathWeightStartNeighbors()
    {
        var expected = new long[,]
        {
            { 1, 3, 9, 13 },
            { 5, 7, 10, 14 },
            { 6, 8, 11, 15 },
            { 7, 9, 12, 16 },
        };

        var grid = new long[,]
        {
            { 1, 2, 6, 4 },
            { 4, 4, 3, 4 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
        };

        var actual = grid.DijkstraMinPathWeights(grid.UpperLeft(), PathFinding.NeighborsRightAndDown);

        Assert.Equal(expected.GetLength(0), actual.GetLength(0));
        Assert.Equal(expected.GetLength(1), actual.GetLength(1));

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                Assert.True(expected[i, j] == actual[i, j], $"expected[{i}, {j}]: {expected[i, j]} != actual[{i}, {j}]: {actual[i, j]}");
            }
        }
    }

    [Fact]
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

        Assert.Equal(expected, actual);
    }

    [Fact]
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

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AstarStartGoal()
    {
        var expected = new[]
        {
            new PathFinding.Coordinate(0, 0),
            new PathFinding.Coordinate(1, 1),
            new PathFinding.Coordinate(2, 2),
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
            .Astar(grid.UpperLeft(), grid.LowerRight())
            .ToList();

        Assert.True(expected.SequenceEqual(actual), actual.EnumerableToString());
    }

    [Fact]
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

        Assert.True(expected.SequenceEqual(actual), actual.EnumerableToString());
    }

    [Fact]
    public void CoordinateEquals()
    {
        var expected = new PathFinding.Coordinate(1, 2);
        var actual = (object)new PathFinding.Coordinate(1, 2);

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void CoordinateEqualsCoordinateNull()
    {
        var expected = new PathFinding.Coordinate(1, 2);
        var actual = default(PathFinding.Coordinate);

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void CoordinateEqualsNotCoordinateNull()
    {
        var expected = new PathFinding.Coordinate(1, 2);
        var actual = (object)null;

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void CoordinateEqualsNotCoordinateOther()
    {
        var expected = new PathFinding.Coordinate(1, 2);
        var actual = 1;

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void CoordinateToString()
    {
        var expected = "(1, 2)";
        var actual = new PathFinding.Coordinate(1, 2).ToString();

        Assert.Equal(expected, actual);
    }
}
