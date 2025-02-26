using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.RoundTheBoard;

public sealed class Match : CommonMatch
{
    
    public override bool IsMatchComplete => Players.Count(f => (f as RoundTheBoardPlayer).Finished()) == 1;
    public override MatchPlayer Winner => Players.FirstOrDefault(f => (f as RoundTheBoardPlayer).Finished());
    public override string Name => "Round The Board";
    public override DartsMatchType DartsMatchType => DartsMatchType.RoundTheBoard;
    
    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            SetCurrentPlayer(Players.First());
            MatchInProgress = true;
        }
    }
}