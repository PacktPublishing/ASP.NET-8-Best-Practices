using ThemePark.Data.DataContext;
using ThemePark.Data.Dto;
using ThemePark.Data.Extensions;
using ThemePark.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<ThemeParkDbContext>(connectionString);

builder.Services.AddTransient<IThemeParkDbContext, ThemeParkDbContext>();
builder.Services.AddTransient<IAttractionService, AttractionService>();
builder.Services.AddTransient<ILocationService, LocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/attractions", async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var attractionService = scope.ServiceProvider.GetRequiredService<IAttractionService>();
        var attractions = await attractionService.GetAttractionsAsync();
        return attractions.Select(y => y.ToDto());
    }
})
.WithName("Attractions")
.WithOpenApi();

app.MapGet("/locations", async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var locationService = scope.ServiceProvider.GetRequiredService<ILocationService>();
        var locations = await locationService.GetLocationsAsync();
        return locations.Select(y => y.ToDto());
    }
})
.WithName("Locations")
.WithOpenApi();

app.Run();

public partial class Program { }
