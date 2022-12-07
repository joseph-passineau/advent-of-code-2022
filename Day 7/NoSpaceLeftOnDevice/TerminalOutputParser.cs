namespace NoSpaceLeftOnDevice;
public class TerminalOutputParser
{
    const string CommandIdentifier = "$";
    const string ChangeDirectoryCommand = "cd";
    const string MoveOutArgument = "..";
    const string DirectoryIdentifier = "dir";
    const string RootDirectoryIdentifier = "/";

	public TerminalOutputParser(FileSystem fileSystem)
	{
        FileSystem = fileSystem;
    }

    public FileSystem FileSystem { get; }

    public void ParseTerminalLine(string line)
    {
        if(line.StartsWith(CommandIdentifier))
        {
            ParseCommand(line);
        } 
        else
        {
            ParseFileSystemObject(line);
        }
    }

    private void ParseCommand(string line)
    {
        var parts = line.Split(' ');
        var command = parts[1];
        var arguments = parts[2..^0];

        if (arguments.Length > 0 && command.Equals(ChangeDirectoryCommand))
        {
            ParseChangeDirectory(arguments[0]);
        }
    }

    private void ParseChangeDirectory(string directoryName)
    {
        if (directoryName.Equals(MoveOutArgument))
        {
            FileSystem.MoveOut();
        }
        else
        {
            if (directoryName.Equals(RootDirectoryIdentifier))
            {
                FileSystem.MoveTop();
            }
            else
            {
                FileSystem.ChangeDirectory(directoryName);
            }
        }
    }

    private void ParseFileSystemObject(string line)
    {
        if (line.StartsWith(DirectoryIdentifier))
        {
            ParseDirectoryLine(line);
        }
        else
        {
            ParseFileLine(line);
        }
    }

    private void ParseFileLine(string line)
    {
        var parts = line.Split(' ');
        var size = int.Parse(parts[0]);
        var name = parts[1];

        var file = new File(name, size);
        FileSystem.CurrentDirectory.AddFile(file);
    }

    private void ParseDirectoryLine(string line)
    {
        var parts = line.Split(' ');
        var name = parts[1];

        FileSystem.CurrentDirectory.CreateDirectory(name);
    }
}
