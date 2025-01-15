using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public DartsMatchType DartsMatchType { get; set; }

    private readonly List<Player.MatchPlayer> _players = [];

    public IReadOnlyList<Player.MatchPlayer> Players => _players.AsReadOnly();

    private List<Set> _sets = [];

    public IReadOnlyList<Set> Sets => _sets.AsReadOnly();

    public Set CurrentSet = new();

    public void AddPlayer(Player.Player player)
    {
        _players.Add(new Player.MatchPlayer(player));
    }

    public void StartMatch()
    {
        // throw exception if no players
        if (_players.Count == 0)
        {
            throw new InvalidOperationException("Cannot start match with no players");
        }

        CurrentPlayer = _players[0];
    }

    public Player.Player? CurrentPlayer { get; private set; }
}
