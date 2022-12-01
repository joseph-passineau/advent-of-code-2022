namespace CalorieCounting.Tests;
public class ElfUnitTests
{
    [Fact]
    public void When_AddingFoodItemCalories_ShouldIncreaseItemCount()
    {
        // Arrange
        var elf = new Elf();

        // Act
        elf.AddFoodItemCalories(1000);
        elf.AddFoodItemCalories(1000);

        // Assert
        Assert.NotEmpty(elf.FoodItemCalories);
        Assert.Equal(2, elf.FoodItemCalories.Count);
    }

    [Fact]
    public void When_CalculatingTotal_ShouldReturnSumOfAllFoodItemCalories()
    {
        // Arrange
        var elf = new Elf();

        // Act
        elf.AddFoodItemCalories(1000);
        elf.AddFoodItemCalories(2000);
        elf.AddFoodItemCalories(6000);

        // Assert
        Assert.Equal(9000, elf.TotalCalories);
    }
}
