using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler.Toolbox
{
    public static class PathFinding
    {
        /// <summary>
        /// Solves the single-source shortest path problem for a graph with nonnegative edge path costs and returns the min-weight sum to the goal point in the grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static long DijkstraMinPathWeight(this long[,] grid, Coordinate start, Coordinate goal) => grid.DijkstraMinPathWeights(start, goal, Neighbors8)[goal.Row, goal.Col];

        // Dijkstra
        // http://en.wikipedia.org/wiki/Dijkstra's_algorithm
        /// <summary>
        /// Solves the single-source shortest path problem for a graph with nonnegative edge path costs and returns the min-weight sum to the goal point in the grid using a custom neighbor function.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <param name="neighbors"> </param>
        /// <returns></returns>
        public static long DijkstraMinPathWeight(this long[,] grid, Coordinate start, Coordinate goal, Func<long[,], Coordinate, IEnumerable<Coordinate>> neighbors) => grid.DijkstraMinPathWeights(start, goal, neighbors)[goal.Row, goal.Col];

        /// <summary>
        /// Solves the single-source shortest path problem for a graph with nonnegative edge path costs and returns the min-weight sum to each point in the grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static long[,] DijkstraMinPathWeights(this long[,] grid, Coordinate start) => grid.DijkstraMinPathWeights(start, null, Neighbors8);

        /// <summary>
        /// Solves the single-source shortest path problem for a graph with nonnegative edge path costs and returns the min-weight sum to each point in the grid using a custom neighbor function.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <param name="neighbors"></param>
        /// <returns></returns>
        public static long[,] DijkstraMinPathWeights(this long[,] grid, Coordinate start, Func<long[,], Coordinate, IEnumerable<Coordinate>> neighbors) => grid.DijkstraMinPathWeights(start, null, neighbors);

        /// <summary>
        /// Solves the single-source shortest path problem for a graph with nonnegative edge path costs and returns the min-weight sum to the goal
        /// point in the grid using a custom neighbor function.  NOT all paths are traversed in the process.
        /// If the path is desired consider using Astar().
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <param name="neighbors"></param>
        /// <returns></returns>
        public static long[,] DijkstraMinPathWeights(this long[,] grid, Coordinate start, Coordinate goal, Func<long[,], Coordinate, IEnumerable<Coordinate>> neighbors)
        {
            var dist = new long[grid.GetLength(0), grid.GetLength(1)];
            var q = new HashSet<Coordinate>();

            for (var row = 0; row < dist.GetLength(0); row++)
            {
                for (var col = 0; col < dist.GetLength(1); col++)
                {
                    dist[row, col] = long.MaxValue;
                    q.Add(new Coordinate(row, col));
                }
            }

            dist[start.Row, start.Col] = grid[start.Row, start.Col];

            while (q.Any())
            {
                var min = long.MaxValue;
                var u = default(Coordinate);

                foreach (var t in q)
                {
                    if (dist[t.Row, t.Col] < min)
                    {
                        min = dist[t.Row, t.Col];
                        u = t;
                    }
                }

                // we are at the final square
                if (goal != null && u.Equals(goal))
                {
                    break;
                }

                q.Remove(u);

                foreach (var v in neighbors(grid, u))
                {
                    if (q.Contains(v))
                    {
                        var alt = dist[u.Row, u.Col] + grid[v.Row, v.Col];
                        if (alt < dist[v.Row, v.Col])
                        {
                            dist[v.Row, v.Col] = alt;
                        }
                    }
                }
            }

            return dist;
        }

        /// <summary>
        /// A* uses a best-first search and finds the least-cost path from a given initial node to one goal node (out of one or more possible goals).
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinate> Astar(this long[,] grid, Coordinate start, Coordinate goal) => grid.Astar(start, goal, (g, x) => g.Neighbors8(x));

        // A*
        // http://en.wikipedia.org/wiki/A*_search_algorithm
        // http://wiki.gamegardens.com/Path_Finding_Tutorial
        /// <summary>
        /// A* uses a best-first search and finds the least-cost path from a given initial node to one goal node (out of one or more possible goals).
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <param name="neighbors"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinate> Astar(this long[,] grid, Coordinate start, Coordinate goal, Func<long[,], Coordinate, IEnumerable<Coordinate>> neighbors)
        {
            var closedSet = new HashSet<Coordinate>();
            var openSet = new HashSet<Coordinate> { start };
            var cameFrom = new Dictionary<Coordinate, Coordinate>();

            var gScore = new long[grid.GetLength(0), grid.GetLength(1)];
            var hScore = new long[grid.GetLength(0), grid.GetLength(1)];
            var fScore = new long[grid.GetLength(0), grid.GetLength(1)];

            gScore[start.Row, start.Col] = 0;
            hScore[start.Row, start.Col] = grid.DistanceEstimate(start, goal);
            fScore[start.Row, start.Col] = hScore[start.Row, start.Col];

            while (openSet.Any())
            {
                var min = openSet.Min(v => fScore[v.Row, v.Col]);
                var u = openSet.First(v => fScore[v.Row, v.Col] == min);

                if (u.Equals(goal))
                {
                    foreach (var p in ReconstitutePath(cameFrom, cameFrom[u]))
                    {
                        yield return p;
                    }

                    yield return goal;
                }

                openSet.Remove(u);
                closedSet.Add(u);

                foreach (var neighbor in neighbors(grid, u))
                {
                    if (closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    var tentativeGScore = gScore[u.Row, u.Col] + grid.DistanceBetween(u, neighbor);
                    var tentativeIsBetter = false;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                        tentativeIsBetter = true;
                    }
                    else if (tentativeGScore < gScore[neighbor.Row, neighbor.Col])
                    {
                        tentativeIsBetter = true;
                    }

                    if (tentativeIsBetter)
                    {
                        if (cameFrom.TryGetValue(neighbor, out Coordinate value))
                        {
                            value = u;
                        }
                        else
                        {
                            cameFrom.Add(neighbor, u);
                        }

                        gScore[neighbor.Row, neighbor.Col] = tentativeGScore;
                        hScore[neighbor.Row, neighbor.Col] = DistanceEstimate(grid, neighbor, goal);
                        fScore[neighbor.Row, neighbor.Col] = gScore[neighbor.Row, neighbor.Col] + hScore[neighbor.Row, neighbor.Col];
                    }
                }
            }
        }

        /// <summary>
        /// Get the four compass direction neighbors in a grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="square"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinate> Neighbors4<T>(this T[,] grid, Coordinate square)
        {
            if (square.Row > 0)
            {
                yield return new Coordinate(square.Row - 1, square.Col); // left
            }

            if (square.Row < grid.GetLength(0) - 1)
            {
                yield return new Coordinate(square.Row + 1, square.Col); // right
            }

            if (square.Col > 0)
            {
                yield return new Coordinate(square.Row, square.Col - 1); // up
            }

            if (square.Col < grid.GetLength(1) - 1)
            {
                yield return new Coordinate(square.Row, square.Col + 1); // down
            }
        }

        /// <summary>
        /// Get the eight compass direction neighbors in a grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="square"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinate> Neighbors8<T>(this T[,] grid, Coordinate square)
        {
            if (square.Row > 0)
            {
                yield return new Coordinate(square.Row - 1, square.Col); // left

                if (square.Col > 0)
                {
                    yield return new Coordinate(square.Row - 1, square.Col - 1); // up left
                }

                if (square.Col < grid.GetLength(1) - 1)
                {
                    yield return new Coordinate(square.Row - 1, square.Col + 1); // down left
                }
            }

            if (square.Row < grid.GetLength(0) - 1)
            {
                yield return new Coordinate(square.Row + 1, square.Col); // right

                if (square.Col > 0)
                {
                    yield return new Coordinate(square.Row + 1, square.Col - 1); // up right
                }

                if (square.Col < grid.GetLength(1) - 1)
                {
                    yield return new Coordinate(square.Row + 1, square.Col + 1); // down right
                }
            }

            if (square.Col > 0)
            {
                yield return new Coordinate(square.Row, square.Col - 1); // up
            }

            if (square.Col < grid.GetLength(1) - 1)
            {
                yield return new Coordinate(square.Row, square.Col + 1); // down
            }
        }

        /// <summary>
        /// Get the neighbors to the right and down
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="square"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinate> NeighborsRightAndDown<T>(this T[,] grid, Coordinate square)
        {
            if (square.Row < grid.GetLength(0) - 1)
            {
                yield return new Coordinate(square.Row + 1, square.Col); // right
            }

            if (square.Col < grid.GetLength(1) - 1)
            {
                yield return new Coordinate(square.Row, square.Col + 1); // down
            }
        }

        /// <summary>
        /// Get the upper left coordinate of a grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Coordinate UpperLeft<T>(this T[,] grid) => new Coordinate(0, 0);

        /// <summary>
        /// Get the lower right coordinate of a grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Coordinate LowerRight<T>(this T[,] grid) => new Coordinate(grid.GetLength(0) - 1, grid.GetLength(1) - 1);

        private static long DistanceBetween(this long[,] grid, Coordinate square1, Coordinate square2) => grid[square2.Row, square2.Col];

        private static long DistanceEstimate(this long[,] grid, Coordinate current, Coordinate goal)
        {
            var dRow = current.Row - goal.Row;
            var dCol = current.Col - goal.Col;

            return (long)Math.Sqrt(dRow * dRow + dCol * dCol);
        }

        private static IEnumerable<Coordinate> ReconstitutePath(IDictionary<Coordinate, Coordinate> cameFrom, Coordinate current)
        {
            if (cameFrom.TryGetValue(current, out Coordinate value))
            {
                foreach (var p in ReconstitutePath(cameFrom, value))
                {
                    yield return p;
                }
            }

            yield return current;
        }

        public class Coordinate : IEquatable<Coordinate>
        {
            public int Row { get; }
            public int Col { get; }

            public Coordinate(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                var c = obj as Coordinate;
                if (c == null)
                {
                    return false;
                }

                return Row == c.Row && Col == c.Col;
            }

            public bool Equals(Coordinate c)
            {
                if (c == null)
                {
                    return false;
                }

                return Row == c.Row && Col == c.Col;
            }

            public override int GetHashCode() => Row ^ Col;

            public override string ToString() => $"({Row}, {Col})";
        }
    }
}