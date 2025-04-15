using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DartsScorer.Main.Player;

/// <summary>
/// Represents a player in the darts scorer application.
/// </summary>
public class Player(string name)
{
    /// <summary>
    /// Gets or sets the unique identifier for the player, used with MongoDB.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    
    /// <summary>
    /// Gets the name of the player.
    /// </summary>
    public string Name { get; } = name;
    
    /// <summary>
    /// Determines whether the specified object is equal to the current player.
    /// </summary>
    /// <param name="obj">The object to compare with the current player.</param>
    /// <returns>True if the specified object is equal to the current player; otherwise, false.</returns>
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
    /// <param name="other">The player to compare with the current player.</param>
    /// <returns>True if the specified player is equal to the current player; otherwise, false.</returns>
    protected bool Equals(Player other)
    {
        return Name == other.Name;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current player.</returns>
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}