namespace DartsScorer.Tests.Match;

public class MatchConfigurationTests
{
    [Test]
    public void MatchConfiguration_Setup_Sets()
    {
        var configuration = new MatchConfig();

        configuration.SetNumberOfSets(2);
        
        Assert.That(configuration.NumberOfSets, Is.EqualTo(2));
    }

    [Test]
    public void MatchConfiguration_Setup_SetsPlayers()
    {
        var configuration = new MatchConfig();

        configuration.SetNumberOfLegs(4);
        
        Assert.That(configuration.NumberOfLegs, Is.EqualTo(4));
    }
}

public class MatchConfig
{
    public int NumberOfSets { get; private set; }

    public int NumberOfLegs { get; private set; }   
    
    public void SetNumberOfSets(int sets)
    {
        NumberOfSets = sets;
    }

    public void SetNumberOfLegs(int legs)
    {
        NumberOfLegs = legs;
    }
    
}