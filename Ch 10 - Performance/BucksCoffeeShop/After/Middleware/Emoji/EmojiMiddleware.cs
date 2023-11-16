using System.IO.Pipelines;

namespace BucksCoffeeShopAfter.Middleware.Emoji;

public class EmojiMiddleware
{
    private readonly RequestDelegate _next;

    public EmojiMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        //if (httpContext.Request.Method != HttpMethods.Post)
        //{
        //    return;
        //}

        var bodyReader = httpContext.Request.BodyReader;
        ReadResult readResult;
        while (true)
        {
            readResult = await bodyReader.ReadAsync();
            if (readResult.IsCompleted)
            {
                break;
            }
            bodyReader.AdvanceTo(readResult.Buffer.Start, readResult.Buffer.End);
        }
        Process(readResult.Buffer);  // process the read only sequence
        bodyReader.Complete();     //  with this line , or without this line, both doesn't work










        //if (httpContext.Request.Method != HttpMethods.Post)
        //{
        //    return;
        //}

        // don't get it by `PipeReader.Create(httpContext.Request.Body);`
        // var bodyReader = httpContext.Request.BodyReader;

        // demo:  read all the body without consuming it
        //ReadResult readResult;
        //while (true)
        //{
        //    readResult = await bodyReader.ReadAsync();
        //    if (readResult.IsCompleted) { break; }
        //    // don't consume them, but examine them
        //    bodyReader.AdvanceTo(readResult.Buffer.Start, readResult.Buffer.End);
        //}

        //// now all the body payload has been read into buffer
        //var buffer = readResult.Buffer;
        //// Process(ref buffer);              // process the payload (ReadOnlySequence<byte>)

        //// Finally, reset the EXAMINED POSITION here
        //bodyReader.AdvanceTo(readResult.Buffer.Start, readResult.Buffer.Start);

        //await _next(httpContext);


    }

}