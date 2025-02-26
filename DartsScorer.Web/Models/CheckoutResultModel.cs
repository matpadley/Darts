using DartsScorer.Main.Scoring;

namespace DartsScorer.Web.Models;

public class CheckoutResultModel
{
    public int Score { get; set; }
    public required ThrowScore[] Results { get; set; }
}