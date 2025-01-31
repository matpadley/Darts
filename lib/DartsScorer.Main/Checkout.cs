using Newtonsoft.Json;

namespace DartsScorer.Main
{
    public class Checkout
    {
        private readonly Dictionary<int, string[]> _checkouts;

        public Checkout()
        {
            var json = File.ReadAllText("checkout.json");
            _checkouts = JsonConvert.DeserializeObject<Dictionary<int, string[]>>(json);
        }

        public string[] Calculate(int number)
        {
            if (number < 2 || number > 170)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "NNo checkout available for the given number");
            }

            if (_checkouts.TryGetValue(number, out var checkout))
            {
                return checkout;
            }

            throw new InvalidOperationException("No checkout available for the given number");
        }
    }
}
