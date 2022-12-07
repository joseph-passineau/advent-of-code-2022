namespace SupplyStacks;
public class Crate
{
	public Crate(char content)
	{
        Content = content;
    }

    public char Content { get; }

    public override string ToString()
    {
        return $"[{Content}]";
    }
}
