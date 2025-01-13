namespace DartsScorer.Main.Models.Variants;

public class KillerVarient : CommonMatch
{
    public override MatchType MatchType { get; set; } = MatchType.Killer;
    public KillerVarient()
    {

    }
}
