namespace ProjectEuler.Toolbox;

public static class Sudoku
{
    /// <summary>
    /// Recursively solve Sudoku puzzles via trial and error
    /// </summary>
    /// <param name="grid">Puzzle grid</param>
    /// <returns>Completed puzzle or null if no solution</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static int[,]? Solve(int[,] grid)
    {
        ArgumentNullException.ThrowIfNull(grid);

        if (grid.GetLength(0) != 9 || grid.GetLength(1) != 9)
        {
            throw new ArgumentException("Puzzle grid must be 9x9.", nameof(grid));
        }

        for (var x = 0; x < 9; x++)
        {
            for (var y = 0; y < 9; y++)
            {
                if (grid[x, y] is < 0 or > 9)
                {
                    throw new ArgumentException($"Cell [{x}, {y}] must hold a value in the range 0..9.", nameof(grid));
                }
            }
        }

        var possibleCellValues = InitializePossibleEmptyCellValues(grid);

        while (true)
        {
            RemoveUsedRowColValuesFromPossibleCellValues(grid, possibleCellValues);
            RemoveUsedBoxValuesFromPossibleCellValues(grid, possibleCellValues);

            if (possibleCellValues.Count == 0)
            {
                return CheckAllUnitsSolved(grid) ? grid : null;
            }

            if (!AssignCellsWithOnlyOnePossibleValue(grid, possibleCellValues))
            {
                return RecursivelyGuess(grid, possibleCellValues);
            }
        }
    }

    private static Dictionary<dynamic, List<int>> InitializePossibleEmptyCellValues(int[,] grid)
    {
        var possibleCellValues = new Dictionary<dynamic, List<int>>();

        for (var x = 0; x < 9; x++)
        {
            for (var y = 0; y < 9; y++)
            {
                if (grid[x, y] == 0)
                {
                    var cell = new { x, y };
                    possibleCellValues[cell] = Enumerable.Range(1, 9).ToList();
                }
            }
        }

        return possibleCellValues;
    }

    private static void RemoveUsedRowColValuesFromPossibleCellValues(int[,] grid, Dictionary<dynamic, List<int>> possibleCellValues)
    {
        for (var x = 0; x < 9; x++)
        {
            for (var y = 0; y < 9; y++)
            {
                if (grid[x, y] != 0)
                {
                    for (var x1 = 0; x1 < 9; x1++)
                    {
                        var cell = new { x = x1, y };
                        RemovePossibleCellValue(possibleCellValues, cell, grid[x, y]);
                    }

                    for (var y1 = 0; y1 < 9; y1++)
                    {
                        var cell = new { x, y = y1 };
                        RemovePossibleCellValue(possibleCellValues, cell, grid[x, y]);
                    }
                }
            }
        }
    }

    private static void RemoveUsedBoxValuesFromPossibleCellValues(int[,] grid, Dictionary<dynamic, List<int>> possibleCellValues)
    {
        for (var x = 0; x < 9; x += 3)
        {
            for (var y = 0; y < 9; y += 3)
            {
                for (var dx = 0; dx < 3; dx++)
                {
                    for (var dy = 0; dy < 3; dy++)
                    {
                        if (grid[x + dx, y + dy] != 0)
                        {
                            for (var x1 = 0; x1 < 3; x1++)
                            {
                                for (var y1 = 0; y1 < 3; y1++)
                                {
                                    var cell = new { x = x + x1, y = y + y1 };
                                    RemovePossibleCellValue(possibleCellValues, cell, grid[x + dx, y + dy]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private static void RemovePossibleCellValue(Dictionary<dynamic, List<int>> possibleCellValues, dynamic cell, int value)
    {
        if (possibleCellValues.TryGetValue(cell, out List<int> valueList))
        {
            valueList.Remove(value);

            if (valueList.Count == 0)
            {
                possibleCellValues.Remove(cell);
            }
        }
    }

    private static bool CheckAllUnitsSolved(int[,] grid) =>
        CheckAllColumnsSolved(grid) && CheckAllRowsSolved(grid) && CheckAllBoxesSolved(grid);

    private static bool CheckAllColumnsSolved(int[,] grid)
    {
        for (var x = 0; x < 9; x++)
        {
            var values = new int[9];

            for (var y = 0; y < 9; y++)
            {
                values[y] = grid[x, y];
            }

            if (!IsUnitComplete(values))
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckAllRowsSolved(int[,] grid)
    {
        for (var y = 0; y < 9; y++)
        {
            var values = new int[9];

            for (var x = 0; x < 9; x++)
            {
                values[x] = grid[x, y];
            }

            if (!IsUnitComplete(values))
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckAllBoxesSolved(int[,] grid)
    {
        for (var x = 0; x < 9; x += 3)
        {
            for (var y = 0; y < 9; y += 3)
            {
                var values = new int[9];
                var index = 0;

                for (var dx = 0; dx < 3; dx++)
                {
                    for (var dy = 0; dy < 3; dy++)
                    {
                        values[index++] = grid[x + dx, y + dy];
                    }
                }

                if (!IsUnitComplete(values))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // A unit (row, column or box) is complete only if it contains every digit 1..9 exactly once.
    // A sum check is not sufficient: e.g. five 9s and four 0s in a row also sums to 45.
    private static bool IsUnitComplete(int[] values)
    {
        var seen = new bool[9];

        foreach (var value in values)
        {
            if (value is < 1 or > 9 || seen[value - 1])
            {
                return false;
            }

            seen[value - 1] = true;
        }

        return true;
    }

    private static bool AssignCellsWithOnlyOnePossibleValue(int[,] grid, Dictionary<dynamic, List<int>> possibleCellValues)
    {
        var cellsWithOnePossibleValue = possibleCellValues
            .Where(kvp => kvp.Value.Count == 1)
            .ToArray();

        foreach (var cell in cellsWithOnePossibleValue)
        {
            grid[cell.Key.x, cell.Key.y] = cell.Value.Single();
            possibleCellValues.Remove(cell.Key);
        }

        return cellsWithOnePossibleValue.Length != 0;
    }

    private static int[,]? RecursivelyGuess(int[,] grid, Dictionary<dynamic, List<int>> possibleCellValues)
    {
        var emptyCellWithFewestPossibleValues = possibleCellValues
            .OrderBy(kvp => kvp.Value.Count)
            .First();

        foreach (var value in emptyCellWithFewestPossibleValues.Value)
        {
            var tempGrid = (int[,])grid.Clone();
            tempGrid[emptyCellWithFewestPossibleValues.Key.x, emptyCellWithFewestPossibleValues.Key.y] = value;

            var tempSolution = Solve(tempGrid);

            if (tempSolution is not null)
            {
                return tempSolution;
            }
        }

        return null;
    }
}
