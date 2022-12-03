namespace RockPaperScissors;
public class GameRoundStrategy
{
	public GameRoundStrategy(HandShape opponentHandShape, RoundResult wantedRoundResult)
	{
        OpponentHandShape = opponentHandShape;
        WantedRoundResult = wantedRoundResult;
    }

    public HandShape OpponentHandShape { get; }

    public RoundResult WantedRoundResult { get; }
}
