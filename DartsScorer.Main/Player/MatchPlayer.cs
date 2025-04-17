using System.Text.RegularExpressions;
using DartsScorer.Main.Exceptions;
using DartsScorer.Main.Match;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Player;

/// <summary>
/// Represents a player participating in a darts match.
/// This abstract class provides common functionality for different types of match players
/// and must be extended by game-specific player implementations.
/// </summary>
/// <param name="player">The base player information</param>
public abstract class MatchPlayer(Player player) : Player(player.Name)
{  
    /// <summary>
    /// Gets or sets the current leg being played by this player.
    /// </summary>
    public Leg? CurrentLeg;

    /// <summary>
    /// Gets or sets a value indicating whether this player has won the match.
    /// </summary>
    public bool HasWon { get; set; }
    
    /// <summary>
    /// Determines whether this player has finished the match according to game-specific rules.
    /// </summary>
    /// <returns>true if the player has finished the match; otherwise, false</returns>
    public abstract bool Finished();

    /// <summary>
    /// Updates the player's required board number based on the latest throw.
    /// Game-specific implementations determine how the score affects the player's progress.
    /// </summary>
    /// <param name="newThrow">The latest throw made by the player</param>
    public abstract void UpdateRequiredBoardNumber(ThrowScore newThrow);
    
    /// <summary>
    /// Gets or sets the collection of completed legs for this player.
    /// </summary>
    public ICollection<Leg?> Legs { get; set; } = new List<Leg?>();

    /// <summary>
    /// Gets the player's legs ordered by creation date in descending order (newest first).
    /// </summary>
    /// <returns>An ordered collection of the player's legs</returns>
    public IOrderedEnumerable<Leg?> OrderedDescendingLegs()
    {
        return Legs.OrderByDescending(leg => leg!.CreationDate.Ticks);
    }

    /// <summary>
    /// Ends the current throw sequence, adding the current leg to the player's leg history.
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
    /// Records a throw using standard dart notation (e.g., "S20" for single 20, "D16" for double 16).
    /// Parses the notation and calls the appropriate method with the corresponding board score and multiplier.
    /// </summary>
    /// <param name="dartThrow">A string representing the dart throw in standard notation</param>
    /// <exception cref="InvalidThrowException">Thrown when the throw notation is invalid</exception>
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
    
    /// <summary>
    /// Records a throw with the specified board score and multiplier.
    /// Updates the current leg and the player's progress in the game.
    /// </summary>
    /// <param name="boardScore">The board score (1-20, BullsEye, etc.)</param>
    /// <param name="multiplier">The multiplier (Single, Double, Treble)</param>
    /// <exception cref="InvalidThrowException">Thrown when there is an error processing the throw</exception>
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