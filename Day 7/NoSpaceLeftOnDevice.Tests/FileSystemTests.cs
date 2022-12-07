namespace NoSpaceLeftOnDevice.Tests;
public class FileSystemTests
{
    [Fact]
    public void When_ChangeDirectory_ShouldChangeCurrentDirectory()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        Assert.Equal("a", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void When_MoveOut_ShouldChangeCurrentDirectoryToParent()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        fileSystem.MoveOut();

        Assert.Equal("/", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void When_MoveTop_ShouldChangeCurrentDirectoryToRoot()
    {
        var fileSystem = new FileSystem(70000000);

        fileSystem.CurrentDirectory.CreateDirectory("a");
        fileSystem.ChangeDirectory("a");

        fileSystem.CurrentDirectory.CreateDirectory("b");
        fileSystem.ChangeDirectory("b");

        fileSystem.MoveTop();

        Assert.Equal("/", fileSystem.CurrentDirectory.Name);
    }
}
