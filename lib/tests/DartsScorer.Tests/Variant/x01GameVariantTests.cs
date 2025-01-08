using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class x01GameVariantTests
{
    [Test]
    public void x01_Instansitation()
    {
        var gameVariant = new X01Variant();
        Assert.That(gameVariant.VariantType, Is.EqualTo(GameType.x01));
    }

    [Test]
    public void x01_Instansitation_Failre()
    {
        var gameVariant = new X01Variant();
        Assert.That(gameVariant.VariantType, !Is.EqualTo(GameType.Killer));
    }
}
