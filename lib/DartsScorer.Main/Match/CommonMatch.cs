using DartsScorer.Main.Models;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public abstract MatchType MatchType { get; set; }

    private List<MatchPlayer> players = new List<MatchPlayer>();

    public IReadOnlyList<MatchPlayer> Players => players.AsReadOnly();

    private List<Set> sets = new List<Set>();

    public IReadOnlyList<Set> Sets => sets.AsReadOnly();

    public void AddPlayer(Player player)
    {
        players.Add(new MatchPlayer(player));
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
