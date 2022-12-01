
using CalorieCounting;
using System.Text;

Console.WriteLine("Advent of Code - Day 1");

using var fileStream = new FileStream(@"input.txt", FileMode.Open, FileAccess.Read);
using var streamReader = new StreamReader(fileStream, Encoding.UTF8);


var elvesCalorieTracker = new ElvesCalorieTracker();
var currentElf = new Elf();

while (streamReader.Peek() >= 0)
{
    var foodItemCalories = streamReader.ReadLine();

    if(string.IsNullOrEmpty(foodItemCalories))
    {
        elvesCalorieTracker.AddElf(currentElf);
        currentElf = new Elf();
    }
    else
    {
        if (int.TryParse(foodItemCalories, out var foodItemCaloriesValue))
        {
            currentElf.AddFoodItemCalories(foodItemCaloriesValue);
        }
        else
        {
            throw new Exception($"Could not parse food item calories. Line: {streamReader.BaseStream.Position}");
        }
    }
}

var elfWithMostCalories = elvesCalorieTracker.ElfWithMostCalories();
if(elfWithMostCalories != null)
{
    Console.WriteLine($"Elf with most calories has a total of {elfWithMostCalories.TotalCalories}");
}
else
{
    Console.WriteLine("No elves were tracked.");
}