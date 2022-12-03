namespace RockPaperScissors;
public class GameEngine
{
    private readonly Dictionary<HandShape, HandShape> winningConditions = new Dictionary<HandShape, HandShape>()
    {
        { HandShape.Paper, HandShape.Rock },
        { HandShape.Rock, HandShape.Scissors },
        { HandShape.Scissors, HandShape.Paper }
    };

    public RoundResult PlayRound(HandShape yourHand, HandShape opponentHand)
    {
        if(yourHand == opponentHand)
        {
            return RoundResult.Draw;
        }

        return winningConditions[yourHand] == opponentHand ? RoundResult.Won : RoundResult.Lost;
    }

    public HandShape CalculateHandShapeNeeded(GameRoundStrategy gameRoundStrategy)
    {
        if (gameRoundStrategy.WantedRoundResult == RoundResult.Draw)
        {
            return gameRoundStrategy.OpponentHandShape;
        }

        if(gameRoundStrategy.WantedRoundResult == RoundResult.Won)
        {
            return winningConditions.First(x => x.Value == gameRoundStrategy.OpponentHandShape).Key;
        }
        else
        {
            return winningConditions[gameRoundStrategy.OpponentHandShape];
        }
    }
}
