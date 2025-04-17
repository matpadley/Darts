using System.Text.RegularExpressions;
using DartsScorer.Main.Match;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Player;

/// <summary>
/// Represents a player participating in a match.
/// </summary>
public abstract class MatchPlayer(Player player) : Player(player.Name)
{  
    /// <summary>
    /// Gets or sets the current leg of the match for the player.
    /// </summary>
    public Leg? CurrentLeg;

    /// <summary>
    /// Gets or sets a value indicating whether the player has won the match.
    /// </summary>
    public bool HasWon { get; set; }
    
    /// <summary>
    /// Determines whether the player has finished the match.
    /// </summary>
    /// <returns>True if the player has finished; otherwise, false.</returns>
    public abstract bool Finished();

    /// <summary>
    /// Updates the required board number based on the new throw.
    /// </summary>
    /// <param name="newThrow">The new throw score.</param>
    public abstract void UpdateRequiredBoardNumber(ThrowScore newThrow);
    
    /// <summary>
    /// Gets or sets the collection of legs played by the player.
    /// </summary>
    public ICollection<Leg?> Legs { get; set; } = new List<Leg?>();

    /// <summary>
    /// Returns the legs ordered by creation date in descending order.
    /// </summary>
    /// <returns>An ordered enumerable of legs.</returns>
    public IOrderedEnumerable<Leg?> OrderedDescendingLegs()
    {
        return Legs.OrderByDescending(leg => leg!.CreationDate.Ticks);
    }

    /// <summary>
    /// Ends the current throw and adds the current leg to the collection of legs.
    /// </summary>
    public void EndThrow()
    {
        if (CurrentLeg != null)
        {
            Legs.Add(CurrentLeg);
        }
        CurrentLeg = null;
    }
    
    /// <summary>
    /// Processes a dart throw based on the input string.
    /// </summary>
    /// <param name="dartThrow">The string representation of the dart throw.</param>
    public void Throw(string dartThrow)
    {
        if (int.TryParse(dartThrow, out _)) dartThrow = "S" + dartThrow;
        
        if (dartThrow == "S25" || dartThrow == "S50")
        {
            Throw(dartThrow == "S25" ? BoardScore.OuterBull : BoardScore.BullsEye, Multiplier.Single);
            return;
        }
        
        var regEx = new Regex("^(S|D|T)(1[0-9]|[0-9]|20|25|50)$");
        
        var regExMatch = regEx.Match(dartThrow);
    
        // if the throw is not 25 or 50 split the string and get the board score
        var score = int.Parse(regExMatch.Groups[2].Value);
        
        var multiplier = regExMatch.Groups[1].Value;
    
        // convert the input to the board score enum
        var boardScore = score switch
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
            0 => BoardScore.Zero,
            _ => throw new InvalidOperationException("Board score not found")
        };
    
        // convert the input to the multiplier enum

        var boardMultiplier = multiplier switch
        {
            "S" => Multiplier.Single,
            "D" => Multiplier.Double,
            "T" => Multiplier.Treble,
            _ => throw new InvalidOperationException("Multiplier not found")
        };
        
        Throw(boardScore, boardMultiplier);
    }
    
    /// <summary>
    /// Processes a dart throw based on the board score and multiplier.
    /// </summary>
    /// <param name="boardScore">The board score of the throw.</param>
    /// <param name="multiplier">The multiplier of the throw.</param>
    public void Throw(BoardScore boardScore, Multiplier multiplier)
    {
        if (HasWon)
        {
            EndThrow();
            return;
        }
        
        var newThrow = new ThrowScore(multiplier, boardScore);
        
        CurrentLeg ??= new Leg();
        
        switch (CurrentLeg?.NextThrow)
        {
            case 1:
                CurrentLeg.ThrowFirst(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                if (HasWon) EndThrow();
                break;
            case 2:
                CurrentLeg.ThrowSecond(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                if (HasWon) EndThrow();
                break;
            case 3:
                CurrentLeg.ThrowThird(newThrow);
                UpdateRequiredBoardNumber(newThrow);
                EndThrow(); 
                break;
        }
    }
}