namespace RockPaperScissors;
public class Tournament
{
    private readonly Dictionary<HandShape, int> handShapeScoreMapping = new Dictionary<HandShape, int>()
    {
        { HandShape.Rock, 1 },
        { HandShape.Paper, 2 },
        { HandShape.Scissors, 3 },
    };

    private readonly Dictionary<RoundResult, int> gameResultScoreMapping = new Dictionary<RoundResult, int>()
    {
        { RoundResult.Lost, 0 },
        { RoundResult.Draw, 3 },
        { RoundResult.Won, 6 },
    };

    public GameEngine GameEngine { get; } = new GameEngine();

    public int CalculateRoundScore(GameRound round)
    {
        var result = GameEngine.PlayRound(round.ShouldPlayHandShape, round.OpponentHandShape);
        return handShapeScoreMapping[round.ShouldPlayHandShape] + gameResultScoreMapping[result];
    }
}
