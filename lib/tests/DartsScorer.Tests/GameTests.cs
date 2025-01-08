using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class GameTests
{
    public GameType GameTypes { get; private set; }

    [Test]
    public void Game_Instansitation_Success()
    {
        var gameVariant = new X01Variant();

        var game = new Game(gameVariant);
        Assert.That(game.GameVariant, Is.EqualTo(gameVariant));
    }
}
