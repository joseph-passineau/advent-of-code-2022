namespace RockPaperScissors.Tests;
public class TournamentTests
{
    [Theory]
    [InlineData(HandShape.Rock, HandShape.Paper, 1)]
    [InlineData(HandShape.Paper, HandShape.Scissors, 2)]
    [InlineData(HandShape.Scissors, HandShape.Rock, 3)]
    [InlineData(HandShape.Rock, HandShape.Rock, 4)]
    [InlineData(HandShape.Paper, HandShape.Paper, 5)]
    [InlineData(HandShape.Scissors, HandShape.Scissors, 6)]
    [InlineData(HandShape.Rock, HandShape.Scissors, 7)]
    [InlineData(HandShape.Paper, HandShape.Rock, 8)]
    [InlineData(HandShape.Scissors, HandShape.Paper, 9)]

    public void When_CalculateRoundScore_ShouldReturnProperScore(HandShape playerHand, HandShape opponentHand, int expectedScore)
    {
        // Arrange

        var tournament = new Tournament();
        var gameRound = new GameRound(opponentHand, playerHand);

        // Act

        var roundScore = tournament.CalculateRoundScore(gameRound);

        // Assert

        Assert.Equal(expectedScore, roundScore);
    }
}
