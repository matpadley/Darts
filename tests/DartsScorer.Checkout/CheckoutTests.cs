using DartsScorer.Main.Checkout;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Checkout;

public class CheckoutTests
{
    [Test]
    public void Checkout_Basic()
    {
        const int inputScore = 170;

        var newCalc = new CheckoutCalculator();

        var first = new ThrowScore(Multiplier.Treble, BoardScore.Twenty);
        var second = new ThrowScore(Multiplier.Treble, BoardScore.Twenty);
        var third = new ThrowScore(Multiplier.Single, BoardScore.BullsEye);

        var result = newCalc.Calculate(inputScore);

        Assert.Multiple(() =>
        {
            Assert.That(result[0].BoardScore, Is.EqualTo(first.BoardScore));
            Assert.That(result[0].Multiplier, Is.EqualTo(first.Multiplier));
            Assert.That(result[1].BoardScore, Is.EqualTo(second.BoardScore));
            Assert.That(result[1].Multiplier, Is.EqualTo(second.Multiplier));
            Assert.That(result[2].BoardScore, Is.EqualTo(third.BoardScore));
            Assert.That(result[2].Multiplier, Is.EqualTo(third.Multiplier));
        });
    }
    
    [Test]
    public void Checkout_Should_Return_Empty_Array()
    {
        const int inputScore = 501;

        var newCalc = new CheckoutCalculator();

        var result = newCalc.Calculate(inputScore);

        Assert.That(result.Length, Is.EqualTo(0));
    }
}