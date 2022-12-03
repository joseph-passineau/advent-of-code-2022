namespace RockPaperScissors;

public class GameRound
{
	public GameRound(HandShape opponentHandShape, HandShape shouldPlayHandShape)
	{
        OpponentHandShape = opponentHandShape;
        ShouldPlayHandShape = shouldPlayHandShape;
    }

    public HandShape OpponentHandShape { get; }
    public HandShape ShouldPlayHandShape { get; }
}