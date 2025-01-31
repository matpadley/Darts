namespace DartsScorer.Main.Player;

public class Player(string name)
{
    public string Name { get; } = name;
    
    // add an equality override to check on the name
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Name == ((Player)obj).Name;
    }
    
}