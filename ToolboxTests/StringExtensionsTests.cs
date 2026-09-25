using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class StringExtensionsTests
{
    [Fact]
    public void Replace()
    {
        var expected = "testing";
        var actual = "tasting".Replace(1, 'e');

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SubstringFound()
    {
        var expected = " a midnight ";
        var actual = "Once upon a midnight dreary".Substring("upon", "dreary");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SubstringStartNotFound()
    {
        Assert.Throws<ArgumentException>(() => "Once upon a midnight dreary".Substring("upn", "dreary"));
    }

    [Fact]
    public void SubstringEndNotFound()
    {
        Assert.Throws<ArgumentException>(() => "Once upon a midnight dreary".Substring("upon", "drery"));
    }

    [Fact]
    public void RandomString()
    {
        // The parameterless overload picks a length in 0..131 and fills it with
        // lowercase a-z. Property checks only, so the test is deterministic.
        var actual = StringExtensions.RandomString();

        Assert.InRange(actual.Length, 0, 131);
        Assert.All(actual, c => Assert.InRange(c, 'a', 'z'));
    }

    [Fact]
    public void RandomStringSpecifiedSize()
    {
        var actual = StringExtensions.RandomString(10);

        Assert.Equal(10, actual.Length);
        Assert.All(actual, c => Assert.InRange(c, 'a', 'z'));
    }
}
