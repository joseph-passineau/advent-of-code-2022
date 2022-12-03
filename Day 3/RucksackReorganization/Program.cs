using RucksackReorganization;

Console.WriteLine("Advent of Code - Day 3");

var sumOfAllRucksacksPriorities = 0;
var sumOfAllBadgesPriorities = 0;

var rucksackPrioritizer = new RucksackPrioritizer();
var elvesGroup = new ElvesGroup();

foreach (string line in File.ReadLines(@"input.txt"))
{
    var rucksack = new Rucksack(line);
    sumOfAllRucksacksPriorities += rucksackPrioritizer.CalculateRucksackPriority(rucksack);

    elvesGroup.AddRucksack(rucksack);

    if (elvesGroup.IsFull)
    {
        var badge = elvesGroup.FindBadge();
        sumOfAllBadgesPriorities += rucksackPrioritizer.CalulateItemPriority(badge);
        elvesGroup.Clear();
    }
}

Console.WriteLine($"The sum of the priorities of all the rucksacks is {sumOfAllRucksacksPriorities}"); 
Console.WriteLine($"The sum of the badges priorities is {sumOfAllBadgesPriorities}");