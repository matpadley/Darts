using DartsScorer.Web.Controllers;
using DartsScorer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DartsScorer.Web.Tests;

public class HomeControllerTests
{
    [Test]
    public void Index_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Privacy_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Privacy();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Error_ReturnsViewResultWithErrorViewModel()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Error() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ErrorViewModel>(result.Model);
    }
}