using DartsScorer.Main.Match.x01;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Tests.Scoring;

public class SetTests
{
    [Test]
    public void Scoring_Set_Instantiate()
    {
        var set = new Set();

        Assert.That(set.SetLegs.Count, Is.EqualTo(0));
    }

    [Test]
    public void Scoring_Set_Can_Add_Leg()
    {
        var set = new Set();
        var leg = new Leg();

        set.AddLeg(leg);

        Assert.That(set.SetLegs.Count, Is.EqualTo(1));
    }
}
