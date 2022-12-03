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
}
