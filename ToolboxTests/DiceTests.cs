using ProjectEuler.Toolbox;
using System;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class DiceTests
{
    [Fact]
    public void DiceRandomRollsSingleDie()
    {
        // 100000 samples put the 2% bound at ~2.8 sigma (≈3% flake rate per run);
        // 1000000 samples put it near 9 sigma, so the test is stable while still
        // catching grossly biased generators.
        var actual = Dice.RandomRolls(1, 6).Take(1000000).ToArray();
        var counts = actual.GroupBy(d => d[0]);
        var average = counts.Select(g => g.Count()).Average();

        // make sure the distribution is no more than 2% from expected
        foreach (var count in counts)
        {
            Assert.True(Math.Abs(1.0 - count.Count() / average) < 0.02);
        }
    }

    [Fact]
    public void DiceRandomRollsMultipleDice()
    {
        var actual = Dice.RandomRolls(2, 6).Take(1000000).ToArray();
        var counts = actual.GroupBy(d => d[0] + d[1]);

        // make sure the distribution is no more than 2% from expected
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 2).Count() / counts.Where(g => g.Key == 2 || g.Key == 12).Sum(g => g.Count())) < 0.02);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 3).Count() / counts.Where(g => g.Key == 3 || g.Key == 11).Sum(g => g.Count())) < 0.02);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 4).Count() / counts.Where(g => g.Key == 4 || g.Key == 10).Sum(g => g.Count())) < 0.02);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 5).Count() / counts.Where(g => g.Key == 5 || g.Key == 9).Sum(g => g.Count())) < 0.02);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 6).Count() / counts.Where(g => g.Key == 6 || g.Key == 8).Sum(g => g.Count())) < 0.02);
    }

    [Fact]
    public void DicePossibleRolls()
    {
        var expected = 36;
        var actual = Dice.PossibleRolls(2, 6).ToArray();

        Assert.Equal(expected, actual.Length);
        Assert.Equal(expected, actual.Distinct().Count());
    }

    [Fact]
    public void DicePossibleRollsZeroDice()
    {
        var actual = Dice.PossibleRolls(0, 6).ToArray();

        Assert.Single(actual);
        Assert.Empty(actual[0]);
    }

    [Fact]
    public void DicePossibleRollsNegativeDiceThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Dice.PossibleRolls(-1, 6).ToArray());
    }

    [Fact]
    public void DicePossibleRollsThreeDice()
    {
        var actual = Dice.PossibleRolls(3, 6).ToArray();

        Assert.Equal(216, actual.Length);
        Assert.Equal(216, actual.Distinct().Count());
    }

    [Fact]
    public void MeteredRollsOneDie()
    {
        var actual = Dice.MeteredRolls(1, 6).Take(100000).ToArray();
        var counts = actual.GroupBy(d => d[0]);
        var average = counts.Select(g => g.Count()).Average();

        // make sure the distribution is no more than 0.02% from expected
        foreach (var count in counts)
        {
            Assert.True(Math.Abs(1.0 - count.Count() / average) < 0.0002);
        }
    }

    [Fact]
    public void MeteredRollsMultipleDice()
    {
        var actual = Dice.MeteredRolls(2, 6).Take(100000).ToArray();
        var counts = actual.GroupBy(d => d[0] + d[1]);

        // make sure the distribution is no more than 0.02% from expected
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 2).Count() / counts.Where(g => g.Key == 2 || g.Key == 12).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 3).Count() / counts.Where(g => g.Key == 3 || g.Key == 11).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 4).Count() / counts.Where(g => g.Key == 4 || g.Key == 10).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 5).Count() / counts.Where(g => g.Key == 5 || g.Key == 9).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 6).Count() / counts.Where(g => g.Key == 6 || g.Key == 8).Sum(g => g.Count())) < 0.0002);
    }
}
