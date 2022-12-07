namespace SupplyStacks.Tests;

public class CrateTests
{
    [Theory]
    [InlineData('C', "[C]")]
    [InlineData('M', "[M]")]
    [InlineData('Z', "[Z]")]
    [InlineData('A', "[A]")]
    public void When_ToStringCreate_ShouldReturnProperStringFormat(char crateValue, string expectedString)
    {
        var crate = new Crate(crateValue);

        Assert.Equal(expectedString, crate.ToString());
    }
}
