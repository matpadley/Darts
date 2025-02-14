namespace DartsScorer.Main.Match.RoundTheBoard;

public sealed class Match : CommonMatch
{
    public Match()
    {
        DartsMatchType = DartsMatchType.RoundTheBoard;
    }

    public override string Name => "Round The Board";

    public override void StartMatch()
    {
        if (CanStartMatch())
        {
            SetCurrentPlayer(Players.First());
        }
    }

    public override bool IsMatchComplete => Players.Count(f => (f as RoundTheBoardPlayer).Finished()) == 1;
    
    public RoundTheBoardPlayer Winner => Players.FirstOrDefault(f => (f as RoundTheBoardPlayer).Finished()) as RoundTheBoardPlayer;
}