using DartsScorer.Main.Match.x01;

namespace DartsScorer.Tests;

public class X01MatchTests
{
    [Test]
    public void Match_Instantiate_X01_Match_Success()
    {
        var match = new Match();

        Assert.That(match.MatchType, Is.EqualTo(Main.Match.MatchType.x01));
    }

    [Test]
    public void Match_Instantiate_Match_X01_Fail()
    {
        var match = new Match();

        Assert.That(match.MatchType, Is.Not.EqualTo(Main.Match.MatchType.Killer));
    }
}