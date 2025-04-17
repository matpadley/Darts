using DartsScorer.Web.Controllers;
using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DartsScorer.Web.Tests;

public class X01ControllerTests
{
    [Test]
    public void Index_ReturnsViewResultWithPlayerList()
    {
        // Arrange
        var mockX01Service = new Mock<IX01Service>();
        var mockPlayerService = new Mock<IPlayerService>();
        mockPlayerService.Setup(s => s.GetPlayersForDropDown()).Returns(new List<string> { "Player 1", "Player 2" });

        var controller = new X01Controller(mockX01Service.Object, mockPlayerService.Object);

        // Act
        var result = controller.Index(false) as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ViewData["PlayerList"]);
        Assert.IsInstanceOf<List<SelectListItem>>(result.ViewData["PlayerList"]);
    }

    [Test]
    public void AddPlayer_CallsServicesAndRedirects()
    {
        // Arrange
        var mockX01Service = new Mock<IX01Service>();
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new X01Controller(mockX01Service.Object, mockPlayerService.Object);

        // Act
        var result = controller.AddPlayer("New Player") as RedirectToActionResult;

        // Assert
        mockX01Service.Verify(s => s.AddPlayer("New Player"), Times.Once);
        mockPlayerService.Verify(s => s.Add("New Player"), Times.Once);
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ActionName);
    }

    [Test]
    public void StartMatch_CallsServiceAndRedirects()
    {
        // Arrange
        var mockX01Service = new Mock<IX01Service>();
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new X01Controller(mockX01Service.Object, mockPlayerService.Object);

        // Act
        var result = controller.StartMatch() as RedirectToActionResult;

        // Assert
        mockX01Service.Verify(s => s.StartMatch(), Times.Once);
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ActionName);
    }
}