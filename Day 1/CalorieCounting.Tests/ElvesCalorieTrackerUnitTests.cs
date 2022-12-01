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

    [Fact]
    public void When_GettingElfWithMostCalories_ShouldReturnElfWithHighestCalorieCount()
    {
        // Arrange
        var elvesCalorieTracker = new ElvesCalorieTracker();

        var elf1 = new Elf();
        elf1.AddFoodItemCalories(1000);
        elvesCalorieTracker.AddElf(elf1);

        var elf2 = new Elf();
        elf2.AddFoodItemCalories(4000);
        elvesCalorieTracker.AddElf(elf2);

        var elf3 = new Elf();
        elf3.AddFoodItemCalories(3999);
        elvesCalorieTracker.AddElf(elf3);

        // Act
        var elfWithMostCalories = elvesCalorieTracker.ElfWithMostCalories();

        // Assert
        Assert.NotNull(elfWithMostCalories);
        Assert.Equal(4000, elfWithMostCalories.TotalCalories);
    }


    [Fact]
    public void When_CalculatingSumOfTop3ElvesTotalCalories_ShouldReturnSumOfTop3ElevesCalories()
    {
        // Arrange
        var elvesCalorieTracker = new ElvesCalorieTracker();

        var elf1 = new Elf();
        elf1.AddFoodItemCalories(3000);
        elvesCalorieTracker.AddElf(elf1);

        var elf2 = new Elf();
        elf2.AddFoodItemCalories(4000);
        elvesCalorieTracker.AddElf(elf2);

        var elf3 = new Elf();
        elf3.AddFoodItemCalories(1999);
        elvesCalorieTracker.AddElf(elf3);

        var elf4 = new Elf();
        elf4.AddFoodItemCalories(2000);
        elvesCalorieTracker.AddElf(elf4);

        // Act
        var top3ElvesTotalCalories = elvesCalorieTracker.SumOfTop3ElvesTotalCalories();

        // Assert
        Assert.Equal(9000, top3ElvesTotalCalories);
    }
}
