using DartsScorer.Web.Models;

namespace DartsScorer.Web.Services;

public interface ICheckoutService
{
    CheckoutResultModel GetCheckoutResult(int score);
}