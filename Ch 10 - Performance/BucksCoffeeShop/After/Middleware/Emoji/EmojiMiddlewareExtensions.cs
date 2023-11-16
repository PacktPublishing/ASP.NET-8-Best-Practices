namespace BucksCoffeeShopAfter.Middleware.Emoji;

public static class EmojiMiddlewareExtensions
{
    public static IApplicationBuilder UseEmojiMiddleware(
        this IApplicationBuilder builder) =>
        builder.UseMiddleware<EmojiMiddleware>();
}