using DartsScorer.Web.Controllers;
using DartsScorer.Web.Models.UpdateModels;
using DartsScorer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DartsScorer.Web.Tests;

public class PlayerControllerTests
{
    [Fact]
    public void Index_ReturnsViewResultWithPlayers()
    {
        // Arrange
        var mockPlayerService = new Mock<IPlayerService>();
        mockPlayerService.Setup(s => s.GetPlayers()).Returns(new List<Player>
        {
            new Player { Name = "Player 1" },
            new Player { Name = "Player 2" }
        });

        var controller = new PlayerController(mockPlayerService.Object);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Player>>(result.Model);
        var model = result.Model as List<Player>;
        Assert.Equal(2, model.Count);
        Assert.Equal("Player 1", model[0].Name);
        Assert.Equal("Player 2", model[1].Name);
    }

    [Fact]
    public void AddPlayer_CallsServiceAndRedirects()
    {
        // Arrange
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new PlayerController(mockPlayerService.Object);

        // Act
        var result = controller.AddPlayer("New Player") as RedirectToActionResult;

        // Assert
        mockPlayerService.Verify(s => s.Add("New Player"), Times.Once);
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }

    [Fact]
    public void DeletePlayer_CallsServiceAndRedirects()
    {
        // Arrange
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new PlayerController(mockPlayerService.Object);

        var model = new EditPlayerModel { Name = "Player 1" };

        // Act
        var result = controller.DeletePlayer(model) as RedirectToActionResult;

        // Assert
        mockPlayerService.Verify(s => s.Delete("Player 1"), Times.Once);
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }

    [Fact]
    public void EditPlayer_CallsServiceAndRedirects()
    {
        // Arrange
        var mockPlayerService = new Mock<IPlayerService>();

        var controller = new PlayerController(mockPlayerService.Object);

        var model = new EditPlayerModel { OldName = "Player 1", Name = "Player 2" };

        // Act
        var result = controller.EditPlayer(model) as RedirectToActionResult;

        // Assert
        mockPlayerService.Verify(s => s.Edit("Player 1", "Player 2"), Times.Once);
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }
}