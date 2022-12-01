namespace CalorieCounting;
public class Elf
{
    public List<int> FoodItemCalories { get; private set; } = new();

    public int TotalCalories { 
        get 
        { 
            return FoodItemCalories.Sum();
        } 
    }

    public void AddFoodItemCalories(int foodItemCalories)
    {
        FoodItemCalories.Add(foodItemCalories);
    }
}
