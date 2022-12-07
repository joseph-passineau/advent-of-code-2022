namespace SupplyStacks.Tests;

public class CargoParserTests
{
    [Theory]
    [InlineData("[N] [C]    ", 3)]
    [InlineData("            [R] [N]     [T] [T] [C] ", 9)]
    [InlineData("[F] [W] [B] [L] [P] [D] [L] [N] [G] ", 9)]
    public void When_CalculatingNumberOfStacks_ShouldReturnProperNumberOfStacks(string line, int expectedValue)
    {
        var numberOfStacks = CargoParser.CalculateNumberOfStacks(line);

        Assert.Equal(expectedValue, numberOfStacks);
    }

    [Theory]
    [InlineData("move 1 from 2 to 1", 2, 1, 1)]
    [InlineData("move 3 from 1 to 3", 1, 3, 3)]
    [InlineData("move 2 from 2 to 1", 2, 1, 2)]
    [InlineData("move 1 from 1 to 2", 1, 2, 1)]
    public void When_ParsingRearrangementProcedure_ShouldReturnRearrangementProcedure(string line, int expectedFrom, int expectedTo, int expectedRepeat)
    {
        var cargoParser = new CargoParser(1);
        var rearrangementProcedure = cargoParser.RearrangementProcedureParser(line);

        Assert.Equal(expectedFrom, rearrangementProcedure.MoveFrom);
        Assert.Equal(expectedTo, rearrangementProcedure.MoveTo);
        Assert.Equal(expectedRepeat, rearrangementProcedure.Repeat);
    }
}