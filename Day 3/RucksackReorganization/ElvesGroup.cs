namespace RucksackReorganization;
public class ElvesGroup
{
    public const int GroupLimit = 3;
    private List<Rucksack> groupRucksacks = new List<Rucksack>();
    public int Count => groupRucksacks.Count;

    public bool IsFull => Count >= GroupLimit;

    public void Clear()
    {
        groupRucksacks.Clear();
    }

    public void AddRucksack(Rucksack rucksack)
    {
        if (!IsFull)
        {
            groupRucksacks.Add(rucksack);
        }
    }

    public char FindBadge()
    {
        var smallestRucksack = groupRucksacks.MinBy(r => r.DistinctItems);
        if (smallestRucksack is null) throw new Exception("Elves groups must contain atleast 2 rucksack to find badge.");

        var smallestRucksackDistinctItems = string.Concat(smallestRucksack.FirstCompartment, smallestRucksack.SecondCompartment)
            .ToCharArray()
            .Distinct();

        var otherRucksackDistinctItems = groupRucksacks
            .Where(r => r != smallestRucksack)
            .Select(r => r.DistinctItems);

        return smallestRucksackDistinctItems
            .Where(x => 
                otherRucksackDistinctItems
                .All(o => o.Contains(x))
            )
            .FirstOrDefault();
    }
}
