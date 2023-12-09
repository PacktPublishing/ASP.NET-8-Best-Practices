using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using ThemePark.Data.DataContext;
using ThemePark.Services.Services;

namespace ThemePark.Tests.Services;

[TestClass]
public class LocationServiceTest
{
    private DbConnection _connection = null!;
    private DbContextOptions<ThemeParkDbContext> _options = null!;
    private IThemeParkDbContext _context = null!;

    [TestInitialize]
    public void Setup()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite,
        // including the connection opened above.
        _options = new DbContextOptionsBuilder<ThemeParkDbContext>()
            .UseSqlite(_connection)
            .Options;

        var config = new Mock<IConfiguration>();

        // Create the schema and seed some data
        _context = new ThemeParkDbContext(_options, config.Object);
        _context?.Database.EnsureCreated();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _connection.Dispose();
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task ReturnAllLocationsTest()
    {
        // Arrange
        var service = new LocationService(_context);

        // Act
        var records = await service.GetLocationsAsync();

        // Assert
        Assert.IsTrue(records.Any());
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task ReturnOneLocationByIdTest()
    {
        // Arrange
        var service = new LocationService(_context);

        // Act
        var record = await service.GetLocationAsync(1);

        // Assert
        Assert.IsNotNull(record);
        Assert.IsTrue(record.Id==1);
    }

}