namespace NoSpaceLeftOnDevice;
public class File : IFileSystemObject
{
	public File(string name, int size)
	{
        Name = name;
        Size = size;
    }

    public string Name { get; }

    public int Size { get; }
}
