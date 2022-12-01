namespace CalorieCounting.Tests;

public class ElvesCalorieTrackerIntergrationTests
{
    [Fact]
    public void When_Example1_Then_ShouldFindElfCarryingMostCalories()
    {
        // Arrange
        var elvesCalorieTracker = new ElvesCalorieTracker();

        var elf1 = new Elf();
        elf1.AddFoodItemCalories(1000);
        elf1.AddFoodItemCalories(2000);
        elf1.AddFoodItemCalories(3000);
        elvesCalorieTracker.AddElf(elf1);

        var elf2 = new Elf();
        elf2.AddFoodItemCalories(4000);
        elvesCalorieTracker.AddElf(elf2);

        var elf3 = new Elf();
        elf3.AddFoodItemCalories(5000);
        elf3.AddFoodItemCalories(6000);
        elvesCalorieTracker.AddElf(elf3);

        var elf4 = new Elf();
        elf4.AddFoodItemCalories(7000);
        elf4.AddFoodItemCalories(8000);
        elf4.AddFoodItemCalories(9000);
        elvesCalorieTracker.AddElf(elf4);

        var elf5 = new Elf();
        elf5.AddFoodItemCalories(10000);
        elvesCalorieTracker.AddElf(elf5);

        // Act
        var elfWithMostCalories = elvesCalorieTracker.ElfWithMostCalories();

        // Assert
        Assert.NotNull(elfWithMostCalories);
        Assert.Equal(24000, elfWithMostCalories.TotalCalories);
    }
}