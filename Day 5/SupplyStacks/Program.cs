using SupplyStacks;

Console.WriteLine("Advent of Code - Day 5");

string firstLine = File.ReadLines("input.txt").First();
var numberOfStacks = CargoParser.CalculateNumberOfStacks(firstLine);
var cargoParser = new CargoParser(numberOfStacks);

var isHeader = true;
var ship = new ShipCrane9001();
foreach (string line in File.ReadLines(@"input.txt"))
{
    if(isHeader && string.IsNullOrWhiteSpace(line))
    {
        isHeader = false;
        var cargo = cargoParser.OutputCargo();
        ship.LoadCargo(cargo);
    }

    if(isHeader)
    {
        cargoParser.ParseCargoDrawing(line);
    }
    else
    {
        if(!string.IsNullOrEmpty(line))
        {
            var rearrangmentProcedure = cargoParser.RearrangementProcedureParser(line);
            ship.Execute(rearrangmentProcedure);
        }
    }
}



Console.Write(ship.ToString());