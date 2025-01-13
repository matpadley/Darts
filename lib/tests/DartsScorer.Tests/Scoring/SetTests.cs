using DartsScorer.Main.Models;
using DartsScorer.Main.Scoring.x01;

namespace DartsScorer.Tests.Scoring;

public class SetTests
{
    [Test]
    public void Instantiate()
    {
        var set = new Set();

        Assert.That(set.SetLegs.Count, Is.EqualTo(0));
    }

    [Test]
    public void Can_Add_Leg()
    {
        var set = new Set();
        var leg = new Leg();

        set.AddLeg(leg);

        Assert.That(set.SetLegs.Count, Is.EqualTo(1));
    }
}
