using TreetopTreeHouse;

Console.WriteLine("Advent of Code - Day 8");

var quadcopter = new Quadcopter(@"input.txt");
var visibleTreesCount = quadcopter.CountVisibleTrees();

Console.WriteLine($"The number of trees that are visible from outside the grid is {visibleTreesCount}");