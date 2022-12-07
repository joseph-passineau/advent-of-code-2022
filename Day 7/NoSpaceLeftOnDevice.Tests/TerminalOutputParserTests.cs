namespace NoSpaceLeftOnDevice.Tests;
public class TerminalOutputParserTests
{
    [Fact]
    public void When_ParsingChangeDirectory_ShouldChangeDirectory()
    {
        var fileSystem = new FileSystem(70000000);
        fileSystem.CurrentDirectory.CreateDirectory("a");

        var terminalOutputParser = new TerminalOutputParser(fileSystem);
        terminalOutputParser.ParseTerminalLine("$ cd a");

        Assert.Equal("a", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void When_ParsingChangeDirectoryMoveOut_ShouldChangeDirectoryToParent()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        fileSystem.CurrentDirectory.CreateDirectory("b");
        fileSystem.ChangeDirectory("b");

        var terminalOutputParser = new TerminalOutputParser(fileSystem);
        terminalOutputParser.ParseTerminalLine("$ cd ..");

        Assert.Equal("a", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void When_ParsingChangeDirectoryToTop_ShouldChangeDirectoryToRoot()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        fileSystem.CurrentDirectory.CreateDirectory("b");
        fileSystem.ChangeDirectory("b");

        var terminalOutputParser = new TerminalOutputParser(fileSystem);
        terminalOutputParser.ParseTerminalLine("$ cd /");

        Assert.Equal("/", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void When_ParsingListDirectory_ShouldDoNothing()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        var terminalOutputParser = new TerminalOutputParser(fileSystem);
        terminalOutputParser.ParseTerminalLine("$ ls");

        Assert.Equal("a", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void When_ParseFileLine_ShouldCreateFile()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        var terminalOutputParser = new TerminalOutputParser(fileSystem);
        terminalOutputParser.ParseTerminalLine("627 test.txt");

        var file = fileSystem.CurrentDirectory.Files.First();

        Assert.Equal("test.txt", file.Name);
        Assert.Equal(627, file.Size);
    }

    [Fact]
    public void When_ParseDirectoryLine_ShouldCreateDirectory()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        var terminalOutputParser = new TerminalOutputParser(fileSystem);
        terminalOutputParser.ParseTerminalLine("dir b");

        var directory = fileSystem.CurrentDirectory.Directories.First();

        Assert.Equal("b", directory.Name);
    }

    [Fact]
    public void When_ParsExample1_FindSizeOfAllSmallDirectories()
    {
        var fileSystem = new FileSystem(70000000);
        var terminalOutputParser = new TerminalOutputParser(fileSystem);

        foreach (string line in System.IO.File.ReadLines(@"example1.txt"))
        {
            terminalOutputParser.ParseTerminalLine(line);
        }

        var exampleAnswer = fileSystem.RootDirectory.AllDirectories()
            .Where(d => d.Size < 100000)
            .Sum(d => d.Size);

        Assert.Equal(95437, exampleAnswer);
    }

    [Fact]
    public void When_ParsExample1_ShouldHaveCorrectAvailableSpace()
    {
        var fileSystem = new FileSystem(70000000);
        var terminalOutputParser = new TerminalOutputParser(fileSystem);

        foreach (string line in System.IO.File.ReadLines(@"example1.txt"))
        {
            terminalOutputParser.ParseTerminalLine(line);
        }

        Assert.Equal(21618835, fileSystem.AvailableSpace);
    }

    [Fact]
    public void When_ParsExample1_FindSmallestDirectoryToDelete()
    {
        var updateSize = 30000000;

        var fileSystem = new FileSystem(70000000);
        var terminalOutputParser = new TerminalOutputParser(fileSystem);

        foreach (string line in System.IO.File.ReadLines(@"example1.txt"))
        {
            terminalOutputParser.ParseTerminalLine(line);
        }

        var spaceNeeded = updateSize - fileSystem.AvailableSpace;
        var smallestFolder = fileSystem.RootDirectory.AllDirectories()
            .Where(d => d.Size >= spaceNeeded)
            .OrderBy(d => d.Size)
            .First();

        Assert.Equal(24933642, smallestFolder.Size);
    }
}
