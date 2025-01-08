using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class GameTests
{
    public GameType GameTypes { get; private set; }

    [Test]
    public void Instansitation_Success()
    {
        var gameVariant = new X01Variant();

        var game = new Game(gameVariant);
        Assert.That(game.GameVariant, Is.EqualTo(gameVariant));
        Assert.That(game.GameVariant.VariantType, Is.EqualTo(GameType.x01));
    }

    [Test]
    public void Instansitation_Failure()
    {
        var gameVariant = new X01Variant();        
        var gameVariantToFail = new KillerVarient();
        var game = new Game(gameVariant);
        Assert.That(game.GameVariant, !Is.EqualTo(gameVariantToFail.VariantType));
    }
}
