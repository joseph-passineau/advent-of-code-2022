namespace NoSpaceLeftOnDevice;
public class Directory : IFileSystemObject, IFileSystemContainer
{
    private List<File> files;

    private List<Directory> directories;

    internal Directory(string name)
    {
        Name = name;
        files = new List<File>();
        directories = new List<Directory>();
        Parent = this;
    }

	public Directory(string name, Directory parent) 
        : this(name)
	{
        Parent = parent;
    }

    public string Name { get; }

    public Directory Parent { get; }

    public int Size { 
        get
        {
            return files.Sum(x => x.Size) + directories.Sum(x=> x.Size);
        } 
    }

    public IEnumerable<File> Files => files;

    public IEnumerable<Directory> Directories => directories;

    public Directory CreateDirectory(string name)
    {
        var newDirectory = new Directory(name, this);
        directories.Add(newDirectory);

        return newDirectory;
    }

    public void AddFile(File file)
    {
        files.Add(file);
    }

    public IEnumerable<Directory> AllDirectories() => this.Directories.SelectMany(c => c.AllDirectories()).Concat(this.Directories);
}
