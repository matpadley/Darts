using DartsScorer.Main.Match;
using DartsScorer.Main.Match.RoundTheBoard;

namespace DartsScore.RoundTheBoard;

public class InstantiateTests
{
    [Test]
    public void RoundTheBoard_Instantiate()
    {
        var match = new Match();
        
        Assert.That(match.DartsMatchType, Is.EqualTo(DartsMatchType.RoundTheBoard));
        Assert.That(match.Name, Is.EqualTo("Round The Board"));
    }
    
    [Test]
    public void RoundTheBoard_Instantiate_Failure()
    {
        var roundTheBoard = new Match();
        
        Assert.That(roundTheBoard.DartsMatchType, !Is.EqualTo(DartsMatchType.X01));
        Assert.That(roundTheBoard.Players.Count, Is.EqualTo(0));
    }
}
