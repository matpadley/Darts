using DartsScorer.Main.Checkout;
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

        var newCalc = new CheckoutCalculator();

        var first = new ThrowScore(Multiplier.Triple, BoardScore.Twenty);
        var second = new ThrowScore(Multiplier.Triple, BoardScore.Twenty);
        var third = new ThrowScore(Multiplier.Double, BoardScore.Eighteen);

        var result = newCalc.Calculate(inputScore);

        Assert.That(result[0].BoardScore, Is.EqualTo(first.BoardScore));
        Assert.That(result[0].Multiplier, Is.EqualTo(first.Multiplier));
        Assert.That(result[1].BoardScore, Is.EqualTo(second.BoardScore));
        Assert.That(result[1].Multiplier, Is.EqualTo(second.Multiplier));
        Assert.That(result[2].BoardScore, Is.EqualTo(third.BoardScore));
        Assert.That(result[2].Multiplier, Is.EqualTo(third.Multiplier));
    }

    [Test]
    public void Checkout_CheckData_Valus()
    {
        var data = new CheckoutData();

        foreach (var checkout in data.Scores)
        {
            if (checkout.Key != checkout.Value.Sum(f => f.Score))
            {
                int i = 0;
            }
            
            Assert.That(checkout.Key, 
                Is.EqualTo(checkout.Value.Sum(f => f.Score)));
        }
    }
}