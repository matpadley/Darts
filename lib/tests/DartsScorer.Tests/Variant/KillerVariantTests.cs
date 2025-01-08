using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests.Variant;

public class KillerVariantTests
{    
    [Test]
    public void Killer_Instansitation()
    {
        var gameVariant = new X01Variant();
        Assert.That(gameVariant.VariantType, Is.EqualTo(GameType.x01));
    }
    [Test]
    public void Killer_Instansitation_Failure()
    {    
        var gameVariant = new Killer();
        Assert.That(gameVariant.VariantType, !Is.EqualTo(GameType.x01));
    }
}
