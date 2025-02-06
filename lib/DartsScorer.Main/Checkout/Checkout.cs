using DartsScorer.Main.Scoring;
using Newtonsoft.Json;

namespace DartsScorer.Main.Checkout
{
    public class CheckoutCalculator
    {
        private readonly Dictionary<int, ThrowScore[]> _checkouts;

        public CheckoutCalculator()
        {
            var checkoutData = new CheckoutData();
            _checkouts = checkoutData.Scores;
        }

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
