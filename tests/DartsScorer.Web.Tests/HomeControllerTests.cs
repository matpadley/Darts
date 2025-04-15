using DartsScorer.Web.Controllers;
using DartsScorer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DartsScorer.Web.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Index_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Privacy_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Privacy();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Error_ReturnsViewResultWithErrorViewModel()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Error() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ErrorViewModel>(result.Model);
    }
}