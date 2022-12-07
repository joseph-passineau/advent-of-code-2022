namespace SupplyStacks.Tests;
public class ShipTests
{
    [Fact]
    public void When_ExecutingProcedure_ShouldMoveCrates()
    {
        var cargoParser = new CargoParser(3);
        cargoParser.ParseCargoDrawing("    [D]     ");
        cargoParser.ParseCargoDrawing("[N] [C]     ");
        cargoParser.ParseCargoDrawing("[Z] [M] [P] ");

        var cargo = cargoParser.OutputCargo();
        var ship = new Ship();
        ship.LoadCargo(cargo);

        var rearrangementProcedure = new RearrangementProcedure(2, 1, 1);

        ship.Execute(rearrangementProcedure);

        var shipCargoState = ship.ToString();

        Assert.Equal(@"[D]         \r\n[N] [C]     \r\n[Z] [M] [P] \r\n 1   2   3 ", shipCargoState);
    }

    [Fact]
    public void When_ExecutingProcedureWithCrane9001_ShouldMoveCrates()
    {
        var cargoParser = new CargoParser(3);
        cargoParser.ParseCargoDrawing("    [D]     ");
        cargoParser.ParseCargoDrawing("[N] [C]     ");
        cargoParser.ParseCargoDrawing("[Z] [M] [P] ");

        var cargo = cargoParser.OutputCargo();
        var ship = new ShipCrane9001();
        ship.LoadCargo(cargo);

        var rearrangementProcedure = new RearrangementProcedure(2, 3, 2);

        ship.Execute(rearrangementProcedure);

        var shipCargoState = ship.ToString();

        Assert.Equal(@"[D]         \r\n[N] [C]     \r\n[Z] [M] [P] \r\n 1   2   3 ", shipCargoState);
    }
}
