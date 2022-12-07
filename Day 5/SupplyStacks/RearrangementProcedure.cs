namespace SupplyStacks;
public class RearrangementProcedure
{
    public RearrangementProcedure(int moveFrom, int moveTo, int repeat)
	{
        MoveFrom = moveFrom;
        MoveTo = moveTo;
        Repeat = repeat;
    }

    public int MoveFrom { get; }

    public int MoveTo { get; }

    public int Repeat { get; }
}
