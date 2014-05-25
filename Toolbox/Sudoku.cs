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
            var available = new Dictionary<Tuple<int, int>, IList<int>>();

            for (var x = 0; x < 9; x++)
            {
                for (var y = 0; y < 9; y++)
                {
                    available[Tuple.Create(x, y)] = Enumerable.Range(1, 9).ToList();
                }
            }

            var done = false;
            var stuck = false;

            while (!done)
            {
                done = true;
                stuck = true;

                // whole square
                for (var x = 0; x < 9; x++)
                {
                    for (var y = 0; y < 9; y++)
                    {
                        if (p[x, y] != 0)
                        {
                            available.Remove(Tuple.Create(x, y));

                            for (var x1 = 0; x1 < 9; x1++)
                            {
                                var tup = Tuple.Create(x1, y);
                                var value = default(IList<int>);

                                if (available.TryGetValue(tup, out value))
                                {
                                    value.Remove(p[x, y]);
                                }
                            }

                            for (var y1 = 0; y1 < 9; y1++)
                            {
                                var tup = Tuple.Create(x, y1);
                                var value = default(IList<int>);

                                if (available.TryGetValue(tup, out value))
                                {
                                    value.Remove(p[x, y]);
                                }
                            }
                        }
                        else
                        {
                            done = false;
                        }
                    }
                }

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
                                    available.Remove(Tuple.Create(x + dx, y + dy));

                                    for (var x1 = 0; x1 < 3; x1++)
                                    {
                                        for (var y1 = 0; y1 < 3; y1++)
                                        {
                                            var tup = Tuple.Create(x + x1, y + y1);
                                            var value = default(IList<int>);

                                            if (available.TryGetValue(tup, out value))
                                            {
                                                value.Remove(p[x + dx, y + dy]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    done = false;
                                }
                            }
                        }
                    }
                }

                if (!done)
                {
                    foreach (var possible in available.Where(kvp => !kvp.Value.Any()).ToList())
                    {
                        available.Remove(possible.Key);
                    }

                    for (var x = 0; x < 9; x++)
                    {
                        for (var y = 0; y < 9; y++)
                        {
                            var tup = Tuple.Create(x, y);
                            var value = default(IList<int>);

                            if (available.TryGetValue(tup, out value) && value.Count == 1)
                            {
                                p[x, y] = value.Single();
                                available.Remove(tup);
                                stuck = false;
                            }
                        }
                    }
                }

                if (done)
                {
                    // verify all rows, cols, and squares
                    for (var x = 0; x < 9; x++)
                    {
                        var sum = 0;

                        for (var y = 0; y < 9; y++)
                        {
                            sum += p[x, y];
                        }

                        if (sum != 45)
                        {
                            return null;
                        }
                    }

                    for (var y = 0; y < 9; y++)
                    {
                        var sum = 0;

                        for (var x = 0; x < 9; x++)
                        {
                            sum += p[x, y];
                        }

                        if (sum != 45)
                        {
                            return null;
                        }
                    }

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

                            if (sum != 45)
                            {
                                return null;
                            }
                        }
                    }
                }

                if (!done && stuck)
                {
                    if (!available.Any())
                    {
                        return null;
                    }

                    // enumerate squares with fewest options first
                    var empty = available.OrderBy(kvp => kvp.Value.Count).First();

                    foreach (var value in empty.Value)
                    {
                        var temp = (int[,])p.Clone();
                        temp[empty.Key.Item1, empty.Key.Item2] = value;

                        temp = Solve(temp);

                        if (temp != null)
                        {
                            return temp;
                        }
                    }

                    return null;
                }
            }

            return p;
        }
    }
}