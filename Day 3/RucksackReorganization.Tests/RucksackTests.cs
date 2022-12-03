namespace RucksackReorganization.Tests;

public class RucksackTests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
    [InlineData("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV", "vPwwTWBwg")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn")]
    [InlineData("ttgJtRGJQctTZtZT", "ttgJtRGJ", "QctTZtZT")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", "CrZsJsPPZsGz", "wwsLwLmpwMDw")]
    public void When_LoadingRucksack_ShouldSplitEqualyInTwoCompartments(string items, string exptectedFirstCompartment, string exptectedSecondCompartment)
    {
        var ruckSack = new Rucksack(items);

        Assert.Equal(exptectedFirstCompartment, ruckSack.FirstCompartment);
        Assert.Equal(exptectedSecondCompartment, ruckSack.SecondCompartment);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", new[] { 'p' })]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", new[] { 'L' })]
    [InlineData("PmmdzqPrVvPwwTWBwg", new[] { 'P' })]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", new[] { 'v' })]
    [InlineData("ttgJtRGJQctTZtZT", new[] { 't' })]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", new[] { 's' })]
    public void When_FindingErrors_ShouldReturnErrors(string items, IEnumerable<char> expectedErrors)
    {
        var ruckSack = new Rucksack(items);

        Assert.Equal(expectedErrors, ruckSack.FindErrors());
    }
}