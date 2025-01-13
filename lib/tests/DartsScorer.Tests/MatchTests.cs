using DartsScorer.Main;

namespace DartsScorer.Tests;

public class MatchTests
{
    [Test]
    public void Match_Instantiate_Match_Success()
    {
        var match = new Match(Main.Match.MatchType.x01);

        Assert.That(match.MatchType, Is.EqualTo(Main.Match.MatchType.x01));
    }

    [Test]
    public void Match_Instantiate_Match_Fail()
    {
        var match = new Match(Main.Match.MatchType.x01);

        Assert.That(match.MatchType, Is.Not.EqualTo(Main.Match.MatchType.Killer));
    }
}

internal class Match
{
    public Match(Main.Match.MatchType matchType)
    {
        MatchType = matchType;
    }

    public Main.Match.MatchType MatchType { get; internal set; }
}