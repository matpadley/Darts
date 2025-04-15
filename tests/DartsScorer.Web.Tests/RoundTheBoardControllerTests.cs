using DartsScorer.Web.Controllers;
using DartsScorer.Web.Models;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DartsScorer.Web.Tests;

public class RoundTheBoardControllerTests
{
    [Fact]
    public void Index_ReturnsViewResultWithPlayerList()
    {
        // Arrange
        var mockMatchService = new Mock<IRoundTheBoardService>();
        var mockPlayerService = new Mock<IPlayerService>();
        mockPlayerService.Setup(s => s.GetPlayersForDropDown()).Returns(new List<string> { "Player 1", "Player 2" });

        var controller = new RoundTheBoardController(mockMatchService.Object, mockPlayerService.Object);

        // Act
        var result = controller.Index(false) as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.ViewData["PlayerList"]);
        Assert.IsType<List<string>>(result.ViewData["PlayerList"]);
    }

    [Fact]
    public void AddPlayer_CallsServicesAndRedirects()
    {
        // Arrange
        var mockMatchService = new Mock<IRoundTheBoardService>();
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new RoundTheBoardController(mockMatchService.Object, mockPlayerService.Object);

        // Act
        var result = controller.AddPlayer("New Player") as RedirectToActionResult;

        // Assert
        mockMatchService.Verify(s => s.AddPlayer("New Player"), Times.Once);
        mockPlayerService.Verify(s => s.Add("New Player"), Times.Once);
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }

    [Fact]
    public void StartMatch_CallsServiceAndRedirects()
    {
        // Arrange
        var mockMatchService = new Mock<IRoundTheBoardService>();
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new RoundTheBoardController(mockMatchService.Object, mockPlayerService.Object);

        // Act
        var result = controller.StartMatch() as RedirectToActionResult;

        // Assert
        mockMatchService.Verify(s => s.StartMatch(), Times.Once);
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }
}