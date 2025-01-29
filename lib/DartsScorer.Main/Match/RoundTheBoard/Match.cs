namespace DartsScorer.Main.Match.RoundTheBoard;

public class Match : CommonMatch
{
    public Match()
    {
        DartsMatchType = DartsMatchType.RoundTheBoard;
    }

    public override string Name { get; } = "Round The Board";
    
    public bool IsMatchComplete => Players.Count(f => (f as RoundTheBoardPlayer).Finished()) == 1;
    public RoundTheBoardPlayer Winner => Players.FirstOrDefault(f => (f as RoundTheBoardPlayer).Finished()) as RoundTheBoardPlayer;
}