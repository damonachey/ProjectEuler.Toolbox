using ProjectEuler.Toolbox;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class TupleExtensionsTests
{
    [Fact]
    public void Sum()
    {
        var expected = 123;
        var tuple = (100, 20, 3);
        var actual = tuple.Sum();

        Assert.Equal(expected, actual);
    }
}
