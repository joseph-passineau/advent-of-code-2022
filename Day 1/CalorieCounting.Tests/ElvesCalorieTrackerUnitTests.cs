namespace CalorieCounting.Tests;
public class ElvesCalorieTrackerUnitTests
{
    [Fact]
    public void When_AddingElf_ShouldIncreaseElfCount()
    {
        // Arrange
        var elvesCalorieTracker = new ElvesCalorieTracker();

        // Act
        elvesCalorieTracker.AddElf(new Elf());
        elvesCalorieTracker.AddElf(new Elf());

        // Assert
        Assert.NotEmpty(elvesCalorieTracker.Elves);
        Assert.Equal(2, elvesCalorieTracker.Elves.Count);
    }
}
