using ProjectEuler.Toolbox;
using System;
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
    public void AStarStartGoal()
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
            .AStar(grid.UpperLeft(), grid.LowerRight())
            .ToArray();

        Assert.True(expected.SequenceEqual(actual), actual.EnumerableToString());
    }

    [Fact]
    public void AStar()
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
            .AStar(grid.UpperLeft(), grid.LowerRight(), PathFinding.NeighborsRightAndDown)
            .ToArray();

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
    public void CoordinateEqualsNotCoordinateNull()
    {
        var expected = new PathFinding.Coordinate(1, 2);
        var actual = (object?)null;

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

    [Fact]
    public void AStarReparentsNodeOnBetterPath()
    {
        // Regression: A* must update a node's parent when a cheaper route is discovered later.
        // The buggy implementation produced the suboptimal path
        // (0,2)->(1,2)->(2,2)->(3,3)->(4,4) with weight 18 instead of the optimal 17.
        var grid = new long[,]
        {
            { 7, 3, 7, 9, 5 },
            { 1, 2, 3, 9, 6 },
            { 6, 7, 9, 8, 7 },
            { 4, 1, 7, 2, 8 },
            { 8, 6, 6, 1, 4 },
        };

        var start = new PathFinding.Coordinate(0, 2);
        var goal = new PathFinding.Coordinate(4, 4);

        var path = grid.AStar(start, goal).ToArray();

        Assert.Equal(start, path.First());
        Assert.Equal(goal, path.Last());

        // A* path cost excludes the start cell weight (gScore semantics).
        // Dijkstra's optimum (including start) is 24, so the path sum must be 17.
        var sum = path.Skip(1).Sum(p => grid[p.Row, p.Col]);

        Assert.Equal(17, sum);
    }

    [Fact]
    public void AStarFindsOptimalPathWhenGoalIsExpensive()
    {
        // The goal cell is far more expensive than its surroundings, so any
        // optimal path pays 100 at the last step; the assertion pins the
        // resulting optimal cost (path cell costs excluding the start).
        var grid = new long[,]
        {
            { 1, 1, 1, 1 },
            { 1, 1, 1, 1 },
            { 1, 1, 1, 1 },
            { 1, 1, 1, 100 },
        };

        var start = new PathFinding.Coordinate(0, 0);
        var goal = new PathFinding.Coordinate(3, 3);

        var path = grid.AStar(start, goal).ToArray();

        // Unique shortest path is the diagonal: (0,0)->(1,1)->(2,2)->(3,3).
        var sum = path.Skip(1).Sum(p => grid[p.Row, p.Col]);

        Assert.Equal(102, sum);
    }

    [Fact]
    public void AStarStartEqualsGoal()
    {
        var grid = new long[,] { { 1, 2 }, { 3, 4 } };
        var start = new PathFinding.Coordinate(1, 1);

        var actual = grid.AStar(start, start).ToArray();

        var expected = new[] { start };
        Assert.True(expected.SequenceEqual(actual), actual.EnumerableToString());
    }

    [Fact]
    public void AStarGoalUnreachable()
    {
        var grid = new long[,] { { 1, 2 }, { 3, 4 } };

        var actual = grid
            .AStar(new PathFinding.Coordinate(0, 0), new PathFinding.Coordinate(1, 1), (g, x) => Enumerable.Empty<PathFinding.Coordinate>())
            .ToArray();

        Assert.Empty(actual);
    }

    [Fact]
    public void AStarAgreesWithDijkstraOnRandomGrids()
    {
        var rng = new Random(20240924);

        for (var iteration = 0; iteration < 50; iteration++)
        {
            var grid = new long[5, 5];

            for (var row = 0; row < 5; row++)
            {
                for (var col = 0; col < 5; col++)
                {
                    grid[row, col] = rng.Next(1, 10);
                }
            }

            var start = new PathFinding.Coordinate(rng.Next(5), rng.Next(5));

            PathFinding.Coordinate goal;
            do
            {
                goal = new PathFinding.Coordinate(rng.Next(5), rng.Next(5));
            }
            while (start.Equals(goal));

            var dijkstraTotal = grid.DijkstraMinPathWeight(start, goal);
            var path = grid.AStar(start, goal).ToArray();
            var pathSum = path.Skip(1).Sum(p => grid[p.Row, p.Col]);
            var optimalExcludingStart = dijkstraTotal - grid[start.Row, start.Col];

            Assert.True(pathSum == optimalExcludingStart,
                $"iteration {iteration}: start {start}, goal {goal}: A* path sum {pathSum} != optimal {optimalExcludingStart}; path {path.EnumerableToString()}");
        }
    }

    [Fact]
    public void DijkstraDisconnectedGoalReturnsMaxValue()
    {
        var grid = new long[,]
        {
            { 1, 2 },
            { 3, 4 },
        };

        // NeighborsRightAndDown from the lower-right corner can never reach the upper-left.
        var actual = grid.DijkstraMinPathWeight(
            new PathFinding.Coordinate(1, 1),
            new PathFinding.Coordinate(0, 0),
            PathFinding.NeighborsRightAndDown);

        Assert.Equal(long.MaxValue, actual);
    }

    [Fact]
    public void DijkstraMinPathWeightsDisconnectedLeavesMaxValue()
    {
        var grid = new long[,]
        {
            { 1, 2 },
            { 3, 4 },
        };

        var actual = grid.DijkstraMinPathWeights(
            new PathFinding.Coordinate(1, 1),
            PathFinding.NeighborsRightAndDown);

        Assert.Equal(grid[1, 1], actual[1, 1]);
        Assert.Equal(long.MaxValue, actual[0, 0]);
    }

    [Fact]
    public void DijkstraStartEqualsGoal()
    {
        var grid = new long[,] { { 1, 2 }, { 3, 4 } };
        var start = new PathFinding.Coordinate(1, 1);

        var actual = grid.DijkstraMinPathWeight(start, start);

        Assert.Equal(grid[start.Row, start.Col], actual);
    }
}
