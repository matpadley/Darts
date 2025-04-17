namespace DartsScorer.Main.Match;

/// <summary>
/// Defines the available types of dart matches supported by the application.
/// </summary>
public enum DartsMatchType
{
    /// <summary>
    /// No specific match type selected.
    /// </summary>
    None,
    
    /// <summary>
    /// The X01 game variant (301, 501, etc.) where players start with a score and aim to reduce it to zero.
    /// </summary>
    X01,
    
    /// <summary>
    /// The Killer game variant where players attempt to "kill" their opponents by hitting their assigned numbers.
    /// </summary>
    Killer,
    
    /// <summary>
    /// The Round The Board (Around the Clock) game variant where players aim to hit numbers in sequence from 1 to 20.
    /// </summary>
    RoundTheBoard
}