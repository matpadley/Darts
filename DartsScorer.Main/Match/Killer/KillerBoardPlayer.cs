using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.Killer;

public class KillerBoardPlayer(string name) : MatchPlayer(new Player.Player(name))
{
    public override void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        throw new NotImplementedException();
    }

    public override bool Finished()
    {
        throw new NotImplementedException();
    }
}