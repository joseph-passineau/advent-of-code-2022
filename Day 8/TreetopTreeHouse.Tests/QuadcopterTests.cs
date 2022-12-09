namespace TreetopTreeHouse.Tests;

public class QuadcopterTests
{
    [Fact]
    public void When_AnalyzingForest_ShouldReturnForest()
    {
        var quadcopter = new Quadcopter(@"example1.txt");

        Assert.Equal(25, quadcopter.Forest.Grid.Length);
        Assert.Equal(3, quadcopter.Forest.Grid[0,0].Height);
        Assert.Equal(3, quadcopter.Forest.Grid[2,2].Height);
        Assert.Equal(9, quadcopter.Forest.Grid[4,3].Height);
        Assert.Equal(0, quadcopter.Forest.Grid[4,4].Height);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(2, 1, true)]
    [InlineData(3, 1, false)]
    [InlineData(1, 2, true)]
    [InlineData(2, 2, false)]
    [InlineData(3, 2, true)]
    [InlineData(1, 3, false)]
    [InlineData(2, 3, true)]
    [InlineData(3, 3, false)]
    public void When_CheckingIfTreeIsVisible_ShouldReturnProperValue(int x, int y, bool expectedValue)
    {
        var quadcopter = new Quadcopter(@"example1.txt");

        Assert.Equal(expectedValue, quadcopter.IsTreeVisible(x, y));
    }

    [Fact]
    public void When_CountingVisibleTrees_ShouldReturnCorrectCount()
    {
        var quadcopter = new Quadcopter(@"example1.txt");

        Assert.Equal(21, quadcopter.CountVisibleTrees());
    }

    [Theory]
    [InlineData(2, 1, 4)]
    [InlineData(2, 3, 8)]
    public void When_CalculatingTreeScenicScore_ShouldReturnProperValue(int x, int y, int expectedScore)
    {
        var quadcopter = new Quadcopter(@"example1.txt");

        Assert.Equal(expectedScore, quadcopter.TreeScenicScore(x, y));
    }

    [Fact]
    public void When_FindingBestScenicScore_ShouldReturnHighestScore()
    {
        var quadcopter = new Quadcopter(@"example1.txt");

        Assert.Equal(8, quadcopter.FindBestScenicScore());
    }
}