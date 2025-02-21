using System.Text.RegularExpressions;
using DartsScorer.Main.Functions;
using DartsScorer.Main.Match;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Player;

public abstract class MatchPlayer(Player player) : Player(player.Name)
{   
    private readonly DartThrowConverter _converter = new();

    public ICollection<Leg?> Legs { get; set; } = new List<Leg?>();
    
   // public abstract void StartThrow();
    public abstract void Throw(BoardScore one, Multiplier multiplier);
    public abstract void EndThrow();
    public abstract bool Finished();
    protected internal bool HasFinishedLeg { get; set; } = false;

    public Leg? CurrentLeg;
    public void Throw(string dartThrow)
    {
        var (boardScore, boardMultiplier) = _converter.Convert(dartThrow);
        Throw(boardScore, boardMultiplier);
    }
}