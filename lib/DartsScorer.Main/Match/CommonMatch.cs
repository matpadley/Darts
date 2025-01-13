using DartsScorer.Main.Models;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public abstract MatchType MatchType { get; set; }

    private readonly List<MatchPlayer> players = [];

    public IReadOnlyList<MatchPlayer> Players => players.AsReadOnly();

    private List<Set> sets = [];

    public IReadOnlyList<Set> Sets => sets.AsReadOnly();

    public Set CurrentSet = new();

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
