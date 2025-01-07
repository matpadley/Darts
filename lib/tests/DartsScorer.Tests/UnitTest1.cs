namespace DartsScorer.Tests;

public class PlayerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PlayerInstansitation()
    {
        var player = new Player("John");
        Assert.That(player.Name, Is.EqualTo("John"));
    }
}

public class Player
{
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
    }
}