namespace SupplyStacks;
public class CargoParser
{
    const int CharPerCrate = 4;

    private List<List<Crate>> cargo = new List<List<Crate>>();
    private readonly int numberOfStacks;

    public CargoParser(int numberOfStacks)
    {
        this.numberOfStacks = numberOfStacks;

        for (int i = 0; i < numberOfStacks; i++)
        {
            cargo.Add(new List<Crate>());
        }
    }

    public void ParseCargoDrawing(string line)
    {
        for(int i = 0; i < numberOfStacks; i++)
        {
            var crateChar = line.Substring(i * CharPerCrate + 1, 1);

            if(!string.IsNullOrEmpty(crateChar))
            {
                var crateValue = crateChar.ToCharArray()[0];
                if(crateValue > 65 && crateValue < 91)
                {
                    cargo[i].Add(new Crate(crateValue));
                }
            }
        }
    }

    public RearrangementProcedure RearrangementProcedureParser(string line)
    {
        var procedureArray = line.Split(' ');

        var repeate = int.Parse(procedureArray[1]);
        var from = int.Parse(procedureArray[3]);
        var to = int.Parse(procedureArray[5]);

        return new RearrangementProcedure(from, to, repeate);
    }

    public List<Stack<Crate>> OutputCargo()
    {
        var output = new List<Stack<Crate>>();
        foreach(var cargoStack in cargo)
        {
            var createStack = new Stack<Crate>();

            cargoStack.Reverse();
            foreach (var crate in cargoStack)
            {
                createStack.Push(crate);
            }

            output.Add(createStack);
        }

        return output;
    }

    public static int CalculateNumberOfStacks(string line)
    {
        return (int)Math.Ceiling(line.Length / (double)CharPerCrate);
    }
}
