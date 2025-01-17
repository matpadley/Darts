using DartsScorer.Main.Match;
using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Scoring;

namespace DartsScore.RoundTheBoard;

public class RoundTheBoardTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RoundTheBoard_Instantiate()
    {
        var roundTheBoard = new Match();
        
        Assert.That(roundTheBoard.DartsMatchType, Is.EqualTo(DartsMatchType.RoundTheBoard));
    }
    
    [Test]
    public void RoundTheBoard_Instantiate_Failure()
    {
        var roundTheBoard = new Match();
        
        Assert.That(roundTheBoard.DartsMatchType, !Is.EqualTo(DartsMatchType.X01));
        Assert.That(roundTheBoard.Players.Count, Is.EqualTo(0));
    }

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
    public void RoundTheBoard_Leg_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.StartThrow();
        
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void RoundTheBoard_Player_Basic_Score_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 2));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void RoundTheBoard_Player_Score_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 4));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(1));
    }    
    
    [Test]
    public void RoundTheBoard_Player_Multi_Leg_Score_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        
        roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Three, Multiplier.Single);
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 4));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(2));
    }   
    
    [Test]
    public void RoundTheBoard_Player_Mid_Leg_Test()
    {
        var roundTheBoardPlayer = new RoundTheBoardPlayer("Fancy New Player Name");
        
        roundTheBoardPlayer.StartThrow();
        roundTheBoardPlayer.Throw(BoardScore.One, Multiplier.Single);
        roundTheBoardPlayer.Throw(BoardScore.Two, Multiplier.Single);
        
        Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo( 3));
        Assert.That(roundTheBoardPlayer.Legs.Count, Is.EqualTo(0));
    }
}
