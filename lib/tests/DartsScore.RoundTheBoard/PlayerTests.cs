using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;

namespace DartsScore.RoundTheBoard;

public class PlayerTests
{
    [Test]
    public void RoundTheBoard_Can_Create_Player()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 1));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo( 0));
    }

    [Test]
    public void RoundTheBoard_Can_Add_Player()
    {
        var roundTheBoard = new Match();

        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoard.AddPlayer(roundTheBoardPlayer);
        
        Assert.That(roundTheBoard.Players.Count, Is.EqualTo(1));
    }

    [Test]
    public void Player_Equality_Tests()
    {
        var player1 = new Player("myName");
        var player2 = new Player("myName");

        
        Assert.That(player1.Equals(player2));
    }
}