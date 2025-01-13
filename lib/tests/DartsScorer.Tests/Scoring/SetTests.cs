using DartsScorer.Main.Scoring;
using DartsScorer.Main.Scoring.x01;

namespace DartsScorer.Tests.Scoring;

public class SetTests
{
    /// <summary>
    /// Tests the instantiation of the <see cref="Set"/> class.
    /// </summary>
    /// <remarks>
    /// This test verifies that a new instance of the <see cref="Set"/> class is created
    /// and that its <see cref="Set.SetLegs"/> collection is initialized with a count of zero.
    /// </remarks>
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

public class Set
{
    private ICollection<CommonLeg> Legs { get; } = new List<CommonLeg>();

    public CommonLeg[] SetLegs => Legs.ToArray();

    internal void AddLeg(Leg leg)
    {
        Legs.Add(leg);
    }
}