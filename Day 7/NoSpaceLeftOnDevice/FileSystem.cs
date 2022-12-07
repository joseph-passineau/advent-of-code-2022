using System.Linq;

namespace NoSpaceLeftOnDevice;
public class FileSystem
{
	public FileSystem(int totalSpace)
	{
        RootDirectory = new RootDirectory();
        CurrentDirectory = RootDirectory;
        TotalSpace = totalSpace;
    }

	public void ChangeDirectory(string name)
	{
        CurrentDirectory = CurrentDirectory.Directories
			.Where(d => d.Name.Equals(name))
			.Single();
    }

    public void MoveOut()
    {
        CurrentDirectory = CurrentDirectory.Parent;
    }

    public void MoveTop()
    {
        CurrentDirectory = RootDirectory;
    }

	public RootDirectory RootDirectory { get; private set; }

	public Directory CurrentDirectory { get; private set; }
    public int TotalSpace { get; }

    public int AvailableSpace => TotalSpace - RootDirectory.Size;
}
