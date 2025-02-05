using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;

namespace DartsScorer.Tests.Player;

public class PlayerTests
{
    [Test]
    public void Player_Instantiation()
    {
        var player = new Main.Player.Player("John");
        Assert.That(player.Name, Is.EqualTo("John"));
    }

    [Test]
    public void Player_Instantiation_Fail()
    {
        var player = new Main.Player.Player("John");
        Assert.That(player.Name, !Is.EqualTo("Steven"));
    }

    [Test]
    public void Player_String_Throw_Success()
    {
        var player = new RoundTheBoardPlayer("John");

        var match = new DartsScorer.Main.Match.RoundTheBoard.Match();
        match.AddPlayer(player);
        match.StartMatch();
        
        var matchPlayer = (match.CurrentPlayer as RoundTheBoardPlayer);
            
        matchPlayer.StartThrow();
        matchPlayer.Throw("1S");
        matchPlayer.Throw("1S");
        matchPlayer.Throw("2S");
        matchPlayer.EndThrow();
        
        Assert.That(matchPlayer.Legs.Count, Is.EqualTo(1));
        Assert.That(matchPlayer.RequiredBoardNumber, Is.EqualTo(3));
    }
}