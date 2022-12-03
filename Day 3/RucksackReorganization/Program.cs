using RucksackReorganization;

Console.WriteLine("Advent of Code - Day 3");

var sumOfAllRucksacksPriorities = 0;
var rucksackPrioritizer = new RucksackPrioritizer();

foreach (string line in File.ReadLines(@"input.txt"))
{
    var rucksack = new Rucksack(line);
    sumOfAllRucksacksPriorities += rucksackPrioritizer.CalculateRucksackPriority(rucksack);
}

Console.WriteLine($"The sum of the priorities of all the rucksacks is {sumOfAllRucksacksPriorities}");