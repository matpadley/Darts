using System;

namespace DartsScorer.Tests;

public class GameTests
{
    public GameType GameTypes { get; private set; }

    [Test]
    public void Instansitation_Success()
    {
        var gameType = GameType.x01;
        var game = new Game(gameType);
        Assert.That(game.GameType, Is.EqualTo(GameType.x01));
    }

    [Test]
    public void Instansitation_Failure()
    {
        var gameType = GameType.Killer;
        var game = new Game(gameType);
        Assert.That(game.GameType, !Is.EqualTo(GameType.x01));
    }
}

internal class Game
{
    public GameType GameType {get;}

    public Game(GameType gameType)
    {
        this.GameType = gameType;
    }
}

public enum GameType
{
    x01,
    Killer
}