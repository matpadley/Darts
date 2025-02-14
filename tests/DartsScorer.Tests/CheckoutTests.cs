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

        // add an nunit testcase that has the first parameter of an integer and the second of an arrary
        // the array should be the expected result
        [TestCase(2, new []{"D1"})]
        [TestCase(170, new []{"T20", "T20", "DB"})]
        [TestCase(138, new [] {"T20", "T14", "D18" })]
        public void Calculate_ValidInputNumber_ReturnsCheckoutArray(int requiredScore, string[] checkoutArray)
        {
            var result = _checkout.Calculate(requiredScore);
            
           // Assert.That(result, Is.EqualTo(checkoutArray).AsCollection);
            
        }
    }
}
