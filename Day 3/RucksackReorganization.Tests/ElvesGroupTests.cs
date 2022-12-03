namespace RucksackReorganization.Tests;
public class ElvesGroupTests
{
    [Fact]
    public void When_GroupIsFull_Should_ReturnTrue()
    {
        var elvesGroup = new ElvesGroup();
        elvesGroup.AddRucksack(new Rucksack("aa"));
        elvesGroup.AddRucksack(new Rucksack("bb"));
        elvesGroup.AddRucksack(new Rucksack("cc"));

        Assert.True(elvesGroup.IsFull);
    }

    [Fact]
    public void When_GroupIsNotFull_Should_ReturnFalse()
    {
        var elvesGroup = new ElvesGroup();
        elvesGroup.AddRucksack(new Rucksack("aa"));
        elvesGroup.AddRucksack(new Rucksack("bb"));

        Assert.False(elvesGroup.IsFull);
    }

    [Fact]
    public void When_GroupIsFull_Should_NotBeAbleToAddMoreRucksack()
    {
        var elvesGroup = new ElvesGroup();
        elvesGroup.AddRucksack(new Rucksack("aa"));
        elvesGroup.AddRucksack(new Rucksack("bb"));
        elvesGroup.AddRucksack(new Rucksack("cc"));
        elvesGroup.AddRucksack(new Rucksack("dd"));

        Assert.Equal(3, elvesGroup.Count);
    }

    [Fact]
    public void When_Clear_Should_HaveNoRucksacks()
    {
        var elvesGroup = new ElvesGroup();
        elvesGroup.AddRucksack(new Rucksack("aa"));
        elvesGroup.AddRucksack(new Rucksack("bb"));

        elvesGroup.Clear();

        Assert.Equal(0, elvesGroup.Count);
    }

    [Theory]
    [MemberData(nameof(GetElvesGroups))]
    public void When_FindingBadge_Should_ReturnCorrectBadge(ElvesGroup group, char expectedBadge)
    {
        var badge = group.FindBadge();

        Assert.Equal(expectedBadge, badge);
    }

    public static IEnumerable<object[]> GetElvesGroups()
    {
        var group1 = new ElvesGroup();
        group1.AddRucksack(new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp"));
        group1.AddRucksack(new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"));
        group1.AddRucksack(new Rucksack("PmmdzqPrVvPwwTWBwg"));

        var group2 = new ElvesGroup();
        group2.AddRucksack(new Rucksack("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"));
        group2.AddRucksack(new Rucksack("ttgJtRGJQctTZtZT"));
        group2.AddRucksack(new Rucksack("CrZsJsPPZsGzwwsLwLmpwMDw"));

        return new List<object[]>
        {
            new object[] { group1, 'r' },
            new object[] { group2, 'Z' },
        };
    }
}
