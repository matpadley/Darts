using System.Text.RegularExpressions;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Player;

public abstract class MatchPlayer(Player player) : Player(player.Name)
{
    public abstract void StartThrow();
    public abstract void Throw(BoardScore one, Multiplier multiplier);
    public abstract void EndThrow();
    public abstract bool Finished();
    public void Throw(string dartThrow)
    {
        if (dartThrow == "25" || dartThrow == "50")
        {
            Throw(dartThrow == "25" ? BoardScore.OuterBull : BoardScore.BullsEye, Multiplier.Single);
            return;
        }
        
        var regexString = "^(S|D|T)(1[0-9]|20|[1-9])$|^(25|50)$";
        var regEx = new Regex(regexString);
        
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
            _ => throw new InvalidOperationException("Board score not found")
        };
    
        // convert the input to the multiplier enum

        var boardMultiplier = multiplier switch
        {
            "S" => Multiplier.Single,
            "D" => Multiplier.Double,
            "T" => Multiplier.Triple,
            _ => throw new InvalidOperationException("Multiplier not found")
        };
        
        Throw(boardScore, boardMultiplier);
    }
}