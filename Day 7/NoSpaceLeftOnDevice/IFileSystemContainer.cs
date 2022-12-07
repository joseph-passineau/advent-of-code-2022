namespace NoSpaceLeftOnDevice;

public interface IFileSystemContainer
{
    public IEnumerable<File> Files { get; }

    public IEnumerable<Directory> Directories { get; }

    public Directory Parent { get; }

    public Directory CreateDirectory (string name);

    public void AddFile(File file);
}