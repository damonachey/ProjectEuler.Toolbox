using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Toolbox
{
    public static class Sudoku
    {
        /// <summary>
        /// Recursively solve Sudoku puzzles via trial and error
        /// </summary>
        /// <param name="p">Puzzle state</param>
        /// <returns>Completed puzzle or null if no solution</returns>
        public static int[,] Solve(int[,] p)
        {
            var possibleCellValues = InitializePossibleEmptyCellValues(p);

            while (true)
            {
                RemoveUsedRowColValuesFromPossibleCellValues(p, possibleCellValues);
                RemoveUsedBoxValuesFromPossibleCellValues(p, possibleCellValues);

                if (!possibleCellValues.Any())
                {
                    return CheckAllSums(p) ? p : null;
                }

                if (!AssignCellsWithOnlyOnePossibleValue(p, possibleCellValues))
                {
                    return RecursivelyGuess(p, possibleCellValues);
                }
            }
        }

        private static Dictionary<Tuple<int, int>, IList<int>> InitializePossibleEmptyCellValues(int[,] p)
        {
            var possibleCellValues = new Dictionary<Tuple<int, int>, IList<int>>();

            for (var x = 0; x < 9; x++)
            {
                for (var y = 0; y < 9; y++)
                {
                    if (p[x, y] == 0)
                    {
                        possibleCellValues[Tuple.Create(x, y)] = Enumerable.Range(1, 9).ToList();
                    }
                }
            }

            return possibleCellValues;
        }

        private static void RemoveUsedRowColValuesFromPossibleCellValues(int[,] p, Dictionary<Tuple<int, int>, IList<int>> possibleCellValues)
        {
            for (var x = 0; x < 9; x++)
            {
                for (var y = 0; y < 9; y++)
                {
                    if (p[x, y] != 0)
                    {
                        for (var x1 = 0; x1 < 9; x1++)
                        {
                            var cell = Tuple.Create(x1, y);
                            RemoveCellValue(possibleCellValues, cell, p[x, y]);
                        }

                        for (var y1 = 0; y1 < 9; y1++)
                        {
                            var cell = Tuple.Create(x, y1);
                            RemoveCellValue(possibleCellValues, cell, p[x, y]);
                        }
                    }
                }
            }
        }

        private static void RemoveUsedBoxValuesFromPossibleCellValues(int[,] p, Dictionary<Tuple<int, int>, IList<int>> possibleCellValues)
        {
            for (var x = 0; x < 9; x += 3)
            {
                for (var y = 0; y < 9; y += 3)
                {
                    for (var dx = 0; dx < 3; dx++)
                    {
                        for (var dy = 0; dy < 3; dy++)
                        {
                            if (p[x + dx, y + dy] != 0)
                            {
                                for (var x1 = 0; x1 < 3; x1++)
                                {
                                    for (var y1 = 0; y1 < 3; y1++)
                                    {
                                        var cell = Tuple.Create(x + x1, y + y1);
                                        RemoveCellValue(possibleCellValues, cell, p[x + dx, y + dy]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void RemoveCellValue(Dictionary<Tuple<int, int>, IList<int>> possibleCellValues, Tuple<int, int> cell, int value)
        {
            var valueList = default(IList<int>);

            if (possibleCellValues.TryGetValue(cell, out valueList))
            {
                valueList.Remove(value);

                if (!valueList.Any())
                {
                    possibleCellValues.Remove(cell);
                }
            }
        }

        private static readonly int ExpectedSum = 45;

        private static bool CheckAllSums(int[,] p)
        {
            return CheckColSums(p) && CheckRowSums(p) && CheckBoxSums(p);
        }

        private static bool CheckColSums(int[,] p)
        {
            for (var x = 0; x < 9; x++)
            {
                var sum = 0;

                for (var y = 0; y < 9; y++)
                {
                    sum += p[x, y];
                }

                if (sum != ExpectedSum)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckRowSums(int[,] p)
        {
            for (var y = 0; y < 9; y++)
            {
                var sum = 0;

                for (var x = 0; x < 9; x++)
                {
                    sum += p[x, y];
                }

                if (sum != ExpectedSum)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckBoxSums(int[,] p)
        {
            for (var x = 0; x < 9; x += 3)
            {
                for (var y = 0; y < 9; y += 3)
                {
                    var sum = 0;

                    for (var dx = 0; dx < 3; dx++)
                    {
                        for (var dy = 0; dy < 3; dy++)
                        {
                            sum += p[x + dx, y + dy];
                        }
                    }

                    if (sum != ExpectedSum)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool AssignCellsWithOnlyOnePossibleValue(int[,] p, Dictionary<Tuple<int, int>, IList<int>> possibleCellValues)
        {
            var cellsWithOnePossibleValue = possibleCellValues
                .Where(kvp => kvp.Value.Count == 1)
                .ToList();

            foreach (var cell in cellsWithOnePossibleValue)
            {
                p[cell.Key.Item1, cell.Key.Item2] = cell.Value.Single();
                possibleCellValues.Remove(cell.Key);
            }

            return cellsWithOnePossibleValue.Any();
        }

        private static int[,] RecursivelyGuess(int[,] p, Dictionary<Tuple<int, int>, IList<int>> possibleCellValues)
        {
            var emptyCellWithFewestPossibleValues = possibleCellValues.OrderBy(kvp => kvp.Value.Count).First();

            foreach (var value in emptyCellWithFewestPossibleValues.Value)
            {
                var temp = (int[,])p.Clone();
                temp[emptyCellWithFewestPossibleValues.Key.Item1, emptyCellWithFewestPossibleValues.Key.Item2] = value;

                temp = Solve(temp);

                if (temp != null)
                {
                    return temp;
                }
            }

            return null;
        }
    }
}