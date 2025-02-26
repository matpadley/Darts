using System.Text.RegularExpressions;
using DartsScorer.Main.Match;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Player;

public abstract class MatchPlayer(Player player) : Player(player.Name)
{  
    public Leg? CurrentLeg;

    public bool HasWon { get; set; }
    
    public abstract bool Finished();

    public abstract void UpdateRequiredBoardNumber(ThrowScore newThrow);
    
    public ICollection<Leg?> Legs { get; set; } = new List<Leg?>();

    public IOrderedEnumerable<Leg?> OrderedDescendingLegs()
    {
        return Legs.OrderByDescending(leg => leg!.CreationDate.Ticks);
    }
    public void EndThrow()
    {
        if (CurrentLeg != null)
        {
            Legs.Add(CurrentLeg);
        }
        CurrentLeg = null;
    }
    
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