namespace EmojiMiddleware.Infrastructure;

public class EmojiMiddleware
{
    private readonly RequestDelegate _next;

    public EmojiMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        using var buffer = new MemoryStream();
        
        // Replace the context response with our buffer
        var stream = context.Response.Body;
        context.Response.Body = buffer;

        // Invoke the rest of the pipeline 
        // if there are any other middleware components
        await _next(context);

        // Reset and read out the contents
        buffer.Seek(0, SeekOrigin.Begin);

        // Adjust the response stream to include our images.
        var emojiStream = new EmojiStream(stream);

        // Reset the stream again
        buffer.Seek(0, SeekOrigin.Begin);

        // Copy our content to the original stream and put it back
        await buffer.CopyToAsync(emojiStream);
        context.Response.Body = emojiStream;
    }
}

public static class EmojiMiddlewareExtensions
{
    public static IApplicationBuilder UseEmojiMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EmojiMiddleware>();
    }
}
