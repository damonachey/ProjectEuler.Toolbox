namespace ProjectEuler.Toolbox;

public static class Similarity
{
    /// <SUMMARY>Computes the Levenshtein Edit Distance between two enumerables.</SUMMARY>
    /// <TYPEPARAM name="T">The type of the items in the enumerables.</TYPEPARAM>
    /// <PARAM name="x">The first enumerable.</PARAM>
    /// <PARAM name="y">The second enumerable.</PARAM>
    /// <RETURNS>The edit distance.</RETURNS>
    public static int EditDistance<T>(IEnumerable<T> x, IEnumerable<T> y) where T : IEquatable<T>
    {
        // Convert the parameters into IList instances
        // in order to obtain indexing capabilities
        var first = x as IList<T> ?? new List<T>(x);
        var second = y as IList<T> ?? new List<T>(y);

        // Get the length of both.  If either is 0, return
        // the length of the other, since that number of insertions
        // would be required.
        var n = first.Count;
        var m = second.Count;
        if (n == 0)
        {
            return m;
        }

        if (m == 0)
        {
            return n;
        }

        // Rather than maintain an entire matrix (which would require O(n*m) space),
        // just store the current row and the next row, each of which has a length m+1,
        // so just O(m) space. Initialize the current row.
        var curRow = 0;
        var nextRow = 1;
        var rows = new[]
        {
            new int[m + 1],
            new int[m + 1],
        };

        for (var j = 0; j <= m; ++j)
        {
            rows[curRow][j] = j;
        }

        // For each virtual row (since we only have physical storage for two)
        for (var i = 1; i <= n; ++i)
        {
            // Fill in the values in the row
            rows[nextRow][0] = i;
            for (var j = 1; j <= m; ++j)
            {
                var dist1 = rows[curRow][j] + 1;
                var dist2 = rows[nextRow][j - 1] + 1;
                var dist3 = rows[curRow][j - 1] + (first[i - 1].Equals(second[j - 1]) ? 0 : 1);

                rows[nextRow][j] = Math.Min(dist1, Math.Min(dist2, dist3));
            }

            // Swap the current and next rows
            if (curRow == 0)
            {
                curRow = 1;
                nextRow = 0;
            }
            else
            {
                curRow = 0;
                nextRow = 1;
            }
        }

        // Return the computed edit distance
        return rows[curRow][m];
    }

    public static int EditDistance(string s, string t)
    {
        var n = s.Length;
        var m = t.Length;
        var d = new int[n + 1, m + 1];

        // Step 1
        if (n == 0)
        {
            return m;
        }

        if (m == 0)
        {
            return n;
        }

        // Step 2
        for (var i = 0; i <= n; d[i, 0] = i++) { }
        for (var j = 0; j <= m; d[0, j] = j++) { }

        // Step 3
        for (var i = 1; i <= n; i++)
        {
            //Step 4
            for (var j = 1; j <= m; j++)
            {
                // Step 5
                var cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                // Step 6
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
            }
        }

        // Step 7
        return d[n, m];
    }
}
