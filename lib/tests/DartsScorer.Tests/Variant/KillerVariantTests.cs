using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests.Variant;

public class KillerVariantTests
{       
     GameVariant? gameVariant;

    [SetUp]
    public void Setup()
    {
        gameVariant = new Killer();
    }

    [Test]
    public void Killer_Instansitation()
    {
        Assert.That(gameVariant?.VariantType, Is.EqualTo(GameType.Killer));
    }
    [Test]
    public void Killer_Instansitation_Failure()
    {    
        Assert.That(gameVariant?.VariantType, !Is.EqualTo(GameType.x01));
    }
}
