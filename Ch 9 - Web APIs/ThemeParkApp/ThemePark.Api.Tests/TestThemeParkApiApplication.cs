using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using ThemePark.Data.DataContext;

namespace ThemePark.Api.Tests;

public class TestThemeParkApiApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptionsBuilder<ThemeParkDbContext>));

            services.AddScoped(sp => new DbContextOptionsBuilder<ThemeParkDbContext>()
                .UseInMemoryDatabase("TestApi", root)
                .UseApplicationServiceProvider(sp)
                .Options);

            services.AddDbContext<ThemeParkDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });

            services.AddTransient<IThemeParkDbContext, ThemeParkDbContext>();
        });

        return base.CreateHost(builder);
    }
}
