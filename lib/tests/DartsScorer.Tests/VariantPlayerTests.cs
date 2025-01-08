namespace DartsScorer.Tests;

public class VariantPlayerTests
{

    [Test]
    public void Instansitation()
    {
        var variantPlayer = new VariantPlayer("Fancy New Team");
        Assert.That(variantPlayer.Name, Is.EqualTo("Fancy New Team")); // Corrected the variable name
    }
}
