using DartsScorer.Main.Checkout;

namespace DartsScorer.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private CheckoutCalculator _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new CheckoutCalculator();
        }

        [Test]
        public void Calculate_InputNumberOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<InvalidOperationException>(() => _checkout.Calculate(1));
            Assert.Throws<InvalidOperationException>(() => _checkout.Calculate(171));
        }
    }
}
