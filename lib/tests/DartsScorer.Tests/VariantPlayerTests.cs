namespace DartsScorer.Tests;

public class VariantPlayerTests
{

    [Test]
    public void VariantPlayer_Instansitation()
    {
        var player = new Player("Fancy New Team");
        var variantPlayer = new VariantPlayer(player);
        Assert.That(variantPlayer.Name, Is.EqualTo("Fancy New Team")); // Corrected the variable name
    }
}
