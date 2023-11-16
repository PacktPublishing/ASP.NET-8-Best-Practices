using Microsoft.Extensions.DependencyInjection;
using ThemePark.Data.DataContext;

namespace ThemePark.Api.Tests;

[TestClass]
public class ApiTests
{
    private TestThemeParkApiApplication _app;

    [TestInitialize]
    public void Setup()
    {
        _app = new TestThemeParkApiApplication();
        using (var scoped = _app.Services.CreateScope())
        {
            var context = scoped.ServiceProvider.GetService<IThemeParkDbContext>();
            context?.Database.EnsureCreated();
        }
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task GetAllAttractions()
    {
        // Arrange
        var client = _app.CreateClient();
        var expected = TestData.ExpectedAttractionData;

        // Act
        var response = await client.GetAsync("/attractions");
        var actual = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
