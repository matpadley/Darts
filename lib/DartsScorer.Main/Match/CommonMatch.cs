using DartsScorer.Main.Models;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public abstract MatchType MatchType { get; set; }

    private List<Player> players = new List<Player>();

    public IReadOnlyList<Player> Players => players.AsReadOnly();

    private List<Set> sets = new List<Set>();

    public IReadOnlyList<Set> Sets => sets.AsReadOnly();

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void StartMatch()
    {
        // throw exception if no players
        if (players.Count == 0)
        {
            throw new InvalidOperationException("Cannot start match with no players");
        }

        CurrentPlayer = players[0];
    }

    public Player? CurrentPlayer {get; private set;}
}
