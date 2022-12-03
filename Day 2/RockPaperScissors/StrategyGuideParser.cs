namespace RockPaperScissors;
public class StrategyGuideParser
{
    private readonly Dictionary<char, HandShape> letterHandShapeMapping = new Dictionary<char, HandShape>()
    {
        { 'A', HandShape.Rock },
        { 'B', HandShape.Paper },
        { 'C', HandShape.Scissors },
    };

    private readonly Dictionary<char, RoundResult> letterRoundResultMapping = new Dictionary<char, RoundResult>()
    {
        { 'Y', RoundResult.Draw },
        { 'X', RoundResult.Lost },
        { 'Z', RoundResult.Won },
    };

    public GameRoundStrategy ParseRoundStrategy(string roundStrategy)
    {
        var chars = roundStrategy.ToCharArray();
        var opponentHandLetter = chars[0];
        var shouldPlayHandLetter = chars[2];

        var opponentHandShape = letterHandShapeMapping[opponentHandLetter];
        var expectedRoundResult = letterRoundResultMapping[shouldPlayHandLetter];

        return new GameRoundStrategy(opponentHandShape, expectedRoundResult);
    }
}
