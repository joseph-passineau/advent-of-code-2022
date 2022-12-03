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

    [Theory]
    [InlineData(HandShape.Paper, RoundResult.Lost, HandShape.Rock)]
    [InlineData(HandShape.Scissors, RoundResult.Lost, HandShape.Paper)]
    [InlineData(HandShape.Rock, RoundResult.Lost, HandShape.Scissors)]
    [InlineData(HandShape.Scissors, RoundResult.Won, HandShape.Rock)]
    [InlineData(HandShape.Rock, RoundResult.Won, HandShape.Paper)]
    [InlineData(HandShape.Paper, RoundResult.Won, HandShape.Scissors)]
    [InlineData(HandShape.Rock, RoundResult.Draw, HandShape.Rock)]
    [InlineData(HandShape.Paper, RoundResult.Draw, HandShape.Paper)]
    [InlineData(HandShape.Scissors, RoundResult.Draw, HandShape.Scissors)]
    public void When_CalculateHandShapeNeeded_ShouldReturnHandShapeNeeded(HandShape opponentHand, RoundResult wantedResult, HandShape expectedHandShape)
    {
        // Arrange

        var gameEngine = new GameEngine();
        var gameRoundStrategy = new GameRoundStrategy(opponentHand, wantedResult);

        // Act

        var handShapeNeeded = gameEngine.CalculateHandShapeNeeded(gameRoundStrategy);

        // Assert

        Assert.Equal(expectedHandShape, handShapeNeeded);
    }
}
