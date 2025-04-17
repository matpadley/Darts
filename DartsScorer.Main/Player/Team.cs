namespace DartsScorer.Main.Player;

/// <summary>
/// Represents a team of dart players.
/// </summary>
/// <param name="name">The name of the team</param>
public class Team(string name)
{
    /// <summary>
    /// Gets the team's name.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Gets the list of players in this team.
    /// </summary>
    public List<Player> Players { get; } = [];

    /// <summary>
    /// Gets the number of players in this team.
    /// </summary>
    public int Count => Players.Count;

    /// <summary>
    /// Adds a new player to the team if a player with the same name doesn't already exist.
    /// </summary>
    /// <param name="player">The player to add to the team</param>
    public void AddNewPlayer(Player player)
    {
        if (Players.Any(p => p.Name == player.Name))
        {
            return;
        }

        Players.Add(player);
    }
}