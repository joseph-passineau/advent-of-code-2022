using System.Text;

namespace SupplyStacks;
public class ShipCrane9001
{
    private List<Stack<Crate>> cargo = new();

    public void LoadCargo(List<Stack<Crate>> cargo)
    {
        this.cargo = cargo;
    }

    public void Execute(RearrangementProcedure rearrangementProcedure)
    {
        var temp = new Stack<Crate>();
        for(var r = 0; r < rearrangementProcedure.Repeat; r++)
        {
            var crate = this.cargo[rearrangementProcedure.MoveFrom - 1].Pop();
            temp.Push(crate);
        }

        foreach(var crate in temp)
        {
            this.cargo[rearrangementProcedure.MoveTo - 1].Push(crate);
        }
    }

    public override string ToString()
    {
        var width = cargo.Count;
        var height = cargo.Max(x => x.Count);

        var ouputCargo = new List<List<Crate>>();
        foreach (var cargoStack in cargo)
        {
            var listStack = cargoStack.ToList();
            listStack.Reverse();
            ouputCargo.Add(listStack);
        }

        var output = new StringBuilder();

        for (var y = height - 1; y >= 0; y--)
        {
            for (var x = 0; x <= width - 1; x++)
            {
                if (ouputCargo[x].Count > y)
                {
                    output.Append(ouputCargo[x].ToArray()[y].ToString());
                }
                else
                {
                    output.Append(' ', 3);
                }
                output.Append(' ');
            }
            output.AppendLine();
        }

        for (var num = 1; num <= width; num++)
        {
            output.Append($" {num} ");
            output.Append(' ');
        }

        return output.ToString();
    }
}
