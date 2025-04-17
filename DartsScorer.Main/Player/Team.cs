using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DartsScorer.Main.Player;

/// <summary>
/// Represents a team in the darts scorer application.
/// </summary>
public class Team(string name)
{
    /// <summary>
    /// Gets or sets the unique identifier for the team, used with MongoDB.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    /// <summary>
    /// Gets or sets the name of the team.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the collection of players in the team.
    /// </summary>
    public ICollection<Player> Players { get; set; } = new List<Player>();

    /// <summary>
    /// Gets the number of players in the team.
    /// </summary>
    public int Count => Players.Count;

    /// <summary>
    /// Adds a new player to the team if a player with the same name does not already exist.
    /// </summary>
    /// <param name="player">The player to add to the team.</param>
    public bool AddNewPlayer(Player player)
    {
        if (Players.Any(p => p.Name == player.Name))
        {
            return false;
        }

        Players.Add(player);
        return true;
    }
}