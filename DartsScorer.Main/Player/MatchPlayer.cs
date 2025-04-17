using System.Text.RegularExpressions;
using DartsScorer.Main.Exceptions;
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
        if (string.IsNullOrWhiteSpace(dartThrow))
        {
            throw new InvalidThrowException("Throw cannot be empty");
        }
        
        if (int.TryParse(dartThrow, out _)) dartThrow = "S" + dartThrow;
        
        if (dartThrow == "S25" || dartThrow == "S50")
        {
            Throw(dartThrow == "S25" ? BoardScore.OuterBull : BoardScore.BullsEye, Multiplier.Single);
            return;
        }
        
        var regEx = new Regex("^(S|D|T)(1[0-9]|[0-9]|20|25|50)$");
        
        var regExMatch = regEx.Match(dartThrow);
        
        if (!regExMatch.Success)
        {
            throw new InvalidThrowException($"Invalid throw format: {dartThrow}. Expected format is 'S1' to 'S20', 'D1' to 'D20', 'T1' to 'T20', 'S25' or 'S50'.");
        }
    
        // Parse the score and multiplier components
        var scoreString = regExMatch.Groups[2].Value;
        var multiplierString = regExMatch.Groups[1].Value;
        
        if (!int.TryParse(scoreString, out var score))
        {
            throw new InvalidThrowException($"Invalid score: {scoreString}");
        }
        
        // Check valid score range
        if (score < 0 || score > 20 && score != 25 && score != 50)
        {
            throw new InvalidThrowException($"Score must be between 1 and 20, or 25 or 50, got: {score}");
        }
    
        // Convert the input to the board score enum
        BoardScore boardScore;
        try 
        {
            boardScore = score switch
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
                _ => throw new InvalidThrowException($"Invalid board score: {score}")
            };
        }
        catch (InvalidThrowException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InvalidThrowException($"Error processing board score: {score}", ex);
        }
    
        // convert the input to the multiplier enum
        Multiplier boardMultiplier;
        try
        {
            boardMultiplier = multiplierString switch
            {
                "S" => Multiplier.Single,
                "D" => Multiplier.Double,
                "T" => Multiplier.Treble,
                _ => throw new InvalidThrowException($"Invalid multiplier: {multiplierString}")
            };
        }
        catch (InvalidThrowException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InvalidThrowException($"Error processing multiplier: {multiplierString}", ex);
        }
        
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
        
        try
        {
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
                default:
                    throw new InvalidOperationException($"Invalid throw number: {CurrentLeg?.NextThrow}");
            }
        }
        catch (Exception ex) when (ex is not DartsScorerException)
        {
            throw new InvalidThrowException("Error processing throw", ex);
        }
    }
}