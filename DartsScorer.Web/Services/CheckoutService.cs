using DartsScorer.Main.Checkout;
using DartsScorer.Web.Models;

namespace DartsScorer.Web.Services;

public class CheckoutService : ICheckoutService
{
    private readonly CheckoutCalculator _checkoutCalculator;

    public CheckoutService()
    {
        _checkoutCalculator = new CheckoutCalculator();
    }

    public CheckoutResultModel GetCheckoutResult(int score)
    {
        var results = _checkoutCalculator.Calculate(score);
        return new CheckoutResultModel
        {
            Score = score,
            Results = results
        };
    }
}