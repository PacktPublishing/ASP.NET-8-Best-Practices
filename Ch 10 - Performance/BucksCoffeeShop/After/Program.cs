using BucksCoffeeShopAfter.Middleware.Emoji;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// builder.Services.AddSingleton<EmojiMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Cached for 24 hours.
        var response = ctx.Context.Response;
        var duration = 60 * 60 * 24; // 24h duration.
        response.Headers[HeaderNames.CacheControl] =
            "public,max-age=" + duration;
    }
});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEmojiMiddleware();

app.Run();
