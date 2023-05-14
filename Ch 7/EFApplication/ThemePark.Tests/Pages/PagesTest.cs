using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Moq;
using ThemePark.Pages;
using ThemePark.Services;

namespace ThemePark.Tests.Pages;

[TestClass]
public class PagesTest
{
    [TestMethod]
    [TestCategory("Integration")]
    public void ConfirmTheMainPageReturnsWithinThreeSecondTest()
    {
        // Arrange
        var logger = new Mock<ILogger<IndexModel>>();
        var service = new Mock<IAttractionService>();

        var stopwatch = Stopwatch.StartNew();

        // Act
        _ = new IndexModel(logger.Object, service.Object);

        // Assert
        // Make sure our call is less than 3 seconds
        stopwatch.Stop();
        var duration = stopwatch.Elapsed.Seconds;

        Assert.IsTrue(duration <= 3);
    }
}
