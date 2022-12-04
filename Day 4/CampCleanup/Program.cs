using CampCleanup;

Console.WriteLine("Advent of Code - Day 4");

var assigmentPairsFullyContainedCount = 0;
var assigmentPairsOverlapCount = 0;

foreach (string line in File.ReadLines(@"input.txt"))
{
    var assignmentPairsParser = new AssignmentsPairsParser(line);
    
    if(assignmentPairsParser.Pair.IsFullyContained)
    {
        assigmentPairsFullyContainedCount++;
    }

    if (assignmentPairsParser.Pair.IsOverlapped)
    {
        assigmentPairsOverlapCount++;
    }
}

Console.WriteLine($"The count of how many assignment pairs does one range fully contain the other is {assigmentPairsFullyContainedCount}");
Console.WriteLine($"The count of how many assignment pairs do the ranges overlap is {assigmentPairsOverlapCount}");