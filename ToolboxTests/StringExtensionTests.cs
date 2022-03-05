using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class StringExtensionTests
{
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
    public void TestRandomString()
    {
        var s1 = StringExtensions.RandomString();
        var s2 = StringExtensions.RandomString();

        Assert.NotEqual(s1, s2);
    }
}
