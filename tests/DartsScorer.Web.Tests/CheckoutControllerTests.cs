using DartsScorer.Web.Controllers;
using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DartsScorer.Web.Tests;

public class CheckoutControllerTests
{
    [Test]
    public void Index_ReturnsViewResult()
    {
        // Arrange
        var mockService = new Mock<ICheckoutService>();
        var controller = new CheckoutController(mockService.Object);

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void CheckoutResult_ValidScore_ReturnsViewWithModel()
    {
        // Arrange
        var mockService = new Mock<ICheckoutService>();
        mockService.Setup(s => s.GetCheckoutResult(It.IsAny<int>()))
            .Returns(new CheckoutResultModel { Score = 170, Results = new List<string> { "Result1" } });

        var controller = new CheckoutController(mockService.Object);

        // Act
        var result = controller.CheckoutResult(170) as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<CheckoutResultModel>(result.Model);
        var model = result.Model as CheckoutResultModel;
        Assert.AreEqual(170, model.Score);
    }

    [Test]
    public void CheckoutResult_Exception_ReturnsNoCheckoutView()
    {
        // Arrange
        var mockService = new Mock<ICheckoutService>();
        mockService.Setup(s => s.GetCheckoutResult(It.IsAny<int>())).Throws(new Exception());

        var controller = new CheckoutController(mockService.Object);

        // Act
        var result = controller.CheckoutResult(170) as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("NoCheckout", result.ViewName);
    }
}