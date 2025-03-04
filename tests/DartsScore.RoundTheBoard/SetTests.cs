namespace DartsScore.RoundTheBoard;

public class SetTests
{
    [Test]
    public void Set_Has_not_Been_Won()
    {
        var set = new Set(4);
        
        Assert.That(set.Legs.Length, Is.EqualTo(4));
        Assert.That(set.Id, Is.Not.EqualTo(Guid.Empty));
    }
}

public class Set(int numberOfLegs)
{
    public Guid Id { get; } = Guid.NewGuid();

    public MatchLeg[] Legs { get; } = new MatchLeg[numberOfLegs];

    public Guid WinnerId { get; private set; }
    
    public Set SetWinner(Guid winnerId)
    {
        WinnerId = winnerId;
        return this;
    }
}

public class MatchLeg
{
    public Guid Id { get; set; }

    public Guid WinnerPLayerId { get; set; }
    
    public MatchLeg SetWinner(Guid winnerPLayerId)
    {
        WinnerPLayerId = winnerPLayerId;
        return this;
    }
}