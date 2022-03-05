using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class SimilarityTests
{
    [Fact]
    public void EditDistanceString()
    {
        var expected = 2;
        var actual = Similarity.EditDistance("this is just a test", "this was just a test");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EditDistanceEnumerable()
    {
        var expected = 2;
        var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "this was just a test".ToCharArray());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EditDistanceSame()
    {
        var expected = 0;
        var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "this is just a test".ToCharArray());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EditDistanceEmpty()
    {
        var expected = 19;
        var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "".ToCharArray());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EditDistanceEmpty2()
    {
        var expected = 19;
        var actual = Similarity.EditDistance("".ToCharArray(), "this is just a test".ToCharArray());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EditDistanceStringEmpty()
    {
        var expected = 19;
        var actual = Similarity.EditDistance("this is just a test", "");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EditDistanceStringEmpty2()
    {
        var expected = 19;
        var actual = Similarity.EditDistance("", "this is just a test");

        Assert.Equal(expected, actual);
    }
}
