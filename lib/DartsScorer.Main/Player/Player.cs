namespace DartsScorer.Main.Player;

public class Player(string name)
{
    public string Name { get; } = name;

    protected bool Equals(Player other)
    {
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}