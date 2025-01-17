using DartsScorer.Main.Match;
using DartsScorer.Main.Match.RoundTheBoard;

namespace DartsScore.RoundTheBoard;

public class InstantiateTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RoundTheBoard_Instantiate()
    {
        var roundTheBoard = new Match();
        
        Assert.That(roundTheBoard.DartsMatchType, Is.EqualTo(DartsMatchType.RoundTheBoard));
    }
    
    [Test]
    public void RoundTheBoard_Instantiate_Failure()
    {
        var roundTheBoard = new Match();
        
        Assert.That(roundTheBoard.DartsMatchType, !Is.EqualTo(DartsMatchType.X01));
        Assert.That(roundTheBoard.Players.Count, Is.EqualTo(0));
    }
}
