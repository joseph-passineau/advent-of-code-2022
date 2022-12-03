namespace RockPaperScissors;
public class StrategyGuideParser
{
    private readonly Dictionary<char, HandShape> letterHandShapeMapping = new Dictionary<char, HandShape>()
    {
        { 'A', HandShape.Rock },
        { 'B', HandShape.Paper },
        { 'C', HandShape.Scissors },
        { 'Y', HandShape.Paper },
        { 'X', HandShape.Rock },
        { 'Z', HandShape.Scissors },
    };

    public GameRound ParseRoundStrategy(string roundStrategy)
    {
        var chars = roundStrategy.ToCharArray();
        var opponentHandLetter = chars[0];
        var shouldPlayHandLetter = chars[2];

        var opponentHandShape = letterHandShapeMapping[opponentHandLetter];
        var shouldPlayHandShape = letterHandShapeMapping[shouldPlayHandLetter];

        return new GameRound(opponentHandShape, shouldPlayHandShape);
    }
}
