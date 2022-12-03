namespace RockPaperScissors.Tests;
public class GameEngineTests
{
    [Theory]
    [InlineData(HandShape.Rock, HandShape.Paper, RoundResult.Lost)]
    [InlineData(HandShape.Paper, HandShape.Scissors, RoundResult.Lost)]
    [InlineData(HandShape.Scissors, HandShape.Rock, RoundResult.Lost)]
    [InlineData(HandShape.Rock, HandShape.Scissors, RoundResult.Won)]
    [InlineData(HandShape.Paper, HandShape.Rock, RoundResult.Won)]
    [InlineData(HandShape.Scissors, HandShape.Paper, RoundResult.Won)]
    [InlineData(HandShape.Rock, HandShape.Rock, RoundResult.Draw)]
    [InlineData(HandShape.Paper, HandShape.Paper, RoundResult.Draw)]
    [InlineData(HandShape.Scissors, HandShape.Scissors, RoundResult.Draw)]
    public void When_PlayRound_ShouldReturnProperResult(HandShape playerHand, HandShape opponentHand, RoundResult expectedResult)
    {
        // Arrange

        var gameEngine = new GameEngine();

        // Act

        var roundResult = gameEngine.PlayRound(playerHand, opponentHand);

        // Assert

        Assert.Equal(expectedResult, roundResult);
    }
}
