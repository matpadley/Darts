using DartsScorer.Main.Match.x01;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Match = DartsScorer.Main.Match.x01.Match;

namespace DartsScorer.x01;

public class PlayerTests
{
    [Test]
    public void X01_Can_Create_Player()
    {
        var x01Player = new X01Player("Fancy New Player Name", 501);
        Assert.That(x01Player.WinningNumber, Is.EqualTo( 501));
        Assert.That(x01Player.Legs.Count, Is.EqualTo( 0));
    }

    [Test]
    public void X01_Can_Add_Player()
    {
        var x01Match = new Match();

        x01Match.AddPlayer(new X01Player("Fancy New Player Name", 501));
        
        Assert.That(x01Match.Players.Count, Is.EqualTo(1));
    }

    [Test]
    public void X01_Match_Can_Get_Current_Player()
    {
        var x01Match = new Match();

        var player = new X01Player("Fancy New Player Name", 501);

        x01Match.AddPlayer(player);
        x01Match.StartMatch();
        
        Assert.That(x01Match.CurrentPlayer, Is.Not.Null);
        Assert.That(x01Match.CurrentPlayer, Is.EqualTo(player));
    }
}