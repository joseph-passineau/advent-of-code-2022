namespace RucksackReorganization;
public class Rucksack
{
	public Rucksack(string items)
	{
		var middleIndex = items.Length / 2;

        FirstCompartment = items[..(middleIndex)];
        SecondCompartment = items[middleIndex..];
    }

	public string FirstCompartment { get; }

	public string SecondCompartment { get; }

	public IEnumerable<char> FindErrors()
	{
		var firstCompartmentItems = FirstCompartment.ToCharArray();

		return firstCompartmentItems
			.Where(i => SecondCompartment.Contains(i))
			.Distinct()
			.ToList();
    }
}
