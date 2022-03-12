namespace ProjectEuler.Toolbox;

public static class LinearAssignmentProblem
{
    // Copyright (c) 2010 Alex Regueiro
    // Licensed under MIT license, available at <http://www.opensource.org/licenses/mit-license.php>.
    // Published originally at <http://blog.noldorin.com/2009/09/hungarian-algorithm-in-csharp/>.
    // Based on implementation described at <http://www.public.iastate.edu/~ddoty/HungarianAlgorithm.html>.
    // Version 1.3, released 22nd May 2010.
    public static class HungarianAlgorithm
    {
        /// <summary>
        /// Finds the optimal assignments for a given matrix of agents and costed tasks such that the total cost is
        /// minimized.
        /// </summary>
        /// <param name="costs">A cost matrix; the element at row <em>i</em> and column <em>j</em> represents the cost of
        /// agent <em>i</em> performing task <em>j</em>.</param>
        /// <returns>A matrix of assignments; the value of element <em>i</em> is the column of the task assigned to agent
        /// <em>i</em>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="costs"/> is <see langword="null"/>.</exception>
        public static int[] FindAssignments(int[,] costs)
        {
            var h = costs.GetLength(0);
            var w = costs.GetLength(1);

            for (var i = 0; i < h; i++)
            {
                var min = int.MaxValue;

                for (var j = 0; j < w; j++)
                {
                    min = Math.Min(min, costs[i, j]);
                }

                for (var j = 0; j < w; j++)
                {
                    costs[i, j] -= min;
                }
            }

            var masks = new byte[h, w];
            var rowsCovered = new bool[h];
            var colsCovered = new bool[w];

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                    {
                        masks[i, j] = 1;
                        rowsCovered[i] = true;
                        colsCovered[j] = true;
                    }
                }
            }
            ClearCovers(rowsCovered, colsCovered, w, h);

            var path = new Location[w * h];
            var pathStart = default(Location);
            var step = 1;
            while (step != -1)
            {
                step = step switch
                {
                    1 => RunStep1(costs, masks, rowsCovered, colsCovered, w, h),
                    2 => RunStep2(costs, masks, rowsCovered, colsCovered, w, h, ref pathStart),
                    3 => RunStep3(costs, masks, rowsCovered, colsCovered, w, h, path, pathStart),
                    4 => RunStep4(costs, masks, rowsCovered, colsCovered, w, h),
                    _ => throw new NotImplementedException(),
                };
            }

