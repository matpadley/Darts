using DartsScorer.Main.Scoring;

namespace DartsScorer.Checkout;

public class CheckoutTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var inputScore = 170;

        var newCalc = new CheckoutCalc();
        
        var first = new ThrowScore(Multiplier.Triple, BoardScore.Twenty);
        var second = new ThrowScore(Multiplier.Triple, BoardScore.Twenty);
        var third = new ThrowScore(Multiplier.Double, BoardScore.Eighteen);

        var result = newCalc.Calculate(inputScore);

        Assert.That(result[0], Is.EqualTo(first));
        Assert.That(result[1], Is.EqualTo(second));
        Assert.That(result[2], Is.EqualTo(third));
    }
}

public class CheckoutCalc
{
    public ThrowScore[] Calculate(int inputScore)
    {
        throw new NotImplementedException();
    }
}