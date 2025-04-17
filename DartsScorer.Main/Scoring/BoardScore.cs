namespace DartsScorer.Main.Scoring;

/// <summary>
/// Represents the possible scores on a dartboard.
/// Each value corresponds to the basic point value of a section on the dartboard before multipliers are applied.
/// </summary>
public enum BoardScore
{
    /// <summary>The number 1 section on the dartboard.</summary>
    One = 1,
    
    /// <summary>The number 2 section on the dartboard.</summary>
    Two = 2,
    
    /// <summary>The number 3 section on the dartboard.</summary>
    Three = 3,
    
    /// <summary>The number 4 section on the dartboard.</summary>
    Four = 4,
    
    /// <summary>The number 5 section on the dartboard.</summary>
    Five = 5,
    
    /// <summary>The number 6 section on the dartboard.</summary>
    Six = 6,
    
    /// <summary>The number 7 section on the dartboard.</summary>
    Seven = 7,
    
    /// <summary>The number 8 section on the dartboard.</summary>
    Eight = 8,
    
    /// <summary>The number 9 section on the dartboard.</summary>
    Nine = 9,
    
    /// <summary>The number 10 section on the dartboard.</summary>
    Ten = 10,
    
    /// <summary>The number 11 section on the dartboard.</summary>
    Eleven = 11,
    
    /// <summary>The number 12 section on the dartboard.</summary>
    Twelve = 12,
    
    /// <summary>The number 13 section on the dartboard.</summary>
    Thirteen = 13,
    
    /// <summary>The number 14 section on the dartboard.</summary>
    Fourteen = 14,
    
    /// <summary>The number 15 section on the dartboard.</summary>
    Fifteen = 15,
    
    /// <summary>The number 16 section on the dartboard.</summary>
    Sixteen = 16,
    
    /// <summary>The number 17 section on the dartboard.</summary>
    Seventeen = 17,
    
    /// <summary>The number 18 section on the dartboard.</summary>
    Eighteen = 18,
    
    /// <summary>The number 19 section on the dartboard.</summary>
    Nineteen = 19,
    
    /// <summary>The number 20 section on the dartboard.</summary>
    Twenty = 20,
    
    /// <summary>The outer bull (or single bull) section, worth 25 points.</summary>
    OuterBull = 25,
    
    /// <summary>The bullseye (or double bull) section, worth 50 points.</summary>
    BullsEye = 50,
    
    /// <summary>Represents a miss or a throw that scored no points.</summary>
    Zero = 0
}
