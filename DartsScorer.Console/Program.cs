using System.Reflection;
using DartsScorer.Main.Match;
using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;
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

foreach (var se in newMatch.Players.ToList().Select(f => f.Name))
{
    AnsiConsole.MarkupLine($"Player: [underline]{se}[/]");
}

// add an option to sytart the game if a player has been added to the match
if (newMatch.Players.Count > 0)
{
    var start = AnsiConsole.Confirm("Do you want to start the game?");
    if (start)
    {
        // run match start method
        newMatch.StartMatch();
        AnsiConsole.MarkupLine("Game Started");
        
        // get the match player type dependeing on the match type
        //var matchPlayer = newMatch.Players[0] switch
        //{
        //    RoundTheBoardPlayer => new RoundTheBoardPlayer(newMatch.Players[0].Name),
        //    _ => throw new InvalidOperationException("Match type not found")
        //};
        
        while (newMatch.Players.Count(d => d.Finished()) == 0)
        {
            foreach (var matchPlayer in newMatch.Players)
            {
                // write the name of the current player to the screen in green
                var roundTheBoardPlayer = matchPlayer as RoundTheBoardPlayer;
                
                AnsiConsole.MarkupLine($"[red]Current Player: {matchPlayer.Name}S core: {roundTheBoardPlayer.RequiredBoardNumber}[/]");
                // write a line under the above line
                AnsiConsole.MarkupLine("[red]--------------------------------[/]");
                
                if (!newMatch.IsMatchComplete)
                {
                    roundTheBoardPlayer.StartThrow();
                    HandleThrow(roundTheBoardPlayer);
                    HandleThrow(roundTheBoardPlayer);
                    HandleThrow(roundTheBoardPlayer);
                    roundTheBoardPlayer.EndThrow();
                }
                newMatch.UpdatePlayer(roundTheBoardPlayer);
                
                //write the name and the score of the current player
                AnsiConsole.MarkupLine($"[green]Player: {roundTheBoardPlayer.Name} Score: {roundTheBoardPlayer.RequiredBoardNumber}[/]");
                
            }
        }
    }
    
    // write out the name of the winner of the match in red
    AnsiConsole.MarkupLine($"[red]Winner: {newMatch.Players.FirstOrDefault(d => d.Finished()).Name}[/]");
}

return;

static void HandleThrow(MatchPlayer matchPlayer)
{
    // ask for inputs 1-20, outerbull or bullseye
    var dartThrow = AnsiConsole.Ask<int>("Enter the throw (1-20) score: ");

    // if the throw is not between 1 and 20 throw an error
    do
    {
        if (dartThrow < 1 || dartThrow > 20)
        {
            dartThrow = AnsiConsole.Ask<int>("[red]Throw must be between 1 and 20[/]");
        }
    } while (dartThrow < 1 || dartThrow > 20);

    // convert the input to the board score enum
    var boardScore1 = dartThrow switch
    {
        1 => BoardScore.One,
        2 => BoardScore.Two,
        3 => BoardScore.Three,
        4 => BoardScore.Four,
        5 => BoardScore.Five,
        6 => BoardScore.Six,
        7 => BoardScore.Seven,
        8 => BoardScore.Eight,
        9 => BoardScore.Nine,
        10 => BoardScore.Ten,
        11 => BoardScore.Eleven,
        12 => BoardScore.Twelve,
        13 => BoardScore.Thirteen,
        14 => BoardScore.Fourteen,
        15 => BoardScore.Fifteen,
        16 => BoardScore.Sixteen,
        17 => BoardScore.Seventeen,
        18 => BoardScore.Eighteen,
        19 => BoardScore.Nineteen,
        20 => BoardScore.Twenty,
        _ => throw new InvalidOperationException("Board score not found")
    };

    // get the multiplier from the input, single, double, triple
    /*
    var multiplier1 = AnsiConsole.Ask<int>("Enter the multiplier: ");
    // add a table with the multiplier options
    var table1 = new Table();
    table1.AddColumn("Index");
    table1.AddColumn("Multiplier");
    table1.AddRow("1", "Single");
    table1.AddRow("2", "Double");
    table1.AddRow("3", "Triple");
    AnsiConsole.Render(table1);

    // convert the input to the multiplier enum

    var multiplier = multiplier1 switch
    {
        1 => Multiplier.Single,
        2 => Multiplier.Double,
        3 => Multiplier.Triple,
        _ => throw new InvalidOperationException("Multiplier not found")
    };*/

    matchPlayer.Throw(boardScore1, Multiplier.Single);
    
    var currentUser = matchPlayer as RoundTheBoardPlayer;
    
    // write to the screen in green the current score of the user
    AnsiConsole.MarkupLine($"[green]Current Score: {currentUser.RequiredBoardNumber}[/]");
}// get three throws from the user

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
    var table = new Table();
    table.BorderStyle = new Style(Color.Purple);
    table.AddColumn("Index");
    table.AddColumn("Match Name");

    foreach (var (index, Name) in matchTuple)
    {
        table.AddRow(index.ToString(), Name);
    }

    AnsiConsole.Write(table);
    
    return types.ToArray();
}
