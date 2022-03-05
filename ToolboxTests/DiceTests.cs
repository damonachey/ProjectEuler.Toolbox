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
        var actual = Dice.RandomRolls(1, 6).Take(100000).ToList();
        var counts = actual.GroupBy(d => d[0]);
        var average = counts.Select(g => g.Count()).Average();

        // make sure the distribution is no more than 0.02% from expected
        foreach (var count in counts)
        {
            Assert.True(Math.Abs(1.0 - count.Count() / average) < 0.02);
        }
    }

    [Fact]
    public void DiceRandomRollsMultipleDice()
    {
        var actual = Dice.RandomRolls(2, 6).Take(100000).ToList();
        var counts = actual.GroupBy(d => d[0] + d[1]);

        // make sure the distribution is no more than 0.02% from expected
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
        var actual = Dice.PossibleRolls(2, 6).ToList();

        Assert.Equal(expected, actual.Count);
        Assert.Equal(expected, actual.Distinct().Count());
    }

    [Fact]
    public void MeteredRollsOneDie()
    {
        var actual = Dice.MeteredRolls(1, 6).Take(100000).ToList();
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
        var actual = Dice.MeteredRolls(2, 6).Take(100000).ToList();
        var counts = actual.GroupBy(d => d[0] + d[1]);

        // make sure the distribution is no more than 0.02% from expected
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 2).Count() / counts.Where(g => g.Key == 2 || g.Key == 12).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 3).Count() / counts.Where(g => g.Key == 3 || g.Key == 11).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 4).Count() / counts.Where(g => g.Key == 4 || g.Key == 10).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 5).Count() / counts.Where(g => g.Key == 5 || g.Key == 9).Sum(g => g.Count())) < 0.0002);
        Assert.True(Math.Abs(0.50 - (double)counts.Single(g => g.Key == 6).Count() / counts.Where(g => g.Key == 6 || g.Key == 8).Sum(g => g.Count())) < 0.0002);
    }
}
