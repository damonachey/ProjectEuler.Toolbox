using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Toolbox
{
    public static class Parsers
    {
        /// <summary>
        /// Parses a newline => comma or whitespace delimited string into it's grid representation.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int[,] ParseIntGrid(string str)
        {
            var list = ParseLongLists(str);
            var grid = new int[list[0].Count, list.Count];

            // i and j swapped because rows are row/column while grid is x/y
            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 0; j < list[0].Count; j++)
                {
                    grid[j, i] = (int)list[i][j];
                }
            }

            return grid;
        }

        /// <summary>
        /// Parses newline delimited string into a list of it's substrings.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IList<string> ParseStringList(string str)
        {
            return str
                .Trim()
                .Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Parses a newline -> comma or whitespace delimited string into a list of lists containing it's string sub-values.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IList<IList<string>> ParseStringLists(string str)
        {
            return ParseStringList(str)
                .Select(s => (IList<string>)s.Split(", \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(s2 => s2)
                    .ToList())
                .ToList();
        }

        /// <summary>
        /// Parses a newline -> comma or whitespace delimited string into a list of lists containing it's long sub-values.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IList<IList<long>> ParseLongLists(string str)
        {
            return ParseStringLists(str)
                .Select(sl => (IList<long>)sl.Select(long.Parse).ToList())
                .ToList();
        }

        /// <summary>
        /// Parses a newline => comma or whitespace delimited string into it's grid representation.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long[,] ParseLongGrid(string str)
        {
            var list = ParseLongLists(str);
            var grid = new long[list[0].Count, list.Count];

            // i and j swapped because rows are row/column while grid is x/y
            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 0; j < list[0].Count; j++)
                {
                    grid[j, i] = list[i][j];
                }
            }

            return grid;
        }
    }
}