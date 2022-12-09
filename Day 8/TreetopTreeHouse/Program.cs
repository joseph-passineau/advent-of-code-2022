using TreetopTreeHouse;

Console.WriteLine("Advent of Code - Day 8");

var quadcopter = new Quadcopter(@"input.txt");

var visibleTreesCount = quadcopter.CountVisibleTrees();
var bestScenicScore = quadcopter.FindBestScenicScore();

Console.WriteLine($"The number of trees that are visible from outside the grid is {visibleTreesCount}");
Console.WriteLine($"The highest scenic score possible for any tree is {bestScenicScore}");