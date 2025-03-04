namespace DartsScorer.Main.Match;

public class MatchConfiguration
{
    public int NumberOfSets { get; private set; } = 1;

    public int NumberOfLegs { get; private set; } = 1;
    
    public void SetNumberOfSets(int sets)
    {
        NumberOfSets = sets;
    }

    public void SetNumberOfLegs(int legs)
    {
        NumberOfLegs = legs;
    }
    
}