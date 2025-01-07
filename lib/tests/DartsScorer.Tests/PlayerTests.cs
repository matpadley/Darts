public class PlayerTests
{
    [Test]
    public void Instansitation()
    {
        var player = new Player("John");
        Assert.That(player.Name, Is.EqualTo("John"));
    }

    [Test]
    public void Instansitation_Fail()
    {
        var player = new Player("John");
        Assert.That(player.Name, !Is.EqualTo("Steven"));
    }
}
