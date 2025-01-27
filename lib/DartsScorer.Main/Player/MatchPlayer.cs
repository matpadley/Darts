using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Player;

public abstract class MatchPlayer(Player player) : Player(player.Name)
{
    public abstract void StartThrow();
    public abstract void Throw(BoardScore one, Multiplier multiplier);
    public abstract void EndThrow();
}