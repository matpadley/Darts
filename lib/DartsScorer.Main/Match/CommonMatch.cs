using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public DartsMatchType DartsMatchType { get; set; }

    private readonly List<Player.MatchPlayer> players = [];

    public IReadOnlyList<Player.MatchPlayer> Players => players.AsReadOnly();

    private List<Set> sets = [];

    public IReadOnlyList<Set> Sets => sets.AsReadOnly();

    public Set CurrentSet = new();

    public void AddPlayer(Player.Player player)
    {
        players.Add(new Player.MatchPlayer(player));
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

    public Player.Player? CurrentPlayer { get; private set; }
}
