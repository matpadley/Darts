using DartsScorer.Main.Functions;
using DartsScorer.Main.Scoring;
using Newtonsoft.Json;

namespace DartsScorer.Main.Checkout
{
    public class CheckoutCalculator
    {
        private readonly Dictionary<int, string[]>? _checkouts = JsonConvert
            .DeserializeObject<Dictionary<int, string[]>>(File.ReadAllText(Path.Combine("checkout","scores.json")));

        private readonly DartThrowConverter _converter = new();

        public ThrowScore[] Calculate(int number)
        {
            if (_checkouts.TryGetValue(number, out var checkoutNeeded))
            {
                return checkoutNeeded.Select(score =>
                {
                    var convertedScore = _converter.Convert(score);
                    return new ThrowScore(convertedScore.boardMultiplier, convertedScore.boardScore);
                }).ToArray();
            }

            throw new InvalidOperationException("No checkout available for the given number");
        }
    }
}