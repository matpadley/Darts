using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class x01GameVariantTests
{
    GameVariant? gameVariant;

    [SetUp]
    public void Setup()
    {
        gameVariant = new X01Variant();
    }

    [Test]
    public void x01_Instansitation()
    {

        Assert.That(gameVariant?.VariantType, Is.EqualTo(GameType.x01));
    }

    [Test]
    public void x01_Instansitation_Failre()
    {
        Assert.That(gameVariant?.VariantType, !Is.EqualTo(GameType.Killer));
    }

    [Test]
    public void Add_Single_Player_Success()
    {
        var player = new  Player("Fancy New Team");
        gameVariant?.AddPlayer(player);
        Assert.That(gameVariant?.Players.Count, Is.EqualTo(1));
    }
}
