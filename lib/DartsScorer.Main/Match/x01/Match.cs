
namespace DartsScorer.Main.Models.Variants;

public class Match : CommonMatch
{
    public override MatchType MatchType { get; set; } = MatchType.x01;

    public Match()
    {

    }
}
