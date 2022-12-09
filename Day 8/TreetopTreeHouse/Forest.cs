namespace TreetopTreeHouse;
public class Forest
{
	public Forest(int width, int height)
	{
		Grid = new Tree[width, height];
        Width = width;
        Height = height;
    }

	public Tree[,] Grid { get; }
    public int Width { get; }
    public int Height { get; }
}
