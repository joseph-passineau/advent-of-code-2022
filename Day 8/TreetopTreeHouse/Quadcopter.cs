namespace TreetopTreeHouse;
public class Quadcopter
{
    private readonly string inputFile;

    public Quadcopter(string inputFile)
	{
        this.inputFile = inputFile;
        Forest = AnalyzeForest();
    }

    public Forest Forest { get; }

    public int CountVisibleTrees()
    {
        var visibleTreeCount = 0;

        for(var y = 0; y < Forest.Height; y++)
        {
            for(var x = 0; x < Forest.Width; x++)
            {
                if (IsTreeVisible(x, y))
                {
                    visibleTreeCount++;
                }
            }
        }

        return visibleTreeCount;
    }

    public int FindBestScenicScore()
    {
        var bestScore = 0;

        for (var y = 0; y < Forest.Height; y++)
        {
            for (var x = 0; x < Forest.Width; x++)
            {
                var treeScenicScore = TreeScenicScore(x, y);
                if (treeScenicScore > bestScore)
                {
                    bestScore = treeScenicScore;
                }
            }
        }

        return bestScore;
    }

    public int TreeScenicScore(int x, int y)
    {
        var tree = Forest.Grid[y, x];
        var visibleTreesUp = VisibleTreesUp(x, y, tree.Height);
        var visibleTreesDown = VisibleTreesDown(x, y, tree.Height);
        var visibleTreesLeft = VisibleTreesLeft(x, y, tree.Height);
        var visibleTreesRight = VisibleTreesRight(x, y, tree.Height);

        return visibleTreesUp * visibleTreesDown * visibleTreesLeft * visibleTreesRight;
    }

    private int VisibleTreesUp(int x, int y, int height)
    {
        var count = 0;
        var up = y - 1;

        while (up >= 0)
        {
            count++;
            if (height <= Forest.Grid[up, x].Height)
            {
                return count;
            }
            up--;
        }

        return count;
    }

    private int VisibleTreesDown(int x, int y, int height)
    {
        var count = 0;
        var down = y + 1;

        while (down <= Forest.Height - 1)
        {
            count++;
            if (height <= Forest.Grid[down, x].Height)
            {
                return count;
            }
            down++;
        }

        return count;
    }

    private int VisibleTreesLeft(int x, int y, int height)
    {
        var count = 0;
        var left = x - 1;

        while (left >= 0)
        {
            count++;
            if (height <= Forest.Grid[y, left].Height)
            {
                return count;
            }
            left--;
        }

        return count;
    }

    private int VisibleTreesRight(int x, int y, int height)
    {
        var count = 0;
        var right = x + 1;

        while (right <= Forest.Width - 1)
        {
            count++;
            if (height <= Forest.Grid[y, right].Height)
            {
                return count;
            }
            right++;
        }

        return count;
    }

    public bool IsTreeVisible(int x, int y)
    {
        var tree = Forest.Grid[y, x];

        return IsVisibleUp(x, y, tree.Height) ||
            IsVisibleDown(x, y, tree.Height) ||
            IsVisibleLeft(x, y, tree.Height) ||
            IsVisibleRight(x, y, tree.Height);
    }

    private bool IsVisibleUp(int x, int y, int height) 
    {
        var up = y - 1;

        while(up >= 0) 
        {
            if (height <= Forest.Grid[up, x].Height)
            {
                return false;
            }
            up--;
        }

        return true;
    }

    private bool IsVisibleDown(int x, int y, int height)
    {
        var down = y + 1;

        while (down <= Forest.Height - 1)
        {
            if (height <= Forest.Grid[down, x].Height)
            {
                return false;
            }
            down++;
        }

        return true;
    }

    private bool IsVisibleLeft(int x, int y, int height)
    {
        var left = x - 1;

        while (left >= 0)
        {
            if (height <= Forest.Grid[y, left].Height)
            {
                return false;
            }
            left--;
        }

        return true;
    }

    private bool IsVisibleRight(int x, int y, int height)
    {
        var right = x + 1;

        while (right <= Forest.Width - 1)
        {
            if (height <= Forest.Grid[y, right].Height)
            {
                return false;
            }
            right++;
        }

        return true;
    }

    private Forest AnalyzeForest()
	{
        var forestGridHeight = File.ReadLines(inputFile).Count();
        var forestGridWidth = File.ReadLines(inputFile).First().Length;

        var forest = new Forest(forestGridHeight, forestGridWidth);

        var rowCount = 0;
        foreach (string line in File.ReadLines(inputFile))
        {
            var columnCount = 0;
            foreach (char c in line)
            {
                var height = int.Parse(c.ToString());
                forest.Grid[rowCount, columnCount] = new Tree(height);
                columnCount++;
            }
            rowCount++;
        }

        return forest;
    }
}
