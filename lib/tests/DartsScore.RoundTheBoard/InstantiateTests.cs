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
        var _match = new Match();
        
        Assert.That(_match.DartsMatchType, Is.EqualTo(DartsMatchType.RoundTheBoard));
        Assert.That(_match?.Name, Is.EqualTo("Killer"));
    }
    
    [Test]
    public void RoundTheBoard_Instantiate_Failure()
    {
        var roundTheBoard = new Match();
        
        Assert.That(roundTheBoard.DartsMatchType, !Is.EqualTo(DartsMatchType.X01));
        Assert.That(roundTheBoard.Players.Count, Is.EqualTo(0));
    }
}
