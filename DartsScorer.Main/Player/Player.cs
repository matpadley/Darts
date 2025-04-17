namespace DartsScorer.Main.Player;

/// <summary>
/// Represents a darts player with a name.
/// This is the base class for all player types in the darts scoring system.
/// </summary>
/// <param name="name">The name of the player</param>
public class Player(string name) : IEquatable<Player>
{
    /// <summary>
    /// Gets the player's name.
    /// </summary>
    public string Name { get; } = name;
    
    /// <summary>
    /// Determines whether the specified object is equal to the current player.
    /// Players are considered equal if they have the same name.
    /// </summary>
    /// <param name="obj">The object to compare with the current player</param>
    /// <returns>true if the specified object has the same name as this player; otherwise, false</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Name == ((Player)obj).Name;
    }

    /// <summary>
    /// Determines whether the specified player is equal to the current player.
    /// </summary>
    /// <param name="other">The player to compare with the current player</param>
    /// <returns>true if the specified player has the same name as this player; otherwise, false</returns>
    public bool Equals(Player? other)
    {
        if (other is null) return false;
        return Name == other.Name;
    }

    /// <summary>
    /// Gets a hash code for the player based on their name.
    /// </summary>
    /// <returns>A hash code for the current player</returns>
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}