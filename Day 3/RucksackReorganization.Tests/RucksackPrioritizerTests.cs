namespace RucksackReorganization.Tests;
public class RucksackPrioritizerTests
{
    [Theory]
    [MemberData(nameof(GetLowercaseItemsPriority))]
    [MemberData(nameof(GetUppercaseItemsPriority))]
    public void When_CalculatingItemPriority_Should_ReturnExpectedPriotity(char item, int expectedPriority)
    {
        var rucksackPrioritizer = new RucksackPrioritizer();

        var itemPriority = rucksackPrioritizer.CalulateItemPriority(item);

        Assert.Equal(expectedPriority, itemPriority);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [InlineData("ttgJtRGJQctTZtZT", 20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]
    public void When_CalculatingRucksackPriority_Should_ReturnExpectedPriotity(string items, int expectedPriority)
    {
        var rucksack = new Rucksack(items);
        var rucksackPrioritizer = new RucksackPrioritizer();

        var itemPriority = rucksackPrioritizer.CalculateRucksackPriority(rucksack);

        Assert.Equal(expectedPriority, itemPriority);
    }

    public static IEnumerable<object[]> GetLowercaseItemsPriority()
    {
        var value = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            value++;
            yield return new object[] { c , value };
        }
    }

    public static IEnumerable<object[]> GetUppercaseItemsPriority()
    {
        var value = 26;
        for (char c = 'A'; c <= 'Z'; c++)
        {
            value++;
            yield return new object[] { c, value };
        }
    }
}
