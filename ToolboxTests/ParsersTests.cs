﻿using ProjectEuler.Toolbox;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class ParsersTests
{
    [Fact]
    public void ParseStringLists()
    {
        var expected = new List<List<string>>
            {
                new() { "1", "2", "3", "4" },
                new() { "5", "6", "7", "8" },
            };
        var actual = Parsers.ParseStringLists(@"
                    1 2 3 4
                    5 6 7 8
                    ");

        Assert.True(expected.SelectMany(sequence => sequence).SequenceEqual(actual.SelectMany(sequence => sequence)));
    }

    [Fact]
    public void ParseStringList()
    {
        var expected = new List<string>
            {
                "1 2 3 4",
                "5 6 7 8",
            };
        var actual = Parsers.ParseStringList(@"
                    1 2 3 4
                    5 6 7 8
                    ")
            .Select(str => str.Trim());

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ParseLongLists()
    {
        var expected = new List<List<long>>
            {
                new() { 1, 2, 3, 4 },
                new() { 5, 6, 7, 8 },
            };
        var actual = Parsers.ParseLists<long>(@"
                    1 2 3 4
                    5 6 7 8
                    ");

        Assert.True(expected.SelectMany(sequence => sequence).SequenceEqual(actual.SelectMany(sequence => sequence)));
    }

    [Fact]
    public void ParseLongGrid()
    {
        var expected = new int[,] { { 1, 5 }, { 2, 6 }, { 3, 7 }, { 4, 8 } };
        var actual = Parsers.ParseGrid<int>(@"
                    1 2 3 4
                    5 6 7 8
                    ");

        for (var i = 0; i < expected.GetLength(0); i++)
        {
            for (int j = 0; j < expected.GetLength(1); j++)
            {
                Assert.Equal(expected[i, j], actual[i, j]);
            }
        }
    }

    [Fact]
    public void ParseIntGrid()
    {
        var expected = new long[,] { { 1, 5 }, { 2, 6 }, { 3, 7 }, { 4, 8 } };
        var actual = Parsers.ParseGrid<long>(@"
                    1 2 3 4
                    5 6 7 8
                    ");

        for (var i = 0; i < expected.GetLength(0); i++)
        {
            for (int j = 0; j < expected.GetLength(1); j++)
            {
                Assert.Equal(expected[i, j], actual[i, j]);
            }
        }
    }
}
