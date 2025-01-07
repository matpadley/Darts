namespace DartsScorer.Tests;

public class PlayerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PlayerInstansitation_Success()
    {
        var player = new Player("John");
        Assert.That(player.Name, Is.EqualTo("John"));
    }

    [Test]
    public void PlayerInstansitation_Fail()
    {
        var player = new Player("John");
        Assert.That(player.Name, !Is.EqualTo("Steven"));
    }
}

public class Player(string name)
{
    public string Name { get; } = name;
}