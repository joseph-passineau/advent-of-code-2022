namespace NoSpaceLeftOnDevice.Tests;

public class DirectoryTests
{
    [Fact]
    public void When_CreateDirectory_ShouldContainSubdirectory()
    {
        var directory = new RootDirectory();
        directory.CreateDirectory("a");
        directory.CreateDirectory("b");

        Assert.Equal(2, directory.Directories.Count());
        Assert.Equal("a", directory.Directories.ToArray()[0].Name);
        Assert.Equal("b", directory.Directories.ToArray()[1].Name);
    }

    [Fact]
    public void When_CreateNestedDirectory_ShouldBeNested()
    {
        var rootDirectory = new RootDirectory();
        var directoryA = rootDirectory.CreateDirectory("a");
        directoryA.CreateDirectory("b");

        Assert.Single(rootDirectory.Directories);
        Assert.Single(rootDirectory.Directories.Single().Directories);
        Assert.Equal("a", rootDirectory.Directories.Single().Name);
        Assert.Equal("b", rootDirectory.Directories.Single().Directories.Single().Name);
    }

    [Fact]
    public void When_WhenCalculatingSize_ShouldCalculateAllFiles()
    {
        var rootDirectory = new RootDirectory();

        var directoryA = rootDirectory.CreateDirectory("a");
        directoryA.AddFile(new File("a.txt", 200));
        directoryA.AddFile(new File("aa.txt", 300));

        var directoryB = directoryA.CreateDirectory("b");
        directoryB.AddFile(new File("b.txt", 100));
        directoryB.AddFile(new File("bb.txt", 50));

        Assert.Equal(650, rootDirectory.Size);
    }

    [Fact]
    public void When_GetAllDirectoriesFromNestedDirectories_ShouldReturnAllFlattenDirectories()
    {
        var rootDirectory = new RootDirectory();
        var directoryA = rootDirectory.CreateDirectory("a");
        var directoryB = directoryA.CreateDirectory("b");
        directoryB.CreateDirectory("b1");
        directoryB.CreateDirectory("b2");
        directoryA.CreateDirectory("c");

        var directories = rootDirectory.AllDirectories();

        Assert.Equal(5, directories.Count());
    }
}