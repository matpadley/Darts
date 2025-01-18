// See https://aka.ms/new-console-template for more information

using System.Reflection;
using DartsScorer.Main.Match;
using DartsScorer.Main.Player;

Console.WriteLine("Hello To My Darts");

// get a list of types from the DartScorer.Main and write them to the screen
var types = Assembly.GetAssembly(typeof(CommonMatch))?.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CommonMatch)))
    .ToList()
    .OrderBy(x => x.Name)
    .ToList();

var matchTuple = new List<(int index, string Name)>();

// write the name of the class that inherits COmmaonMatch to screen

for(int i = 0; i < types.Count; i++)
{
    var match = (CommonMatch)Activator.CreateInstance(types[i]);
    matchTuple.Add((i, match.Name));
}

// list out the tuple values
foreach (var (index, Name) in matchTuple)
{
    Console.WriteLine($"{index}: {Name}");
}

// get the user input and display the match description
Console.WriteLine("Enter the number of the match you want to use: ");
var input = Console.ReadLine();

// insntiate a match and display the description
var newNatch = (CommonMatch)Activator.CreateInstance(types[int.Parse(input)]);
Console.WriteLine($"You have picked: {newNatch.Name}");

// add the name of the first user
Console.WriteLine("Enter the name of the first player: ");
var player1 = Console.ReadLine();
newNatch.AddPlayer(new Player(player1));

foreach (var se in newNatch.Players.ToList().Select(f => f.Name))
{  
    Console.WriteLine($"Player: {se}");
}

