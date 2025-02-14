using DartsScorer.Main.Scoring;

namespace DartsScore.RoundTheBoard.TestCases;

internal class ThrowCase
{
    // add a new initialise a Tuple for BoardScore and Multiplier
    // Use named tuples for BoardScore and Multiplier
    public (BoardScore BoardScore, Multiplier Multiplier) FirstThrow { get; set; }
    public (BoardScore BoardScore, Multiplier Multiplier) SecondThrow { get; set; }
    public (BoardScore BoardScore, Multiplier Multiplier) ThirdThrow { get; set; }
}