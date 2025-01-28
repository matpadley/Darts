using System;
using NUnit.Framework;
using DartsScorer.Checkout;

namespace DartsScorer.Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void Calculate_InputNumberOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _checkout.Calculate(1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _checkout.Calculate(171));
        }

        [Test]
        public void Calculate_ValidInputNumber_ReturnsCheckoutArray()
        {
            var result = _checkout.Calculate(2);
            Assert.AreEqual(new[] { "D1" }, result);

            result = _checkout.Calculate(170);
            Assert.AreEqual(new[] { "T56", "2" }, result);
        }

        [Test]
        public void Calculate_InvalidInputNumber_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _checkout.Calculate(171));
        }
    }
}
