using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Checkout
{
    public class CheckoutCalculator
    {
        private readonly Dictionary<int, ThrowScore[]> _checkouts = CheckoutData.Scores;

        public ThrowScore[] Calculate(int number)
        {
            var checkoutNeeded = _checkouts.FirstOrDefault(cd => cd.Key == number);

            if (checkoutNeeded.Value != null)
            {
                return checkoutNeeded.Value;
            }

            throw new InvalidOperationException("No checkout available for the given number");
        }
        
        
    }
}
