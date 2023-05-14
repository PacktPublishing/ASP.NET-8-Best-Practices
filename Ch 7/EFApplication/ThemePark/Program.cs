using System.Reflection;
using EFApplication.DataContext;
using EFApplication.Services;

var builder = WebApplication.CreateBuilder(args);

//var config = new MapperConfiguration(cfg =>
//{
//    cfg.AddProfile<ThemeParkProfile>();
//});

// builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<ThemeParkDbContext>(connectionString);

builder.Services.AddTransient<IThemeParkDbContext, ThemeParkDbContext>();
builder.Services.AddTransient<IAttractionService, AttractionService>();
builder.Services.AddTransient<ILocationService, LocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
