using DartsScorer.Main.Match.RoundTheBoard;

namespace DartsScorer.Main.Match.RoundTheBoard;

public sealed class Match : CommonMatch
{
    public Match()
    {
        DartsMatchType = DartsMatchType.RoundTheBoard;
    }
    
    public override bool IsMatchComplete => Players.Count(f => (f as RoundTheBoardPlayer).Finished()) == 1;
    public RoundTheBoardPlayer Winner => Players.FirstOrDefault(f => (f as RoundTheBoardPlayer).Finished()) as RoundTheBoardPlayer;
    public override string Name => "Round The Board";

    public override bool MatchInProgress { get; set; }

    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            SetCurrentPlayer(Players.First());
            MatchInProgress = true;
        }
    }
}