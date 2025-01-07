using System;

namespace DartsScorer.Tests;

public class GameTests
{
    public GameType GameTypes { get; private set; }

    [Test]
    public void Instansitation_Success()
    {
        var gameVariant = new X01Varient();

        var game = new Game(gameVariant);
        Assert.That(game.GameVariant, Is.EqualTo(gameVariant));
        Assert.That(game.GameVariant.VariantType, Is.EqualTo(GameType.x01));
    }

    [Test]
    public void Instansitation_Failure()
    {
        var gameVariant = new X01Varient();        
        var gameVariantToFail = new KillerVarient();
        var game = new Game(gameVariant);
        Assert.That(game.GameVariant, !Is.EqualTo(gameVariantToFail.VariantType));
    }
}

public abstract class GameVarient
{
    public abstract GameType VariantType { get; set; }
}

public class X01Varient: GameVarient
{
    public override GameType VariantType { get; set; } = GameType.x01;

    public X01Varient()
    {

    }
}

public class KillerVarient: GameVarient
{
    public override GameType VariantType { get; set; } = GameType.Killer;
    public KillerVarient()
    {

    }
}

public class Game
{
    public GameVarient GameVariant {get;}

    public Game(GameVarient gameVariant)
    {
        GameVariant = gameVariant;
    }
}

public enum GameType
{
    None,
    x01,
    Killer
}