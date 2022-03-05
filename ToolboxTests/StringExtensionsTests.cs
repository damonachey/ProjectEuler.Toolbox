using ProjectEuler.Toolbox;
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
}
