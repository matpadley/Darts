using DartsScorer.Main.Match;
using DartsScorer.Main.Match.x01;
using DartsScorer.Main.Scoring;

namespace DartsScorer.x01;

public class CheckoutTests
{
    
    [Test]
    public void X01_Single_PLayer_Run_To_End()
    {
        var match = new Match(new MatchConfiguration(), 1);
        var player = new X01Player("p1", match.RequiredScore);
        match.AddPlayer(player);
        match.StartMatch();
        var currentPlayer = match.CurrentPlayer as X01Player;
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(101));
            Assert.That(currentPlayer.Checkout().Length, Is.EqualTo(3));
        });

        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Treble);
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(41));
            Assert.That(currentPlayer.Checkout().Length, Is.EqualTo(2));
        });

        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Treble);
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(41));
            Assert.That(currentPlayer.Checkout().Length, Is.EqualTo(2));
        });

        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Double);
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(1));
            Assert.That(currentPlayer.Checkout().Length, Is.EqualTo(0));
        });

        currentPlayer.Throw(BoardScore.Twenty, Multiplier.Double);
        Assert.Multiple(() =>
        {
            Assert.That(currentPlayer.RemainingScore, Is.EqualTo(1));
            Assert.That(currentPlayer.Checkout().Length, Is.EqualTo(0));
        });

        currentPlayer.Throw(BoardScore.One, Multiplier.Single);
        
        Assert.That(currentPlayer.Finished(), Is.True);
    }
}