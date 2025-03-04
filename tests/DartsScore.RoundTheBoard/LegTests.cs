using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Scoring;

namespace DartsScore.RoundTheBoard;

public class LegTests
{
    [Test]
    public void RoundTheBoard_Leg_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
       // roundTheBoardPlayer.StartThrow();
        
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(0));
    }

    [Test]
    public void RoundTheBoard_Player_Basic_Score_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        //roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.EndThrow();
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 2));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(1));
    }

    [Test]
    public void RoundTheBoard_Player_Score_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
       // roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.EndThrow();
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 4));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(1));
    }

    [Test]
    public void RoundTheBoard_Player_Multi_Leg_Score_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.EndThrow();
        
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.EndThrow();
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 4));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(2));
    }

    [Test]
    public void RoundTheBoard_Player_Mid_Leg_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 3));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(0));
    }

    [Test]
    public void RoundTheBoard_Player_Leg_Missed_Last_ThrowTest()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Seven, Multiplier.Single);
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 3));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(1));
    }

    [Test]
    public void RoundTheBoard_Leg_Order_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Seven, Multiplier.Single);
        
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Six, Multiplier.Single);
        
        Assert
            .That(roundTheBoardPlayer.Legs.Last().CreationDate, 
                Is.GreaterThan(roundTheBoardPlayer.Legs.First().CreationDate));
    }
}