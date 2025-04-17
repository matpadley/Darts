using System.Security.Cryptography.X509Certificates;

namespace DartsScorer.Main.Player;

public class Player(string name)
{
    public string Name { get; } = name;
    public Guid Id { get; } = Guid.NewGuid();

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Name == ((Player)obj).Name;
    }

    protected bool Equals(Player other)
    {
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}