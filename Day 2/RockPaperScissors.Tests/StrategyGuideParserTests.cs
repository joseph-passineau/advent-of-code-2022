namespace RockPaperScissors.Tests;

public class StrategyGuideParserTests
{
    [Theory]
    [InlineData("A Y", HandShape.Rock, HandShape.Paper)]
    [InlineData("B X", HandShape.Paper, HandShape.Rock)]
    [InlineData("C Z", HandShape.Scissors, HandShape.Scissors)]
    public void When_ParsingRoundStrategy_ShouldReturnGameRound(string roundStrategy, HandShape expectedOpponentHand, HandShape expectedShouldPlayHand)
    {
        // Arrange

        var strategyGuideParser = new StrategyGuideParser();

        // Act

        var gameRound = strategyGuideParser.ParseRoundStrategy(roundStrategy);

        // Assert

        Assert.Equal(expectedOpponentHand, gameRound.OpponentHandShape);
        Assert.Equal(expectedShouldPlayHand, gameRound.ShouldPlayHandShape);
    }
}