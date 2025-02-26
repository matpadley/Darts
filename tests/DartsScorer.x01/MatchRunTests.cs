using DartsScorer.Main.Match;
using DartsScorer.Main.Match.x01;
using DartsScorer.Main.Scoring;

namespace DartsScorer.x01;

public class MatchRunTests
{
    private Match _match;
    
    [SetUp]
    public void Setup()
    {
        _match = new Match();
        _match.AddPlayer(new X01Player("name", _match.RequiredScore));
        _match.StartMatch();
    }
    
    [Test]
    public void X01_SingleThrow()
    {
        var currentPlayer = _match.CurrentPlayer as X01Player;
        
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        
        Assert.That(currentPlayer.CurrentScore, Is.EqualTo(456));
        Assert.That(currentPlayer.HasWon, Is.False);
        Assert.That(_match.IsMatchComplete, Is.False);
    }
}