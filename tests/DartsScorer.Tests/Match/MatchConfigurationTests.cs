using DartsScorer.Main.Match;

namespace DartsScorer.Tests.Match;

public class MatchConfigurationTests
{
    [Test]
    public void MatchConfiguration_Setup_Sets()
    {
        var configuration = new MatchConfiguration();

        configuration.SetNumberOfSets(2);
        
        Assert.That(configuration.NumberOfSets, Is.EqualTo(2));
    }

    [Test]
    public void MatchConfiguration_Setup_SetsPlayers()
    {
        var configuration = new MatchConfiguration();

        configuration.SetNumberOfLegs(4);
        
        Assert.That(configuration.NumberOfLegs, Is.EqualTo(4));
    }

    [Test]
    public void MatchConfiguration_Defaults()
    {
        var configuration = new MatchConfiguration();
        
        Assert.That(configuration.NumberOfSets, Is.EqualTo(1));
        Assert.That(configuration.NumberOfLegs, Is.EqualTo(1));
    }
}