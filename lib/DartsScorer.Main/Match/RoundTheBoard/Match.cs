namespace DartsScorer.Main.Match.RoundTheBoard;

public class Match : CommonMatch
{
    public Match()
    {
        DartsMatchType = DartsMatchType.RoundTheBoard;
    }

    public override string Name { get; } = "Round The Board";
    
    
}