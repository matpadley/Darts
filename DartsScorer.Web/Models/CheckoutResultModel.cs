using DartsScorer.Main.Scoring;

namespace DartsScorer.Web.Models;

public class CheckoutResultModel
{
    public int Score { get; set; }
    public ThrowScore[] Results { get; set; }
}