using DartsScorer.Main.Scoring;

namespace DartsScorer.Web.Views.Checkout;

public class CheckoutResultModel
{
    public int Score { get; set; }
    public ThrowScore[] Results { get; set; }
}