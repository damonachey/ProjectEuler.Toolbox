using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class SudokuTests
{
    [Fact]
    public void Solve()
    {
        var expected = new int[,]
            {
                {4,8,3,9,2,1,6,5,7},
                {9,6,7,3,4,5,8,2,1},
                {2,5,1,8,7,6,4,9,3},
                {5,4,8,1,3,2,9,7,6},
                {7,2,9,5,6,4,1,3,8},
                {1,3,6,7,9,8,2,4,5},
                {3,7,2,6,8,9,5,1,4},
                {8,1,4,2,5,3,7,6,9},
                {6,9,5,4,1,7,3,8,2},
            };
        var actual = Sudoku.Solve(new int[,]
            {
                {0,0,3,0,2,0,6,0,0},
                {9,0,0,3,0,5,0,0,1},
                {0,0,1,8,0,6,4,0,0},
                {0,0,8,1,0,2,9,0,0},
                {7,0,0,0,0,0,0,0,8},
                {0,0,6,7,0,8,2,0,0},
                {0,0,2,6,0,9,5,0,0},
                {8,0,0,2,0,3,0,0,9},
                {0,0,5,0,1,0,3,0,0},
            });

        Assert.NotNull(actual);
        AssertIsValidSolution(actual!);

        for (var i = 0; i < expected.GetLength(0); i++)
        {
            for (int j = 0; j < expected.GetLength(1); j++)
            {
                Assert.Equal(expected[i, j], actual?[i, j]);
            }
        }
    }

    [Fact]
    public void SolveHardPuzzle()
    {
        // AI Escargot, Arto Inkala (2006) -- one of the hardest published puzzles.
        var expected = new int[,]
            {
                {1,6,2,8,5,7,4,9,3},
                {5,3,4,1,2,9,6,7,8},
                {7,8,9,6,4,3,5,2,1},
                {4,7,5,3,1,2,9,8,6},
                {9,1,3,5,8,6,7,4,2},
                {6,2,8,7,9,4,1,3,5},
                {3,5,6,4,7,8,2,1,9},
                {2,4,1,9,3,5,8,6,7},
                {8,9,7,2,6,1,3,5,4},
            };
        var actual = Sudoku.Solve(new int[,]
            {
                {1,0,0,0,0,7,0,9,0},
                {0,3,0,0,2,0,0,0,8},
                {0,0,9,6,0,0,5,0,0},
                {0,0,5,3,0,0,9,0,0},
                {0,1,0,0,8,0,0,0,2},
                {6,0,0,0,0,4,0,0,0},
                {3,0,0,0,0,0,0,1,0},
                {0,4,0,0,0,0,0,0,7},
                {0,0,7,0,0,0,3,0,0},
            });

        Assert.NotNull(actual);
        AssertIsValidSolution(actual!);

        for (var i = 0; i < expected.GetLength(0); i++)
        {
            for (int j = 0; j < expected.GetLength(1); j++)
            {
                Assert.Equal(expected[i, j], actual?[i, j]);
            }
        }
    }

    [Fact]
    public void SolveRejectsGridFullOfFives()
    {
        // Every row and column sums to 45, yet the grid is not a valid solution.
        var grid = new int[9, 9];

        for (var x = 0; x < 9; x++)
        {
            for (var y = 0; y < 9; y++)
            {
                grid[x, y] = 5;
            }
        }

        var actual = Sudoku.Solve(grid);

        Assert.Null(actual);
    }

    [Fact]
    public void SolveRejectsSumPerfectButInvalidGrid()
    {
        // A completed grid in which every row, column and box still sums to 45
        // (by construction) but rows 0 and 1 contain duplicates. A sum check
        // accepts it; a uniqueness check must reject it.
        var grid = new int[,]
            {
                {5,7,3,9,2,1,6,5,7},
                {8,7,7,3,4,5,8,2,1},
                {2,5,1,8,7,6,4,9,3},
                {5,4,8,1,3,2,9,7,6},
                {7,2,9,5,6,4,1,3,8},
                {1,3,6,7,9,8,2,4,5},
                {3,7,2,6,8,9,5,1,4},
                {8,1,4,2,5,3,7,6,9},
                {6,9,5,4,1,7,3,8,2},
            };

        var actual = Sudoku.Solve(grid);

        Assert.Null(actual);
    }

    [Fact]
    public void SolveRejectsGridWithValidColumnsButInvalidRow()
    {
        // The test-solution grid with two values swapped within the first row
        // (positions 3 and 4): every column is still a permutation of 1-9, but
        // the third row (spanning the swap) now contains a duplicate.
        var grid = new int[,]
            {
                {4,8,3,2,9,1,6,5,7},
                {9,6,7,3,4,5,8,2,1},
                {2,5,1,8,7,6,4,9,3},
                {5,4,8,1,3,2,9,7,6},
                {7,2,9,5,6,4,1,3,8},
                {1,3,6,7,9,8,2,4,5},
                {3,7,2,6,8,9,5,1,4},
                {8,1,4,2,5,3,7,6,9},
                {6,9,5,4,1,7,3,8,2},
            };

        var actual = Sudoku.Solve(grid);

        Assert.Null(actual);
    }

    [Fact]
    public void SolveRejectsLatinSquareWithInvalidBoxes()
    {
        // A Latin square: every row and column is a permutation of 1-9, but the
        // 3x3 boxes are not.
        var grid = new int[,]
            {
                {1,2,3,4,5,6,7,8,9},
                {2,3,1,5,6,4,8,9,7},
                {3,1,2,6,4,5,9,7,8},
                {4,5,6,7,8,9,1,2,3},
                {5,6,4,8,9,7,2,3,1},
                {6,4,5,9,7,8,3,1,2},
                {7,8,9,1,2,3,4,5,6},
                {8,9,7,2,3,1,5,6,4},
                {9,7,8,3,1,2,6,4,5},
            };

        var actual = Sudoku.Solve(grid);

        Assert.Null(actual);
    }

    [Fact]
    public void SolveReturnsNullForPuzzleWithDuplicateClues()
    {
        // A duplicate 3 in the first row makes the puzzle unsolvable.
        var actual = Sudoku.Solve(new int[,]
            {
                {3,0,3,0,2,0,6,0,0},
                {9,0,0,3,0,5,0,0,1},
                {0,0,1,8,0,6,4,0,0},
                {0,0,8,1,0,2,9,0,0},
                {7,0,0,0,0,0,0,0,8},
                {0,0,6,7,0,8,2,0,0},
                {0,0,2,6,0,9,5,0,0},
                {8,0,0,2,0,3,0,0,9},
                {0,0,5,0,1,0,3,0,0},
            });

        Assert.Null(actual);
    }

    [Fact]
    public void SolveNullThrows()
    {
        Assert.Throws<ArgumentNullException>(() => Sudoku.Solve(null!));
    }

    [Fact]
    public void SolveWrongSizeThrows()
    {
        Assert.Throws<ArgumentException>(() => Sudoku.Solve(new int[4, 4]));
    }

    [Fact]
    public void SolveInvalidCellValueThrows()
    {
        var grid = new int[9, 9];
        grid[0, 0] = 10;

        Assert.Throws<ArgumentException>(() => Sudoku.Solve(grid));
    }

    private static void AssertIsValidSolution(int[,] grid)
    {
        for (var x = 0; x < 9; x++)
        {
            var column = new int[9];

            for (var y = 0; y < 9; y++)
            {
                column[y] = grid[x, y];
            }

            AssertUnit(column, $"column {x}");
        }

        for (var y = 0; y < 9; y++)
        {
            var row = new int[9];

            for (var x = 0; x < 9; x++)
            {
                row[x] = grid[x, y];
            }

            AssertUnit(row, $"row {y}");
        }

        for (var x = 0; x < 9; x += 3)
        {
            for (var y = 0; y < 9; y += 3)
            {
                var box = new int[9];
                var index = 0;

                for (var dx = 0; dx < 3; dx++)
                {
                    for (var dy = 0; dy < 3; dy++)
                    {
                        box[index++] = grid[x + dx, y + dy];
                    }
                }

                AssertUnit(box, $"box at ({x}, {y})");
            }
        }
    }

    private static void AssertUnit(int[] values, string unit)
    {
        var seen = new bool[9];

        foreach (var value in values)
        {
            Assert.InRange(value, 1, 9);
            Assert.False(seen[value - 1], $"{unit} contains duplicate {value}");
            seen[value - 1] = true;
        }
    }
}