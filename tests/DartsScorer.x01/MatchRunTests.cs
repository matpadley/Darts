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
        _match = new Match(new MatchConfiguration());
        _match.AddPlayer(new X01Player("playerOne", _match.RequiredScore));
        _match.AddPlayer(new X01Player("playerTwo", _match.RequiredScore));
        _match.StartMatch();
    }
    [Test]
    
    public void RoundTheBoard_Configuration()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_match.Configuration.NumberOfLegs, Is.EqualTo(1));
            Assert.That(_match.Configuration.NumberOfSets, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void X01_Single_Throw()
    {
        var currentPlayer = _match.CurrentPlayer as X01Player;
        
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(456));
            Assert.That(currentPlayer.HasWon, Is.False);
            Assert.That(_match.IsMatchComplete, Is.False);
        });
    }

    [Test]
    public void X01_Multiple_Throws()
    {
        var currentPlayer = _match.CurrentPlayer as X01Player;
        
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        
        Assert.That(currentPlayer.Legs.Count, Is.EqualTo(2));
    }

    [Test]
    public void X01_Multiple_Player_Single_Let()
    {
        _match.StartMatch();
        var currentPlayer = _match.CurrentPlayer as X01Player;
        Assert.That(currentPlayer.Name, Is.EqualTo("playerOne"));
        
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        currentPlayer.Throw(BoardScore.Fifteen, Multiplier.Treble);
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(366));
            Assert.That(currentPlayer.Legs.Count, Is.EqualTo(1));
        });

        _match.UpdatePlayer(currentPlayer);
        
        currentPlayer = _match.CurrentPlayer as X01Player;
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.Name, Is.EqualTo("playerTwo"));
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(501));
        });
    }

    [Test]
    public void X01_Single_PLayer_Run_To_End()
    {
        var match = new Match(new MatchConfiguration(), 1);
        var player = new X01Player("p1", match.RequiredScore);
        match.AddPlayer(player);
        match.StartMatch();
        var currentPlayer = match.CurrentPlayer as X01Player;
        
        Assert.That(currentPlayer.RemainingScore, Is.EqualTo(101));
        
        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Treble);
        
        Assert.That(currentPlayer.RemainingScore, Is.EqualTo(41));
        
        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Treble);
        
        Assert.That(currentPlayer.RemainingScore, Is.EqualTo(41));
        
        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Double);
        
        Assert.That(currentPlayer.RemainingScore, Is.EqualTo(1));
        
        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Double);
        
        Assert.That(currentPlayer.RemainingScore, Is.EqualTo(1));
        
        currentPlayer.Throw(BoardScore.One, Multiplier.Single);
        
        Assert.That(currentPlayer.Finished(), Is.True);
    }
}