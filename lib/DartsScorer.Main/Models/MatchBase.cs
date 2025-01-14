namespace DartsScorer.Main.Models;

public abstract class MatchBase
{
    public abstract DartsMatchType MatchType { get; set; }

    // add an abstract method to allow players to be added to a player array
    public abstract void AddPlayer(Player player);

    // add an abstract method to allow players to be removed from a player array
    //public abstract void RemovePlayer(Player player);

    // add a new array for the players
    protected List<MatchPlayer> _players = new List<MatchPlayer>();

    public IReadOnlyList<MatchPlayer> Players => _players.AsReadOnly();
}
