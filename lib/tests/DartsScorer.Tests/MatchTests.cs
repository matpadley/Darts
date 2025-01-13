using System;
using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class MatchTests
{
    [Test]
    public void Match_Instantiate_Match_Success()
    {
        var match = new Match(Main.Models.Variants.MatchType.x01);

        Assert.That(match.MatchType, Is.EqualTo(Main.Models.Variants.MatchType.x01));
    }

    [Test]
    public void Match_Instantiate_Match_Fail()
    {
        var match = new Match(Main.Models.Variants.MatchType.x01);

        Assert.That(match.MatchType, Is.Not.EqualTo(Main.Models.Variants.MatchType.Killer));
    }
}

internal class Match
{
    public Match(Main.Models.Variants.MatchType gameVariant)
    {
        MatchType = gameVariant;
    }

    public Main.Models.Variants.MatchType MatchType { get; internal set; }
}