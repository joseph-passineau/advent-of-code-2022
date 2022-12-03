namespace RucksackReorganization;
public class RucksackPrioritizer
{
    private readonly int upperCaseItemPriorityAsciiCodeModifier = 27 - (int)'A';
    private readonly int lowerCaseItemPriorityAsciiCodeModifier = 1 - (int)'a';

    public int CalculateRucksackPriority(Rucksack rucksack)
    {
        var items = rucksack.FindErrors();
        return items.Sum(x => CalulateItemPriority(x));
    }

    public int CalulateItemPriority(char item)
    {
        var itemAsciiCode = (int)item;
        var isItemLowerCase = itemAsciiCode >= (int)'a';

        var modifier = isItemLowerCase ? lowerCaseItemPriorityAsciiCodeModifier : upperCaseItemPriorityAsciiCodeModifier;

        return itemAsciiCode + modifier;
    }
}
