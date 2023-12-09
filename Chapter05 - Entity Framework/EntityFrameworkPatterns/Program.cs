using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.Repository_UOW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ThemeParkDbContext>((provider, options) =>
    {
        var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
        options.UseLoggerFactory(loggerFactory);
        options.UseInMemoryDatabase("ThemeParkRides");
    },
    ServiceLifetime.Transient);

builder.Services.AddTransient<IThemeParkDbContext, ThemeParkDbContext>();
builder.Services.AddTransient<IAttractionService, AttractionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var context = new ThemeParkDbContext(new DbContextOptions<ThemeParkDbContext>()))
{
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
