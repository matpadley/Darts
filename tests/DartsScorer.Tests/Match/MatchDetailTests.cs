using System.Reflection;
using DartsScorer.Main.Match;

namespace DartsScorer.Tests.Match;

public class MatchDetailTests
{
    [Test]
    public void Match_Read_The_Name_And_Description()
    {
        //iterate of the CommonMatch abstract type find the ones that inherit it
        var matchTypes = Assembly.GetAssembly(typeof(CommonMatch))?.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CommonMatch)))
            .ToList();
        
        // write the name and description of each match type
        foreach (var match in matchTypes)
        {
            Console.WriteLine($"Match Name: {match.Name}");
        }
    }
}