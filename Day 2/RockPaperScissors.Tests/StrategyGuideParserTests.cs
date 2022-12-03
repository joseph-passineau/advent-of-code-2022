namespace RockPaperScissors.Tests;

public class StrategyGuideParserTests
{
    [Theory]
    [InlineData("A Y", HandShape.Rock, RoundResult.Draw)]
    [InlineData("B X", HandShape.Paper, RoundResult.Lost)]
    [InlineData("C Z", HandShape.Scissors, RoundResult.Won)]
    public void When_ParsingRoundStrategy_ShouldReturnGameRound(string roundStrategy, HandShape expectedOpponentHand, RoundResult expectedRoundResult)
    {
        // Arrange

        var strategyGuideParser = new StrategyGuideParser();

        // Act

        var gameRoundStrategy = strategyGuideParser.ParseRoundStrategy(roundStrategy);

        // Assert

        Assert.Equal(expectedOpponentHand, gameRoundStrategy.OpponentHandShape);
        Assert.Equal(expectedRoundResult, gameRoundStrategy.WantedRoundResult);
    }
}