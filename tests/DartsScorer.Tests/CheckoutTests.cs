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
        public void Calculate_InputNumberOutOfRange_Returns_Empty_Throw_List()
        {
            Assert.That(_checkout.Calculate(1).Length, Is.EqualTo(0));
            Assert.That(_checkout.Calculate(171).Length, Is.EqualTo(0));
        }
    }
}
