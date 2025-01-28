using DartsScorer.Main.Scoring;

namespace DartsScore.RoundTheBoard.TestCases;

internal class ThrowCase
{
    //add a new initialise a Tuple for BoardScore and Multiplier
    public Tuple<BoardScore, Multiplier> FirstThrow { get; set; }
    public Tuple<BoardScore, Multiplier> SecondThrow { get; set; }
    public Tuple<BoardScore, Multiplier> ThirdThrow { get; set; }
}