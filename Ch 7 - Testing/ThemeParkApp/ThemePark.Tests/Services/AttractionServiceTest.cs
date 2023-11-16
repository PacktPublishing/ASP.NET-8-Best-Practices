using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Moq;
using ThemePark.DataContext;
using ThemePark.Services;

namespace ThemePark.Tests.Services;

[TestClass]
public class AttractionServiceTest
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
    public async Task ReturnAllAttractionsTest()
    {
        // Arrange
        var service = new AttractionService(_context);

        // Act
        var records = await service.GetAttractionsAsync();

        // Assert
        Assert.IsTrue(records.Any());
    }
}