            var agentsTasks = new int[h];
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (masks[i, j] == 1)
                    {
                        agentsTasks[i] = j;
                        break;
                    }
                }
            }

            return agentsTasks;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private static int RunStep1(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (masks[i, j] == 1)
                    {
                        colsCovered[j] = true;
                    }
                }
            }

            var colsCoveredCount = 0;

            for (var j = 0; j < w; j++)
            {
                if (colsCovered[j])
                {
                    colsCoveredCount++;
                }
            }

            if (colsCoveredCount == h)
            {
                return -1;
            }
            else
            {
                return 2;
            }
        }

        private static int RunStep2(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h, ref Location pathStart)
        {
            Location loc;
            while (true)
            {
                loc = FindZero(costs, masks, rowsCovered, colsCovered, w, h);
                if (loc.Row == -1)
                {
                    return 4;
                }
                else
                {
                    masks[loc.Row, loc.Column] = 2;
                    var starCol = FindStarInRow(masks, w, loc.Row);
                    if (starCol != -1)
                    {
                        rowsCovered[loc.Row] = true;
                        colsCovered[starCol] = false;
                    }
                    else
                    {
                        pathStart = loc;
                        return 3;
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private static int RunStep3(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h, Location[] path, Location pathStart)
        {
            var pathIndex = 0;
            path[0] = pathStart;

            while (true)
            {
                var row = FindStarInColumn(masks, h, path[pathIndex].Column);
                if (row == -1)
                {
                    break;
                }

                pathIndex++;
                path[pathIndex] = new(row, path[pathIndex - 1].Column);
                var col = FindPrimeInRow(masks, w, path[pathIndex].Row);
                pathIndex++;
                path[pathIndex] = new(path[pathIndex - 1].Row, col);
            }

            ConvertPath(masks, path, pathIndex + 1);
            ClearCovers(rowsCovered, colsCovered, w, h);
            ClearPrimes(masks, w, h);

            return 1;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private static int RunStep4(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            var minValue = FindMinimum(costs, rowsCovered, colsCovered, w, h);

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (rowsCovered[i])
                    {
                        costs[i, j] += minValue;
                    }

                    if (!colsCovered[j])
                    {
                        costs[i, j] -= minValue;
                    }
                }
            }

            return 2;
        }

        private static void ConvertPath(byte[,] masks, Location[] path, int pathLength)
        {
            for (var i = 0; i < pathLength; i++)
            {
                if (masks[path[i].Row, path[i].Column] == 1)
                {
                    masks[path[i].Row, path[i].Column] = 0;
                }
                else if (masks[path[i].Row, path[i].Column] == 2)
                {
                    masks[path[i].Row, path[i].Column] = 1;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private static Location FindZero(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                    {
                        return new(i, j);
                    }
                }
            }

            return new(-1, -1);
        }

        private static int FindMinimum(int[,] costs, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            var minValue = int.MaxValue;
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (!rowsCovered[i] && !colsCovered[j])
                    {
                        minValue = Math.Min(minValue, costs[i, j]);
                    }
                }
            }

            return minValue;
        }

        private static int FindStarInRow(byte[,] masks, int w, int row)
        {
            for (var j = 0; j < w; j++)
            {
                if (masks[row, j] == 1)
                {
                    return j;
                }
            }

            return -1;
        }

        private static int FindStarInColumn(byte[,] masks, int h, int col)
        {
            for (var i = 0; i < h; i++)
            {
                if (masks[i, col] == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int FindPrimeInRow(byte[,] masks, int w, int row)
        {
            for (var j = 0; j < w; j++)
            {
                if (masks[row, j] == 2)
                {
                    return j;
                }
            }

            return -1;
        }

        private static void ClearCovers(bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            for (var i = 0; i < h; i++)
            {
                rowsCovered[i] = false;
            }

            for (var j = 0; j < w; j++)
            {
                colsCovered[j] = false;
            }
        }

        private static void ClearPrimes(byte[,] masks, int w, int h)
        {
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (masks[i, j] == 2)
                    {
                        masks[i, j] = 0;
                    }
                }
            }
        }

        private struct Location
        {
            public int Row;
            public int Column;

            public Location(int row, int col)
            {
                Row = row;
                Column = col;
            }
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
    public static int LapJV(int dim, int[][] assigncost, int[] rowsol, int[] colsol, int[] u, int[] v)
    {
        if (dim != assigncost.GetLength(0) ||
            dim != assigncost.GetLength(1) ||
            dim != rowsol.Length ||
            dim != colsol.Length ||
            dim != u.Length ||
            dim != v.Length
            )
        {
            throw new ArgumentException(null, nameof(dim));
        }

        bool unassignedfound;

        int i = 0, imin = 0, numfree = 0, prvnumfree = 0, f = 0, i0 = 0, k = 0, freerow = 0;
        int[] pred = new int[dim], free = new int[dim];

        int j = 0, j1 = 0, j2 = 0, endofpath = 0, last = 0, low = 0, up = 0;
        int[] collist = new int[dim], matches = new int[dim];

        int min = 0, h = 0, umin = 0, usubmin = 0, v2 = 0;
        int[] d = new int[dim];


        for (i = 0; i < dim; i++)
        {
            matches[i] = 0;
        }

        //column reduction
        for (j = dim - 1; j >= 0; j--)//reverse order gives better results
        {
            min = assigncost[0][j];
            imin = 0;
            for (i = 1; i < dim; i++)
            {
                if (assigncost[i][j] < min)
                {
                    min = assigncost[i][j];
                    imin = i;
                }
            }

            v[j] = min;

            if (++matches[imin] == 1)
            {
                rowsol[imin] = j;
                colsol[j] = imin;
            }
            else
            {
                colsol[j] = -1;
            }
        }

        //REDUCTION TRANSFER
        for (i = 0; i < dim; i++)
        {
            if (matches[i] == 0)
            {
                free[numfree++] = i;
            }
            else if (matches[i] == 1)
            {
                j1 = rowsol[i];
                min = int.MaxValue;
                for (j = 0; j < dim; j++)
                {
                    if (j != j1)
                    {
                        if (assigncost[i][j] - v[j] < min)
                        {
                            min = assigncost[i][j] - v[j];
                        }
                    }
                }

                v[j1] = v[j1] - min;
            }
        }

        //AUGMENGING ROW REDUCTION
        int loopcnt = 0;

        do
        {
            loopcnt++;
            k = 0;
            prvnumfree = numfree;
            numfree = 0;

            while (k < prvnumfree)
            {
                i = free[k];
                k++;

                //find min and second min reduced cost over cols
                umin = assigncost[i][0] - v[0];
                j1 = 0;
                usubmin = int.MaxValue;
                for (j = 1; j < dim; j++)
                {
                    h = assigncost[i][j] - v[j];
                    if (h < usubmin)
                    {
                        if (h >= umin)
                        {
                            usubmin = h;
                            j2 = j;
                        }
                        else
                        {
                            usubmin = umin;
                            umin = h;
                            j2 = j1;
                            j1 = j;
                        }
                    }
                }

                i0 = colsol[j1];

                if (umin < usubmin)
                {
                    //change the reduction of the min col to increase the min
                    //reduced cost in the row to the subminimum
                    v[j1] = v[j1] - (usubmin - umin);
                }
                else if (i0 >= 0)
                {
                    j1 = j2;
                    i0 = colsol[j2];
                }

                //(re)assign i to j1, possibly un-assigning an i0
                rowsol[i] = j1;
                colsol[j1] = i;

                if (i0 >= 0)
                {
                    if (umin < usubmin)
                    {
                        //put in current k, and go back to that k
                        //continue augmenting path i - j1 with i0
                        free[--k] = i0;
                    }
                    else
                    {
                        //no further augmenting reduction possible
                        //store i0 in list of free rows for next phase
                        free[numfree++] = i0;
                    }
                }
            }
        }
        while (loopcnt < 2);

        //AUGMENT SOLUTION for each free row
        for (f = 0; f < numfree; f++)
        {
            freerow = free[f];

            //Dijkstra shortest path algorithm
            //runs until unassigned column added to shortest path tree
            for (j = 0; j < dim; j++)
            {
                d[j] = assigncost[freerow][j] - v[j];
                pred[j] = freerow;
                collist[j] = j;
            }

            low = 0;
            up = 0;

            unassignedfound = false;

            do
            {
                if (up == low)
                {
                    last = low - 1;

                    //scan cols for up...dim-1 to find indices for which new min occurs
                    //store these indices between low...up-1 (increasing)
                    min = d[collist[up++]];

                    for (k = up; k < dim; k++)
                    {
                        j = collist[k];
                        h = d[j];
                        
                        if (h <= min)
                        {
                            if (h < min)//new min
                            {
                                up = low;//restart list at index low
                                min = h;
                            }
                        
                            //new index with same min, put on index up, and extend list
                            collist[k] = collist[up];
                            collist[up++] = j;
                        }
                    }
                    //check if any of the min cols happen to be unassigned
                    //if so, we have augmenting path
                    for (k = low; k < up; k++)
                    {
                        if (colsol[collist[k]] < 0)
                        {
                            endofpath = collist[k];
                            unassignedfound = true;
                            break;
                        }
                    }
                }

                if (!unassignedfound)
                {
                    //update 'distances' between freerow and all unscanned cols
                    j1 = collist[low];
                    low++;
                    i = colsol[j1];
                    h = assigncost[i][j1] - v[j1] - min;

                    for (k = up; k < dim; k++)
                    {
                        j = collist[k];
                        v2 = assigncost[i][j] - v[j] - h;

                        if (v2 < d[j])
                        {
                            pred[j] = i;

                            if (v2 == min)
                            {
                                if (colsol[j] < 0)
                                {
                                    endofpath = j;
                                    unassignedfound = true;
                                    break;
                                }
                                else
                                {
                                    collist[k] = collist[up];
                                    collist[up++] = j;
                                }
                            }

                            d[j] = v2;
                        }
                    }
                }
            }
            while (!unassignedfound);

            //update column prices
            for (k = 0; k <= last; k++)
            {
                j1 = collist[k];
                v[j1] = v[j1] + d[j1] - min;
            }

            //reset row and col assignments along alternating path
            do
            {
                i = pred[endofpath];
                colsol[endofpath] = i;
                j1 = endofpath;
                endofpath = rowsol[i];
                rowsol[i] = j1;
            }
            while (i != freerow);
        }

        //calculate optimal cost
        int lapcost = 0;

        for (i = 0; i < dim; i++)
        {
            j = rowsol[i];
            u[i] = assigncost[i][j] - v[j];
            lapcost += assigncost[i][j];
        }

        return lapcost;
    }
}
