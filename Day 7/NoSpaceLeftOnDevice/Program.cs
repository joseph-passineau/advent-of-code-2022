using NoSpaceLeftOnDevice;

Console.WriteLine("Advent of Code - Day 7");

const int UpdateSize = 30000000;

var fileSystem = new FileSystem(70000000);
var terminalOutputParser = new TerminalOutputParser(fileSystem);

foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    terminalOutputParser.ParseTerminalLine(line);
}

var sizeOfDirectories = fileSystem.RootDirectory.AllDirectories()
    .Where(d => d.Size < 100000)
    .Sum(d => d.Size);

var spaceNeededToFreeUp = UpdateSize - fileSystem.AvailableSpace;
var smallestDirectoryToFreeSpaceForUpdate = fileSystem.RootDirectory
    .AllDirectories()
    .Where(d => d.Size >= spaceNeededToFreeUp)
    .OrderBy(d => d.Size)
    .First();

Console.WriteLine($"The sum of the total sizes of those directories is {sizeOfDirectories}");
Console.WriteLine($"The smallest directory that, if deleted, would free up enough space on the filesystem to run the update has a total size of {smallestDirectoryToFreeSpaceForUpdate.Size}");