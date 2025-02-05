using System.Reflection;
using System.Text.RegularExpressions;
using DartsScorer.Main.Match;
using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using Spectre.Console;

Console.WriteLine("Hello To My Darts");

var types = GetAndDisplayMatchTypes();

// get the user input and display the match description
var input = AnsiConsole.Ask<int>("Enter the number of the match you want to use: ");

// instantiate a match and display the description
var newMatch = (CommonMatch)Activator.CreateInstance(types[input])!;

AnsiConsole.MarkupLine($"You have picked: [bold yellow]{newMatch.Name}[/]");

// add the name of the first user
var player1 = AnsiConsole.Ask<string>("Enter the name of the first player: ");
newMatch.AddPlayer(new RoundTheBoardPlayer(player1));

// add a loop so people can add new players
var addPlayer = true;

while (addPlayer)
{
    var add = AnsiConsole.Confirm("Do you want to add another player?");
    if (add)
    {
        var player = AnsiConsole.Ask<string>("Enter the name of the player: ");
        newMatch.AddPlayer(new RoundTheBoardPlayer(player));
    }
    else
    {
        addPlayer = false;
    }
}

foreach (var player in newMatch.Players.ToList().Select(f => f.Name))
{
    AnsiConsole.MarkupLine($"Player: [underline]{player}[/]");
}

// add an option to sytart the game if a player has been added to the match
if (newMatch.Players.Count > 0)
{
    var start = AnsiConsole.Confirm("Do you want to start the game?");
    if (start)
    {
        // run match start method
        newMatch.StartMatch();

        AnsiConsole.MarkupLine("Game On!");

        while (!newMatch.IsMatchComplete)
        {
            var player = newMatch.CurrentPlayer as RoundTheBoardPlayer;

            AnsiConsole.MarkupLine("[blue]--------------------------------[/]"); 
            AnsiConsole.MarkupLine($"[blue]Current Player - {player.Name} - Score: {player.RequiredBoardNumber}[/]");
            // write a line under the above line
            AnsiConsole.MarkupLine("[blue]--------------------------------[/]");

            player.StartThrow();
            if (!player.Finished()) HandleThrow(player);
            if (!player.Finished()) HandleThrow(player);
            if (!player.Finished()) HandleThrow(player);
            player.EndThrow();

            newMatch.UpdatePlayer(player!);

            //write the name and the score of the current player
            AnsiConsole.MarkupLine($"[green]Player: - {player.Name} - Score: {player.RequiredBoardNumber}[/]");
            AnsiConsole.MarkupLine("[green]--------------------------------[/]");
        }
    }

    AnsiConsole.MarkupLine($"[red]Winner: {newMatch.Players.FirstOrDefault(d => d.Finished()).Name}[/]");
}

return;

static void HandleThrow(MatchPlayer matchPlayer)
{
    var regexString = "^(1[0-9]|20|[1-9])(S|D|T)$|^(25|50)$";
    var regEx = new Regex(regexString);
    
    // ask for inputs 1-20, outerbull or bullseye
    var dartThrow = AnsiConsole.Ask<string>($"[yellow]Enter the throw: 1-20 and S,D or T or 25 or 50 score:[/]");
    var regExMatch = regEx.Match(dartThrow);
    
    // if the throw is not between 1 and 20 throw an error
    do
    {
        if (regExMatch.Success) continue;
        dartThrow = AnsiConsole.Ask<string>("[red]Enter the throw: 1-20 and S,D or T or 25 or 50 score:[/]");
        regExMatch = regEx.Match(dartThrow);
    } while (!regExMatch.Success);
    
    matchPlayer.Throw(dartThrow);
    
    var currentUser = matchPlayer as RoundTheBoardPlayer;
    
    AnsiConsole.MarkupLine($"[green]Current Score: {currentUser.RequiredBoardNumber}[/]");
}

static Type[] GetAndDisplayMatchTypes()
{
    // get a list of types from the DartScorer.Main and write them to the screen
    var types = Assembly.GetAssembly(typeof(CommonMatch))?.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CommonMatch)))
        .ToList()
        .OrderBy(x => x.Name)
        .ToList();

    var matchTuple = new List<(int index, string Name)>();

    // write the name of the class that inherits CommonMatch to screen
    if (types != null)
        for (var i = 0; i < types.Count; i++)
        {
            var match = (CommonMatch)Activator.CreateInstance(types[i]);
            matchTuple.Add((i, match.Name));
        }

    AnsiConsole.MarkupLine("[yellow]Pick your game[/]");

    // list out the tuple values
    var table = new Table
    {
        BorderStyle = new Style(Color.Purple)
    };
    table.AddColumn("Index");
    table.AddColumn("Match Name");

    foreach (var (index, Name) in matchTuple)
    {
        table.AddRow(index.ToString(), Name);
    }

    AnsiConsole.Write(table);
    
    return types.ToArray();
}
