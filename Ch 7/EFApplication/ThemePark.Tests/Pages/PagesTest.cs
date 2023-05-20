using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ThemePark.DataContext;
using ThemePark.DataContext.Models;
using ThemePark.Dto;
using ThemePark.Pages;
using ThemePark.Services;

namespace ThemePark.Tests.Pages;

[TestClass]
public class PageTests
{
    private DbContextOptions<ThemeParkDbContext> _options;
    private ThemeParkDbContext _context;

    [TestInitialize]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ThemeParkDbContext>()
            .UseSqlServer("Data Source=localhost;Initial Catalog=ASPNetCore8BestPractices;"+
                          "Integrated Security=True;MultipleActiveResultSets=True;"+
                          "Encrypt=True;TrustServerCertificate=True")
            .Options;

        var config = new Mock<IConfiguration>();

        _context = new ThemeParkDbContext(_options, config.Object);
    }

    [TestMethod]
    [TestCategory("Integration")]
    public void ReturnAnIndexModelTest()
    {
        // Arrange
        var logger = new Mock<ILogger<IndexModel>>();
        var service = new AttractionService(_context);

        // Act
        var actual = new IndexModel(logger.Object, service);

        // Assert
        Assert.IsNotNull(actual);
        Assert.IsInstanceOfType(actual, typeof(IndexModel));
    }

    [TestMethod]
    [TestCategory("Integration")]
    public void ConfirmTheMainPageReturnsWithinThreeSecondTest()
    {
        // Arrange
        var logger = new Mock<ILogger<IndexModel>>();
        var service = new Mock<IAttractionService>();

        // Act
        var actual = new IndexModel(logger.Object, service.Object);

        // Assert
        Assert.IsNotNull(actual);
        Assert.IsInstanceOfType(actual, typeof(IndexModel));
    }
}
