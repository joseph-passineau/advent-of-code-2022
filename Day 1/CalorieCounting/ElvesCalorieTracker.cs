namespace CalorieCounting;

public class ElvesCalorieTracker
{
    public List<Elf> Elves { get; private set; } = new();


    public void AddElf(Elf elf)
    {
        Elves.Add(elf);
    }

    public Elf? ElfWithMostCalories()
    {
        return Elves
            .OrderByDescending(x => x.TotalCalories)
            .FirstOrDefault();
    }

    public int SumOfTop3ElvesTotalCalories()
    {
        return Elves
            .OrderByDescending(x => x.TotalCalories)
            .Take(3)
            .Sum(x => x.TotalCalories);
    }
}
